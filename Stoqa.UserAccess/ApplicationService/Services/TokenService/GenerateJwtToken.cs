using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Request;
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Response;
using Stoqa.Identity.ApplicationService.DTOs.Google;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;
using Stoqa.Identity.Extensions;
using Stoqa.Identity.Infraestrutura.Interface;

namespace Stoqa.Identity.ApplicationService.Services.TokenService;

public sealed class GenerateJwtToken(
    IConfiguration configuration,
    IHttpClientFactory httpClientFactory,
    IUserAuthenticationRepository userAuthenticationRepository,
    IUserRepository userRepository) : IGenerateJwtToken
{
    public async Task<TokenResponse> ExchangeCodeForTokenAsync(GoogleAuthRequest request)
    {
        var tokenResponse = await RequestGoogleTokenAsync(request);

        if (tokenResponse is null)
            return TokenResponse.Failure("Autenticação com google falhou");

        var payload = ExtensionParse.ParseIdToken(tokenResponse.IdToken);

        if (payload!.Value.Email.IsNullOrEmpty() || payload.Value.Name.IsNullOrEmpty())
            return TokenResponse.Failure("Insira todos os valores obrigátorios");

        var user = await userRepository.FindByPredicateAsync(u => u.UserName == payload.Value.Email,
            i => i.Include(ur => ur.UserRoles)!
                .ThenInclude(r => r.Role)!);

        if (user is null)
            return TokenResponse.Failure("Colaborador não encontrado no sistema");

        var role = user.UserRoles!.Select(ur => ur.Role!.Name).First();

        var jwtToken = await GenerateNewToken(payload.Value.Email, payload.Value.Name, role!);

        return TokenResponse.Success(jwtToken);
    }

    public async Task<TokenResponse> AuthenticationTokenAsync(CollaboratorAuthenticationRequest request)
    {
        var user = await userRepository.FindByPredicateAsync(u => u.UserName == request.Email,
            i => i.Include(ur => ur.UserRoles)!
                .ThenInclude(r => r.Role)!);

        if (user is null)
            return TokenResponse.Failure("Não foi encontrado colaborador com esse email");

        var authenticated = await IsUserAuthenticatedAsync(request.Email, request.Password);
        if (!authenticated)
            return TokenResponse.Failure("Autenticação falhou");

        var role = user.UserRoles!.Select(ur => ur.Role!.Name).First();

        var token = await GenerateNewToken(user.UserName!, user.DisplayName, role!);
        return TokenResponse.Success(token);
    }

    private async Task<bool> IsUserAuthenticatedAsync(string email, string password)
    {
        var result = await userAuthenticationRepository.UserAuthenticationAsync(email, password);
        return result.Succeeded;
    }

    private async Task<GoogleTokenResponse?> RequestGoogleTokenAsync(GoogleAuthRequest request)
    {
        var client = httpClientFactory.CreateClient();
        const string googleTokenEndpoint = "https://oauth2.googleapis.com/token";

        var parameters = new Dictionary<string, string>
        {
            { "code", WebUtility.UrlDecode(request.Code) },
            { "client_id", configuration["Authentication:Google:ClientId"]! },
            { "client_secret", configuration["Authentication:Google:ClientSecret"]! },
            { "redirect_uri", request.RedirectUri },
            { "grant_type", "authorization_code" }
        };

        var response = await client.PostAsync(googleTokenEndpoint, new FormUrlEncodedContent(parameters));

        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();

        return string.IsNullOrWhiteSpace(content)
            ? null
            : JsonSerializer.Deserialize<GoogleTokenResponse>(content);
    }

    private async Task<string> GenerateNewToken(string email, string name, string role)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:Key"]!);
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Name, name),
            new(ClaimTypes.Role, role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(45),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return await Task.FromResult(tokenHandler.WriteToken(token));
    }
}
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Request;
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Response;
using Stoqa.Identity.ApplicationService.DTOs.Google;

namespace Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;

public interface IGenerateJwtToken
{
    Task<TokenResponse> ExchangeCodeForTokenAsync(GoogleAuthRequest request);
    Task<TokenResponse> AuthenticationTokenAsync(CollaboratorAuthenticationRequest request);
}
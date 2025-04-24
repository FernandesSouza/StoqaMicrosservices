using Microsoft.AspNetCore.Mvc;
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Request;
using Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Response;
using Stoqa.Identity.ApplicationService.DTOs.Google;
using Stoqa.Identity.ApplicationService.Interfaces;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;

namespace Stoqa.Identity.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class AuthenticationController(
    IGenerateJwtToken tokenService
) : ControllerBase
{
    [HttpPost("signin-google")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TokenResponse> SignInGoogle([FromBody] GoogleAuthRequest request) =>
        await tokenService.ExchangeCodeForTokenAsync(request);

    [HttpPost("create_access_token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TokenResponse> SignIn(CollaboratorAuthenticationRequest collaboratorAuthenticationRequest) =>
        await tokenService.AuthenticationTokenAsync(collaboratorAuthenticationRequest);
}
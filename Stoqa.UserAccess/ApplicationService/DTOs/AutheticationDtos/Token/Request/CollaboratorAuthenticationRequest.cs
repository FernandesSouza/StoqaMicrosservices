namespace Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Request;

public sealed record CollaboratorAuthenticationRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
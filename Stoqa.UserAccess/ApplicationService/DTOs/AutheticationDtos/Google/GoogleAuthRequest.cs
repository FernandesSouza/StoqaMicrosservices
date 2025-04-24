namespace Stoqa.Identity.ApplicationService.DTOs.Google;

public sealed record GoogleAuthRequest
{
    public required string Code { get; set; }
    public required string RedirectUri { get; set; }
}
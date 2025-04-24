namespace Stoqa.Identity.ApplicationService.DTOs.AutheticationDtos.Token.Response;

public sealed record TokenResponse
{
    public string? Value { get; set; }
    public string? Error { get; set; }

    public static TokenResponse Success(string token) => new() { Value = token };
    public static TokenResponse Failure(string error) => new() { Error = error };
}
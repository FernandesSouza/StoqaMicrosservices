using System.Text.Json.Serialization;

namespace Stoqa.Identity.ApplicationService.DTOs.Google;

public sealed record GoogleTokenResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    [JsonPropertyName("id_token")]
    public required string IdToken { get; init; }
}
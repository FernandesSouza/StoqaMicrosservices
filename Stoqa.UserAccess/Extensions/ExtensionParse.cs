using System.IdentityModel.Tokens.Jwt;

namespace Stoqa.Identity.Extensions;

public static class ExtensionParse
{
    public static (string Email, string Name)? ParseIdToken(string idToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(idToken);

        var email = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
        var name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

        if (email == null) return null;

        return (email, name)!;
    }
}
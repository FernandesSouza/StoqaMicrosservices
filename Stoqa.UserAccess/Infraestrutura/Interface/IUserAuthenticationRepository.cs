using Microsoft.AspNetCore.Identity;

namespace Stoqa.Identity.Infraestrutura.Interface;

public interface IUserAuthenticationRepository
{
    Task<SignInResult> UserAuthenticationAsync(string login, string password);
}
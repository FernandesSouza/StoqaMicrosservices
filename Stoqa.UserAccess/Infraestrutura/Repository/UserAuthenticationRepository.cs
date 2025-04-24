using Microsoft.AspNetCore.Identity;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.Interface;

namespace Stoqa.Identity.Infraestrutura.Repository;

public sealed class UserAuthenticationRepository(
    SignInManager<User> signInManager
) : IUserAuthenticationRepository
{
    public async Task<SignInResult> UserAuthenticationAsync(string login, string password) =>
        await signInManager.PasswordSignInAsync(login, password, false, true);
}
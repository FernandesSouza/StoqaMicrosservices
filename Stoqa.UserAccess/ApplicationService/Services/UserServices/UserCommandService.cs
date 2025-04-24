using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Request;
using Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;
using Stoqa.Identity.Infraestrutura.Interface;

namespace Stoqa.Identity.ApplicationService.Services.UserServices;

public sealed class UserCommandService(
    IUserRepository userRepository,
    IUserMappers userMappers
) : IUserCommandService
{
    //TODO: CRIAR VALIDAÇÃO DE USUÁRIO
    public async Task<bool> RegisterAsync(UserRegisterRequest userRegisterRequest)
    {
        var user = userMappers.RegisterDtoToDomain(userRegisterRequest);

        var passwordHash = await userRepository.PasswordHashAsync(user.PasswordHash!);

        user.PasswordHash = passwordHash;

        var result = await userRepository.SaveAsync(user);

        return result.Succeeded;
    }
}
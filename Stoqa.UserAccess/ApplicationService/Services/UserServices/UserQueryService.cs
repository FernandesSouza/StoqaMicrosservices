using Microsoft.EntityFrameworkCore;
using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;
using Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;
using Stoqa.Identity.Infraestrutura.Interface;

namespace Stoqa.Identity.ApplicationService.Services.UserServices;

public class UserQueryService(
    IUserRepository userRepository,
    IUserMappers userMappers
) : IUserQueryService
{
    public async Task<UserSimpleResponse?> FindByEmailAsync(string email)
    {
        var user = await userRepository.FindByPredicateAsync(x => x.UserName == email,
            i => i.Include(ur => ur.UserRoles)!
                .ThenInclude(r => r.Role)!);

        return user is not null
            ? userMappers.DomainToSimpleResponse(user)
            : null;
    }
}
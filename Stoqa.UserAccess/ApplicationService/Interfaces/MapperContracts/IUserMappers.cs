using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Request;
using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;
using Stoqa.Identity.Domain.Entities;

namespace Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;

public interface IUserMappers
{
    User RegisterDtoToDomain(UserRegisterRequest userRegisterRequest);
    UserSimpleResponse DomainToSimpleResponse(User user);
}
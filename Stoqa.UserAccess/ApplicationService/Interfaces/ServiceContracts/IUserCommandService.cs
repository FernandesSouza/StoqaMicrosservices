using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Request;

namespace Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;

public interface IUserCommandService
{
    Task<bool> RegisterAsync(UserRegisterRequest userRegisterRequest);
}
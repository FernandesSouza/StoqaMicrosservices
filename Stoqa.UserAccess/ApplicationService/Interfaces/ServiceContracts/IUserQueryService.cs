using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;

namespace Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;

public interface IUserQueryService
{
    Task<UserSimpleResponse?> FindByEmailAsync(string email);
}
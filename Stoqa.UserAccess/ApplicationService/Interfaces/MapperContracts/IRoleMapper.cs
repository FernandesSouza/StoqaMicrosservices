using Stoqa.Identity.ApplicationService.DTOs.RolesDtos.Response;
using Stoqa.Identity.Domain.Entities;

namespace Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;

public interface IRoleMapper
{
    List<RoleSimpleResponse> DomainToSimpleResponse(List<Role> role);
}
using Stoqa.Identity.ApplicationService.DTOs.RolesDtos.Response;
using Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;
using Stoqa.Identity.Domain.Entities;

namespace Stoqa.Identity.ApplicationService.Mappers;

public sealed class RoleMapper : IRoleMapper
{
    public List<RoleSimpleResponse> DomainToSimpleResponse(List<Role> role) =>
        role.Select(SingleToSimpleResponse).ToList();
    private RoleSimpleResponse SingleToSimpleResponse(Role role) =>
        new()
        {
            Name = role.Name!
        };
}
using Stoqa.Identity.ApplicationService.DTOs.RolesDtos.Response;
using Stoqa.Identity.Domain.Enums;

namespace Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;

public sealed record UserSimpleResponse
{
    public required string Email { get; set; }
    public required EUserStatus Status { get; set; }
    public required EUserType UserType { get; set; }
    public required string Password { get; set; }
    public required string DisplayName { get; set; }
    public string? Document { get; set; }
    public List<RoleSimpleResponse>? Roles { get; set; }
}
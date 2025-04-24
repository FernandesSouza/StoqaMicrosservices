using Microsoft.AspNetCore.Identity;
using Stoqa.Identity.Domain.Enums;

namespace Stoqa.Identity.Domain.Entities;

public sealed class User : IdentityUser<Guid>
{
    public required EUserStatus Status { get; set; }
    public required EUserType UserType { get; set; }
    public required DateTime CreationDate { get; set; }
    public required string DisplayName { get; set; }
    public required string NormalizedDisplayName { get; set; }
    public string? Document { get; set; }
    public List<UserRole>? UserRoles { get; set; }
}
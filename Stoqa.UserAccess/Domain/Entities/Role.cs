using Microsoft.AspNetCore.Identity;

namespace Stoqa.Identity.Domain.Entities;

public sealed class Role : IdentityRole<Guid>
{
    public bool Active { get; set; }
    public List<UserRole>? UserRoles { get; set; }
}
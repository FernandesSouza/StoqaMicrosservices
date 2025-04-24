using Microsoft.AspNetCore.Identity;

namespace Stoqa.Identity.Domain.Entities;

public sealed class UserRole : IdentityUserRole<Guid>
{
    public Role? Role { get; set; }
    public User? User { get; set; }
}
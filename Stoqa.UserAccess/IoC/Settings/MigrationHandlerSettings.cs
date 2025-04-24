using Microsoft.EntityFrameworkCore;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.ORM;

namespace Stoqa.Identity.IoC.Settings;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();

        await appContext.Database.MigrateAsync();
        await CreatingRoles(appContext);
    }

    private static async Task CreatingRoles(IdentityContext context)
    {
        var roles = new List<Role>
        {
            new()
            {
                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "b0e4f3f0-0f0f-4c6a-bc75-8f264d4ecfd2",
                Active = true,
                UserRoles = new List<UserRole>()
            },
            new()
            {
                Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                Name = "Collaborator",
                NormalizedName = "COLLABORATOR",
                ConcurrencyStamp = "a23b5a8b-4cfc-43c9-92c0-9bb582222d9d",
                Active = true,
                UserRoles = new List<UserRole>()
            },
            new()
            {
                Id = Guid.Parse("3d6fa9e2-56c4-4f5b-9e0e-785eb27f52c5"),
                Name = "Analyst",
                NormalizedName = "ANALYST",
                ConcurrencyStamp = "e96a450f-764f-476e-84b9-83221aaf3178",
                Active = true,
                UserRoles = new List<UserRole>()
            },
            new()
            {
                Id = Guid.Parse("6fa459ea-ee8a-3ca4-894e-db77e160355e"),
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "d1a890a1-9f3e-4b65-9e95-472f7fbe299a",
                Active = true,
                UserRoles = new List<UserRole>()
            }
        };

        var rolesAdded = false;

        foreach (var role in roles)
        {
            var exists = await context.Roles
                .AsNoTracking()
                .AnyAsync(r => r.NormalizedName == role.NormalizedName);

            if (exists) continue;
            await context.Roles.AddAsync(role);
            rolesAdded = true;
        }

        if (rolesAdded)
        {
            await context.SaveChangesAsync();
        }
    }
}
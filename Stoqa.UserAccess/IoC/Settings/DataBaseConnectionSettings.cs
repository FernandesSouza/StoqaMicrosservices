using Microsoft.EntityFrameworkCore;
using Stoqa.Identity.Domain.Providers;
using Stoqa.Identity.Infraestrutura.ORM;

namespace Stoqa.Identity.IoC.Settings;

public static class DataBaseConnectionSettings
{
    public static void AddDataBaseConnectionSettings(this IServiceCollection services)
    {
        services.AddDbContext<IdentityContext>((serviceProv, options) =>
            options.UseNpgsql(
                serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection,
                sql => sql.CommandTimeout(180)));
    }
}
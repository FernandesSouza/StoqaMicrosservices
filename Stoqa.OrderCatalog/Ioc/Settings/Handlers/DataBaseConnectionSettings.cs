using Microsoft.EntityFrameworkCore;
using Stoqa.Domain.Providers;
using Stoqa.Infra.ORM.Context;

namespace Stoqa.OrderCatalog.Ioc.Settings.Handlers;

public static class DataBaseConnectionSettings
{
    public static void AddDataBaseConnectionSettings(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
            options.UseSqlServer(
                serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection,
                sql => sql.CommandTimeout(180)));
    }
}
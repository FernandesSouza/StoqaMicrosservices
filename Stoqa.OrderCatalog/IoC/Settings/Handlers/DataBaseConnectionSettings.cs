using Microsoft.EntityFrameworkCore;
using Stoqa.OrderCatalog.Domain.Providers;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;

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
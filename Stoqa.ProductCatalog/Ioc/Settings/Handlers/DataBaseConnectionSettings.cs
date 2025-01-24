using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.Domain.Providers;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;

namespace Stoqa.ProductCatalog.Ioc.Settings.Handlers;

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
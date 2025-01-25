using Microsoft.EntityFrameworkCore;
using Stoqa.Managment.Domain.Providers;
using Stoqa.Managment.Infraestrutura.ORM.Context;

namespace Stoqa.Managment.IoC.Settings.Handlers;

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
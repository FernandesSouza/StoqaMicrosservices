using Microsoft.EntityFrameworkCore;
using Stoqa.Infra.ORM.Context;

namespace Stoqa.OrderCatalog.Ioc.Settings.Handlers;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        await appContext.Database.MigrateAsync();
    }
}
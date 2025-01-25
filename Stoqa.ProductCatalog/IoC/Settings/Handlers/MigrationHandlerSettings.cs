using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;

namespace Stoqa.ProductCatalog.Ioc.Settings.Handlers;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        await appContext.Database.MigrateAsync();
    }
}
using Microsoft.Extensions.Options;
using Stoqa.OrderCatalog.Domain.Providers;

namespace Stoqa.OrderCatalog.IoC.Settings.Handlers;

public static class ProviderSettings
{
    public static void AddProviderSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
    }
}
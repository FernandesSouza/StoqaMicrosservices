using Microsoft.Extensions.Options;
using Stoqa.ProductCatalog.Domain.Providers;

namespace Stoqa.ProductCatalog.Ioc.Settings.Handlers;

public static class ProviderSettings
{
    public static void AddProviderSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
        
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<HttpUrlConnectionOptions>>()!.CurrentValue);
        services.Configure<HttpUrlConnectionOptions>(configuration.GetSection(HttpUrlConnectionOptions.SectionName));
    }
}
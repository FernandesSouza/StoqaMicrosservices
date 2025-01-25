using Microsoft.Extensions.Options;
using Stoqa.Managment.Domain.Providers;

namespace Stoqa.Settings.Handlers;

public static class ProviderSettings
{
    public static void AddProviderSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
    }
}
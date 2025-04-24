using Stoqa.OrderCatalog.Ioc.Settings.Handlers;
using Stoqa.OrderCatalog.IoC.Settings.Handlers;

namespace Stoqa.OrderCatalog.Ioc.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddProviderSettings(configuration);
        service.AddDataBaseConnectionSettings();
        service.AddFiltersSettings();
    }
}
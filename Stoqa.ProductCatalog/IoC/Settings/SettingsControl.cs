using Stoqa.ProductCatalog.Ioc.Settings.Handlers;
using Stoqa.ProductCatalog.IoC.Settings.Handlers;

namespace Stoqa.ProductCatalog.Ioc.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddProviderSettings(configuration);
        service.AddDataBaseConnectionSettings();
        service.AddFiltersSettings();
    }
}
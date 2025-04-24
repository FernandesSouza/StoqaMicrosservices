using Stoqa.Identity.IoC.Settings;

namespace Stoqa.Identity.IoC;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddProviderSettings(configuration);
        service.AddDataBaseConnectionSettings();
    }
}
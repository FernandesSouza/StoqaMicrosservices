using Stoqa.Managment.IoC.Settings.Handlers;
using Stoqa.Settings.Handlers;

namespace Stoqa.Managment.IoC.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddProviderSettings(configuration);
        service.AddDataBaseConnectionSettings();
    }
}
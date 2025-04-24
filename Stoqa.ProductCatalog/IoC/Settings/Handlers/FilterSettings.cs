using Stoqa.ProductCatalog.Filters;

namespace Stoqa.ProductCatalog.IoC.Settings.Handlers;

public static class FilterSettings
{
    public static void AddFiltersSettings(this IServiceCollection services)
    {
        services.AddMvc(config => config.Filters.AddService<NotificationFilter>());

        services.AddScoped<NotificationFilter>();
    }
}
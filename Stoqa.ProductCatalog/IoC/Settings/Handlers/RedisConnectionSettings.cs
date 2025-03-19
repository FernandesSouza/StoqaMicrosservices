namespace Stoqa.ProductCatalog.Ioc.Settings.Handlers;

public static class RedisConnectionSettings
{
    public static void AddRedisSettings(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = "DataBase_Conference";
            options.Configuration = "localhost:6379";
        });
    }
}
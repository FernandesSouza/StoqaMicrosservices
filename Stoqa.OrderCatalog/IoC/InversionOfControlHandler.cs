using Stoqa.Infra.ORM.Context;

namespace Stoqa.OrderCatalog.Ioc;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddScoped<ApplicationContext>();
}
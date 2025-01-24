using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;

namespace Stoqa.ProductCatalog.Ioc;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddScoped<ApplicationContext>();
}
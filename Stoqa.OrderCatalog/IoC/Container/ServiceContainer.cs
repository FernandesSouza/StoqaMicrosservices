using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.ApplicationService.Services.OrderService;

namespace Stoqa.OrderCatalog.IoC.Container;

public static class ServiceContainer
{
    public static IServiceCollection AddServiceContainer(this IServiceCollection service) =>
        service.AddScoped<IOrderSaleCommandService, OrderSaleCommandService>()
            .AddScoped<IOrderSaleQueryService, OrderSaleQueryService>()
        ;
}
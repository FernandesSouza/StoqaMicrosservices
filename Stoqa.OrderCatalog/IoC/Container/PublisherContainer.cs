using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Publishers;

namespace Stoqa.OrderCatalog.IoC.Container;

public static class PublisherContainer
{
    public static IServiceCollection AddPublisherContainer(this IServiceCollection service) =>
        service.AddScoped<IOrderInventoryPublisher, OrderInventoryPublisher>();
}
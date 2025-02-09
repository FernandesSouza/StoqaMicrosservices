using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;
using Stoqa.OrderCatalog.Infraestrutura.Repository;

namespace Stoqa.OrderCatalog.IoC.Container;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepositoryContainer(this IServiceCollection service) =>
        service.AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductOrderRepository, ProductOrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>();
}
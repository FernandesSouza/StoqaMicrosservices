using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.Repository;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepositoryContainer(this IServiceCollection service) =>
        service.AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IStockItemRepository, StockItemRepository>()
            .AddScoped<IItemRepository, ItemRepository>()
            .AddScoped<IDepositRepository, DepositRepository>();
}
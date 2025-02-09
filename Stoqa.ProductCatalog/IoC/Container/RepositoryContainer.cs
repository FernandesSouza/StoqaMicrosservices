using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.Repository;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepositoryContainer(this IServiceCollection service) =>
        service.AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IPackagingCompositionRepository, PackagingCompositionRepository>()
            .AddScoped<IStockItemRepository, StockItemRepository>();
}
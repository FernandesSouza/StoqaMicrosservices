using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.ServiceContracts;
using Stoqa.ProductCatalog.Infraestrutura.Service;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class PaginationQueryContainer
{
    public static IServiceCollection AddPaginationContainer(this IServiceCollection service) =>
        service.AddScoped<IPaginationQueryService<StockItem>, PaginationQueryService<StockItem>>();
}
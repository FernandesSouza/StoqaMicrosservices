using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Publishers;
using Stoqa.ProductCatalog.ApplicationService.Services.DepositService;
using Stoqa.ProductCatalog.ApplicationService.Services.ItemService;
using Stoqa.ProductCatalog.ApplicationService.Services.ProductService;
using Stoqa.ProductCatalog.ApplicationService.Services.StockItemService;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class ServiceContainer
{
    public static IServiceCollection AddServiceContainer(this IServiceCollection service) =>
        service.AddScoped<IProductCommandService, ProductCommandService>()
            .AddScoped<IProductQueryService, ProductQueryService>()
            .AddScoped<IProductSyncService, ProductSyncService>()
            .AddScoped<IStockItemCommandService, StockItemCommandService>()
            .AddScoped<IItemCommandService, ItemCommandService>()
            .AddScoped<IDepositCommandService, DepositCommandService>()
            .AddScoped<IItemQueryService, ItemQueryService>()
            .AddScoped<IStockItemQueryService, StockItemQueryService>()
            .AddScoped<IStockItemFacadeCommandService, StockItemCommandService>();
}
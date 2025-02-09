using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.ApplicationService.Services;
using Stoqa.ProductCatalog.ApplicationService.Services.PackagingCompositionServices;
using Stoqa.ProductCatalog.ApplicationService.Services.ProductService;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class ServiceContainer
{
    public static IServiceCollection AddServiceContainer(this IServiceCollection service) =>
        service.AddScoped<IProductCommandService, ProductCommandService>()
            .AddScoped<IProductQueryService, ProductQueryService>()
            .AddScoped<IPackagingCompositionCommandService, PackagingCompositionCommandService>();
}
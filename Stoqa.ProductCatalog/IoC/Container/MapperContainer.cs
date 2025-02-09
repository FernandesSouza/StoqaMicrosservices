using Stoqa.ProductCatalog.ApplicationService.Interfaces;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Mappers;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class MapperContainer
{
    public static IServiceCollection AddMapperContainer(this IServiceCollection service) =>
        service.AddScoped<IProductMapper, ProductMapper>()
            .AddScoped<IPackagingCompositionMapper, PackagingCompositionMapper>();
}
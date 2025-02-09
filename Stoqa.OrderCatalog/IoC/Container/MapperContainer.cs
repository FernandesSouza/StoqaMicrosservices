using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.ApplicationService.Mappers;

namespace Stoqa.OrderCatalog.IoC.Container;

public static class MapperContainer
{
    public static IServiceCollection AddMapperContainer(this IServiceCollection service) =>
        service.AddScoped<IOrderMapper, OrderMapper>()
            .AddScoped<IProductMapper, ProductMapper>();
}
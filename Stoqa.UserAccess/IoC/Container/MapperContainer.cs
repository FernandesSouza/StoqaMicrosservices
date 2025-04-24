using Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;
using Stoqa.Identity.ApplicationService.Mappers;

namespace Stoqa.Identity.IoC.Container;

public static class MapperContainer
{
    public static IServiceCollection AddMapperContainer(this IServiceCollection service) =>
        service.AddScoped<IUserMappers, UserMapper>()
            .AddScoped<IRoleMapper, RoleMapper>();
}
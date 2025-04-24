using Stoqa.Identity.Infraestrutura.Interface;
using Stoqa.Identity.Infraestrutura.Repository;

namespace Stoqa.Identity.IoC.Container;

public static class RepositoryContainer
{
    public static void AddRepositoryContainer(this IServiceCollection service) =>
        service.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>()
            .AddScoped<IUserRepository, UserRepository>();
}
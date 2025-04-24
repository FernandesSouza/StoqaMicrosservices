using Stoqa.Identity.IoC.Container;

namespace Stoqa.Identity.IoC;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddServiceContainer()
            .AddMapperContainer()
            .AddRepositoryContainer();
}
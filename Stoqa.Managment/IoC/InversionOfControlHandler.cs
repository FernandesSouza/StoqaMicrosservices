using Stoqa.Managment.Infraestrutura.ORM.Context;

namespace Stoqa.Managment.IoC;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddScoped<ApplicationContext>();
}
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Domain.UoW;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Ioc.Container;

namespace Stoqa.ProductCatalog.Ioc;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddScoped<ApplicationContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<INotficationHandler, NotificationHandler>()
            .AddMapperContainer()
            .AddRepositoryContainer()
            .AddServiceContainer()
            .AddPaginationContainer()
            .AddValidationContainer();
}
using Stoqa.OrderCatalog.Domain.Handlers.NotificationHandler;
using Stoqa.OrderCatalog.Domain.Interface;
using Stoqa.OrderCatalog.Domain.UoW;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using Stoqa.OrderCatalog.IoC.Container;

namespace Stoqa.OrderCatalog.Ioc;

public static class InversionOfControlHandler
{
    public static void AddInversionOfControlHandler(this IServiceCollection services) =>
        services.AddScoped<ApplicationContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<INotficationOrderHandler, NotificationOrderHandler>()
            .AddMapperContainer()
            .AddRepositoryContainer()
            .AddServiceContainer()
            .AddValidations()
            .AddPublisherContainer()
        ;
}
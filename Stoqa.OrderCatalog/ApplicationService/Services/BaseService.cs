using Stoqa.OrderCatalog.Domain.Interface;
using DomainNotification = Stoqa.OrderCatalog.Domain.Handlers.NotificationHandler.DomainNotification;

namespace Stoqa.OrderCatalog.ApplicationService.Services;

public abstract class BaseService<T>(
    INotficationOrderHandler notificationOrder,
    IValidate<T> validate) where T : class
{
    protected readonly INotficationOrderHandler NotificationOrder = notificationOrder;

    protected async Task<bool> EntityValidationAsync(T entity)
    {
        var validationResponse = await validate.ValidationAsync(entity);

        if (!validationResponse.Valid)
            NotificationOrder.CreateNotifications(DomainNotification.CreateNotifications(validationResponse.Errors));

        return validationResponse.Valid;
    }
}
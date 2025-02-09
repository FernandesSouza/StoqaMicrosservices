using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;
using Stoqa.ProductCatalog.Domain.Interfces;

namespace Stoqa.ProductCatalog.ApplicationService.Services;

public abstract class BaseService<T>(
    INotficationHandler notification,
    IValidate<T> validate) where T : class
{
    protected readonly INotficationHandler Notification = notification;

    protected async Task<bool> EntityValidationAsync(T entity)
    {
        var validationResponse = await validate.ValidationAsync(entity);

        if (!validationResponse.Valid)
            Notification.CreateNotifications(DomainNotification.CreateNotifications(validationResponse.Errors));

        return validationResponse.Valid;
    }
}
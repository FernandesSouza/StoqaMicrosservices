using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;

namespace Stoqa.ProductCatalog.Domain.Interfces;

public interface INotficationHandler
{
    List<DomainNotification> GetNotifications();
    bool HasNotification();
    void CreateNotification(DomainNotification domainNotification);
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
}
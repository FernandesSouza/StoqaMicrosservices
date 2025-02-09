using DomainNotification = Stoqa.OrderCatalog.Domain.Handlers.NotificationHandler.DomainNotification;

namespace Stoqa.OrderCatalog.Domain.Interface;

public interface INotficationOrderHandler
{
    List<DomainNotification> GetNotifications();
    bool HasNotification();
    void CreateNotification(DomainNotification domainNotification);
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
    bool CreateNotification(string key, string value);
}
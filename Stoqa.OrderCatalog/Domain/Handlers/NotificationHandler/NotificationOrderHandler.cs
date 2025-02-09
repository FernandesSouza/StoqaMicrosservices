using Stoqa.OrderCatalog.Domain.Interface;

namespace Stoqa.OrderCatalog.Domain.Handlers.NotificationHandler;

public class NotificationOrderHandler : INotficationOrderHandler
{
    private readonly List<DomainNotification> _notifications;

    public NotificationOrderHandler()
    {
        _notifications = new List<DomainNotification>();
    }

    public List<DomainNotification> GetNotifications() => _notifications;
    public bool HasNotification() => _notifications.Count > 0;

    public void CreateNotification(DomainNotification domainNotification) =>
        _notifications.Add(domainNotification);

    public void CreateNotifications(IEnumerable<DomainNotification> domainNotification) =>
        _notifications.AddRange(domainNotification);

    public bool CreateNotification(string key, string value)
    {
        _notifications.Add(new DomainNotification(key, value));

        return false;
    }
}
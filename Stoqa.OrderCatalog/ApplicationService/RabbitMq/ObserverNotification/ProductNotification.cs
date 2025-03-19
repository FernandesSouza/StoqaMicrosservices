using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq.ObserverNotification;

public sealed class ProductNotification
{
    private readonly List<IProductObserver> _observers = [];

    public void AddObserver(IProductObserver observer)
    {
        _observers.Add(observer);
    }

    public async Task NotificationCreateObserversAsync(ProductEventDto product)
    {

        var tasks = _observers.Select(o => o.HandleCreateEventAsync(product));
        await Task.WhenAll(tasks);
    }
}
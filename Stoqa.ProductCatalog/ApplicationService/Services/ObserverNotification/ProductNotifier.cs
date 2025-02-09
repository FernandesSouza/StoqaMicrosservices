using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ObserverContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ObserverNotification;

public sealed class ProductNotifier
{
    private readonly List<IProductObserver> _observers = [];

    public void AddObserver(IProductObserver observer)
    {
        _observers.Add(observer);
    }
    public async Task NotificationCreateObserversAsync(ProductEvent product)
    {
        var tasks = _observers.Select(o => o.HandleCreateEventAsync(product));
        await Task.WhenAll(tasks);
    }
}
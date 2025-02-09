using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ObserverContracts;

public interface IProductObserver
{
    Task HandleCreateEventAsync(ProductEvent product);
}
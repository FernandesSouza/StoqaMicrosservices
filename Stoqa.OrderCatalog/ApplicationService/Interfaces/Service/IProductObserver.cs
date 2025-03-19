using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IProductObserver
{
    Task HandleCreateEventAsync(ProductEventDto eventDto);
}
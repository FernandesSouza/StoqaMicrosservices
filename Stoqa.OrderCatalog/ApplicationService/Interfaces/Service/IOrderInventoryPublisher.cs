using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IOrderInventoryPublisher
{
    Task PublishOrder(OrderInventoryMessage message);
}
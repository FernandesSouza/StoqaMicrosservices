using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IOrderSaleQueryService
{
    Task<OrderConferenceResponse> GetByIdAsync(long orderId);
}
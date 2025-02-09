using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IOrderSaleCommandService
{
    Task<bool> RegisterAsync(OrderSaleRegisterRequest saleRegisterRequest);
    Task<bool> UpdateConferenceStatus(long orderId);
}
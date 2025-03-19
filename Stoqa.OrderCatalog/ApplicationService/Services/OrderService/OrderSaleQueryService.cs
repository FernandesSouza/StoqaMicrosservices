using Microsoft.EntityFrameworkCore;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

namespace Stoqa.OrderCatalog.ApplicationService.Services.OrderService;

public sealed class OrderSaleQueryService(
    IOrderRepository orderRepository,
    IOrderMapper orderMapper) : IOrderSaleQueryService
{
    public async Task<OrderConferenceResponse> GetByIdAsync(long orderId)
    {
        var order = await orderRepository.FindByPredicateAsync(
            o => o.Id == orderId,
            i => i.Include(po => po.ProductOrders)!);

        return order is not null
            ? orderMapper.DomainToConferenceDtoResponse(order)
            : new OrderConferenceResponse();
    }
}
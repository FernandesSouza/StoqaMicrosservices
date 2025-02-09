using Microsoft.EntityFrameworkCore;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;
using Stoqa.OrderCatalog.Domain.Extensions;
using Stoqa.OrderCatalog.Domain.Interface;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

namespace Stoqa.OrderCatalog.ApplicationService.Services.OrderService;

public sealed class OrderSaleCommandService(
    IOrderRepository orderRepository,
    IOrderMapper orderMapper,
    IOrderInventoryPublisher orderInventoryPublisher,
    INotficationOrderHandler notificationOrderHandler,
    IValidate<Orders> validate)
    : BaseService<Orders>(notificationOrderHandler, validate), IOrderSaleCommandService
{
    private const string EntityName = "Order";

    public async Task<bool> RegisterAsync(OrderSaleRegisterRequest saleRegisterRequest)
    {
        var order = orderMapper.DtoRegisterToDomain(saleRegisterRequest);

        if (!await EntityValidationAsync(order))
            return false;

        return await orderRepository.SaveAsync(order);
    }

    public async Task<bool> UpdateConferenceStatus(long orderId)
    {
        var confirmUpdate = await orderRepository.UpdateAsync(o
            => o.Id == orderId, EOrderStatus.Conference);

        if (confirmUpdate == false)
            return NotificationOrder.CreateNotification(
                "Conference order update",
                EMessage.ErrorConferenceUpdate.GetDescription().FormatTo(EntityName));

        await PublishingOrder(orderId);

        return true;
    }

    private async Task PublishingOrder(long orderId)
    {
        var order = await orderRepository.FindByPredicateAsync(o => o.Id == orderId,
            o => o.Include(s => s.Sale)
                .Include(po => po.ProductOrders)!);

        var message = orderMapper.DomainToDtoResponse(order!);
        await orderInventoryPublisher.PublishOrder(message);
    }
}
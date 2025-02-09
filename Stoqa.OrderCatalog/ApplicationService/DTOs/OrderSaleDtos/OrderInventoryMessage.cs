using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

public sealed class OrderInventoryMessage
{
    public required string Code { get; init; }
    public EOrderStatus Status { get; set; }
    public Sale? Sale { get; init; }
    public List<ProductOrder>? ProductOrders { get; init; }
}
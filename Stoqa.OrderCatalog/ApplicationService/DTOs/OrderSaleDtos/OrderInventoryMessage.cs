using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

public sealed class OrderInventoryMessage
{
    public required string Code { get; init; }
    public List<ProductOrder>? ProductOrders { get; init; }
}
namespace Stoqa.OrderCatalog.ApplicationService.DTOs.ProductOrderDtos;

public sealed record ProductOrderRequestDto
{
    public long OrderId { get; init; }
    public long ProductId { get; init; }
    public int QuantityOrdered { get; init; }
}
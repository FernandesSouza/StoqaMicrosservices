namespace Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos.ResponseDtos;

public sealed record ProductOrderDetailResponse
{
    public long OrderId { get; init; }
    public long ProductId { get; init; }
    public int QuantityOrdered { get; init; }
}
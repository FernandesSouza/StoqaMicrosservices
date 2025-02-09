using Stoqa.OrderCatalog.ApplicationService.DTOs.TransportDtos;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos;

public sealed class SaleRegisterRequest
{
    public required string Invoice { get; init; }
    public required decimal Value { get; init; }
    public required bool Shipping { get; init; }
    public required long OrderId { get; init; }
    public TransportRegisterRequest? Transport { get; init; }
    public long CustomerId { get; init; }
}
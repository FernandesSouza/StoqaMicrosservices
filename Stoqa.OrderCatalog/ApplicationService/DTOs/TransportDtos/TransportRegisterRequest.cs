using Stoqa.Order.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.TransportDtos;

public sealed class TransportRegisterRequest
{
    public required ETransportType TransportType { get; init; }
    public required decimal Freight { get; init; }
    public required string TrackingCode { get; init; }
    public decimal StandardQuote { get; init; }
}
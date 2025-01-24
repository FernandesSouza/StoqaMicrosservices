using Stoqa.Order.Domain.Enums;

namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Transport
{
    public long Id { get; init; }
    public required ETransportType TransportType { get; init; }
    public required decimal Freight { get; init; }
    public required string TrackingCode { get; init; }
    public decimal StandardQuote { get; init; }
}
using Stoqa.Order.Domain.Entities;

namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Sale
{
    public long Id { get; init; }
    public required string Invoice { get; init; }
    public required decimal Value { get; init; }
    public required bool Shipping { get; init; }
    public required long OrderId { get; init; }
    public Transport? Transport { get; init; }
    public required Customer Customer { get; init; }
}   
using Stoqa.Order.Domain.Entities;

namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Return
{
    public long Id { get; init; }
    public required string Description { get; init; }
    public required bool Approved { get; init; }
    public required long OrderId { get; init; }
    public string? Code { get; set; }
    public DateTime CreateDate { get; init; }
    public Transport? Transport { get; init; }
}
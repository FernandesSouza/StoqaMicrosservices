namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class ProductOrder
{
    public long Id { get; init; }
    public long OrderId { get; init; }
    public long ProductId { get; init; }
    public required Product Product { get; init; }
}
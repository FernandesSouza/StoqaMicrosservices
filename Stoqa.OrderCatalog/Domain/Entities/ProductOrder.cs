namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class ProductOrder
{
    public long Id { get; init; }
    public long OrderId { get; init; }
    public required long ProductId { get; init; }
    public Product Product { get; init; }
    
    public int QuantityOrdered { get; init; }
}   
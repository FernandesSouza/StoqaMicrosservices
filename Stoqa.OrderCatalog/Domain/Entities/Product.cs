namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Product
{
    public long Id { get; init; }
    public decimal Price { get; init; }
    public required string Name { get; init; }
    public string? Code { get; init; }
}
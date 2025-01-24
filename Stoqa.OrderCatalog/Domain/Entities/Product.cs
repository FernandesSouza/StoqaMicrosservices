namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Product
{
    public long Id { get; init; }
    public decimal Price { get; init; }
    public required List<PackagingComposition> PackingCompositions { get; init; }
    public DateTime CreateDate { get; init; }
    public required string Name { get; init; }
    public bool Active { get; init; }
    public required string Description { get; init; }
    public string? Code { get; init; }
}
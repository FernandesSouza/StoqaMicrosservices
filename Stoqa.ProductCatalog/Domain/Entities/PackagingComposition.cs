using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.Domain.Entities;
public sealed class PackagingComposition
{
    public long Id { get; init; }
    public int Level { get; init; }
    public int Quantity { get; init; }
    public long ProductId { get; init; }
    public EKindPacking Packing { get; init; }
}
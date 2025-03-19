using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.Domain.Entities;

public sealed class Item
{
    public long Id { get; init; }
    public required string SerialCode { get; init; }
    public required long ProductId { get; init; }
    public DateTime CreateDate { get; init; }
    public EStatusItem StatusItem { get; init; }
    public Product Product { get; init; }
}
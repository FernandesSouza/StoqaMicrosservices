using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.Domain.Entities;

public sealed class Item
{
    public long Id { get; init; }
    public required string SerialCode { get; init; }
    public DateTime CreateDate { get; init; }
    public EStatusItem StatusItem { get; set; }
    public required long ProductId { get; init; }
    public required long StockItemId { get; set; }
    public long? OrderId { get; set; }
    public Product? Product { get; init; }
    public StockItem? StockItem { get; set; }
}
namespace Stoqa.ProductCatalog.Domain.Entities;

public sealed class StockItem
{
    public long Id { get; init; }
    public required long ProductId { get; init; }
    public int Quantity { get; init; }
    public int QuantityReserved { get; set; }
    public long DepositId { get; set; }
    public Product Product { get; init; }
    public Deposit Deposit { get; init; }
}
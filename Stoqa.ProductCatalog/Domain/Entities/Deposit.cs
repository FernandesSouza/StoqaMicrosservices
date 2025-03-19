namespace Stoqa.ProductCatalog.Domain.Entities;

public sealed class Deposit
{
    public long Id { get; init; }
    public required string DepositName { get; set; }
    public required string Identifier { get; init; }
    public bool Active { get; set; }
    public List<StockItem> StockItems { get; init; } = [];
}
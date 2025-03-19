namespace Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;

public sealed class StockItemRegisterRequest
{
    public required long ProductId { get; init; }
    public int Quantity { get; init; }
    public long DepositId { get; set; }
}
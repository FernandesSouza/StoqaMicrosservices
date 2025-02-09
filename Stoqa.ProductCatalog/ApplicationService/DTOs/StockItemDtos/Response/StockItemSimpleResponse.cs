namespace Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;

public sealed class StockItemSimpleResponse
{
    public required long ProductId { get; init; }
    public int Quantity { get; init; }
}
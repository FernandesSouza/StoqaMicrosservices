namespace Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;

public sealed record ItemRegisterRequest
{
    public required string SerialCode { get; init; }
    public required long ProductId { get; init; }
    public DateTime CreateDate { get; init; }
    public long StockItemId { get; set; }
}
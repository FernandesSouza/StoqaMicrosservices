namespace Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;

public sealed record ItemValidateRequest
{
    public required string SerialCode { get; init; }
    public long OrderId { get; init; }
}
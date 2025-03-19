using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;

public sealed record ItemRegisterRequest
{
    public required string SerialCode { get; init; }
    public required long ProductId { get; init; }
    public DateTime CreateDate { get; init; }
    public EStatusItem StatusItem { get; init; }
}
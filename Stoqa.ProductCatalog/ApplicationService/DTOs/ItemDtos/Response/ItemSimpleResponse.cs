using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;

public class ItemSimpleResponse
{
    public required string SerialCode { get; init; }
    public EStatusItem StatusItem { get; set; }
}
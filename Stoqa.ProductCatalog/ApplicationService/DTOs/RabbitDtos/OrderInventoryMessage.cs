namespace Stoqa.ProductCatalog.ApplicationService.DTOs.RabbitDtos;

public sealed class OrderInventoryMessage
{
    public required string Code { get; init; }
    public List<string>? ProductOrders { get; init; }
}
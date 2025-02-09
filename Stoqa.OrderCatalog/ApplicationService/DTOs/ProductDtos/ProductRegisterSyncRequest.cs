namespace Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;

public sealed class ProductRegisterSyncRequest
{
    public long Id { get; init; }
    public decimal Price { get; init; }
    public DateTime CreateDate { get; init; }
    public required string Name { get; init; }
    public bool Active { get; init; }
    public required string Description { get; init; }
    public string? Code { get; init; }
}
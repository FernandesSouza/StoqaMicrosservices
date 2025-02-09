namespace Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;

public sealed class ProductRegisterRequestDto
{
    public decimal Price { get; init; }
    public DateTime CreateDate { get; init; }
    public required string Name { get; init; }
    public bool Active { get; init; }
    public required string Description { get; init; }
    public string? Code { get; init; }
}
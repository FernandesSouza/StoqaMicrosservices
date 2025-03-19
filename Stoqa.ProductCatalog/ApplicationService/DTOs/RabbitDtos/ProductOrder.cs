using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.DTOs.RabbitDtos;

public sealed record ProductOrder
{
    public long Id { get; init; }
    public long OrderId { get; init; }
    public required long ProductId { get; init; }
    public Product Product { get; init; }
    
    public int QuantityOrdered { get; init; }
}
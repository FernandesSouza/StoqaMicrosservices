using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;

public sealed record ProductEventDto
{
    public EProductTypeEvent ProductTypeEvent { get; init; }
    public long? ProductId { get; init; }
    public Product? Product { get; init; }
}
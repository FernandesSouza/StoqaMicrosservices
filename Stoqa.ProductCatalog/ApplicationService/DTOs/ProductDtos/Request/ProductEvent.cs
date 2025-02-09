using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;

public sealed class ProductEvent
{
    public EProductTypeEvent ProductTypeEvent { get; set; }
    public required Product Product { get; set; }
}
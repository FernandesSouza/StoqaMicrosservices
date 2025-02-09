using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Response;

public sealed class PackagingCompositionSimpleResponse
{
    public int Level { get; init; }
    public int Quantity { get; init; }
    public EKindPacking Packing { get; init; }
}
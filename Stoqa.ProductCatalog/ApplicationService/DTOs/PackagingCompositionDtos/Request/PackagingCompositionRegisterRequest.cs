using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;

public sealed class PackagingCompositionRegisterRequest
{
    public int Level { get; init; }
    public int Quantity { get; init; }
    public long ProductId { get; init; }
    public EKindPacking Packing { get; init; }
}
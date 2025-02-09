using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos;
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Mappers;

public sealed class PackagingCompositionMapper : IPackagingCompositionMapper
{
    public PackagingComposition DtoRegisterToDomain(
        PackagingCompositionRegisterRequest packagingCompositionRegisterRequest) =>
        new()
        {
            Level = packagingCompositionRegisterRequest.Level,
            Quantity = packagingCompositionRegisterRequest.Quantity,
            ProductId = packagingCompositionRegisterRequest.ProductId,
            Packing = packagingCompositionRegisterRequest.Packing
        };
}
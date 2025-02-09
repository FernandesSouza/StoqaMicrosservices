using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos;
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IPackagingCompositionMapper
{
    PackagingComposition DtoRegisterToDomain(PackagingCompositionRegisterRequest packagingCompositionRegisterRequest);
}
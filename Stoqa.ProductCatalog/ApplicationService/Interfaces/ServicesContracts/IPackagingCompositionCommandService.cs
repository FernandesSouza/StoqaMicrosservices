using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos;
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IPackagingCompositionCommandService
{
    Task<bool> RegisterAsync(PackagingCompositionRegisterRequest packagingCompositionRegisterRequest);
}
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.PackagingCompositionServices;

public class PackagingCompositionCommandService(
    IPackagingCompositionRepository packagingCompositionRepository,
    IPackagingCompositionMapper packagingCompositionMapper)
    : IPackagingCompositionCommandService
{
    public Task<bool> RegisterAsync(PackagingCompositionRegisterRequest packagingCompositionRegisterRequest)
    {
        var packaging = packagingCompositionMapper.DtoRegisterToDomain(packagingCompositionRegisterRequest);

        return packagingCompositionRepository.SaveAsync(packaging);
    }
}
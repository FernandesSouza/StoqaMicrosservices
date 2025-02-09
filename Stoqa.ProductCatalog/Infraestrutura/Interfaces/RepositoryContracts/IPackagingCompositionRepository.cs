using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IPackagingCompositionRepository
{
    Task<bool> SaveAsync(PackagingComposition packagingComposition);
}
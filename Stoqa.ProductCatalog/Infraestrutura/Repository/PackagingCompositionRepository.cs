using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository;

public sealed class PackagingCompositionRepository(
    ApplicationContext applicationContext
) : BaseRepository<PackagingComposition>(applicationContext), IPackagingCompositionRepository
{
    public async Task<bool> SaveAsync(PackagingComposition packagingComposition)
    {
        await DbSetContext.AddAsync(packagingComposition);
        return await SaveInDataBaseAsync();
    }
}
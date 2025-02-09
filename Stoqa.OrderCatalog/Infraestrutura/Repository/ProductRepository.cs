using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using Stoqa.OrderCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.Repository;

public sealed class ProductRepository(
    ApplicationContext context
) : BaseRepository<Product>(context), IProductRepository
{

    public async Task<bool> SaveAsync(Product product)
    {
        await DbSetContext.AddAsync(product);
        return await SaveInDatabaseAsync();
    }
}
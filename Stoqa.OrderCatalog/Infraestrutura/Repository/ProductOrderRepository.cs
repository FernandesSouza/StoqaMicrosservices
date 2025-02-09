using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using Stoqa.OrderCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.Repository;

public sealed class ProductOrderRepository(
    ApplicationContext context
) : BaseRepository<ProductOrder>(context), IProductOrderRepository
{
    public async Task<bool> SaveAsync(ProductOrder productOrder)
    {
        await DbSetContext.AddAsync(productOrder);
        return await SaveInDatabaseAsync();
    }
}
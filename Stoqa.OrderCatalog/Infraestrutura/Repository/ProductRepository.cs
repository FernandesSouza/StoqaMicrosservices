using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using Stoqa.OrderCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.Repository;

public sealed class ProductRepository(
    ApplicationContext context
) : BaseRepository<Product>(context), IProductRepository
{
    private const int StandardQuantity = 1;

    public async Task<bool> SaveAsync(Product product)
    {
        await DbSetContext.AddAsync(product);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        DbSetContext.Update(product);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> predicate) =>
        await DbSetContext.Where(predicate).ExecuteDeleteAsync() >= StandardQuantity;
}
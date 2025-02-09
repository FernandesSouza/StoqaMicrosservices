using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository;

public sealed class ProductRepository(
    ApplicationContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<bool> SaveAsync(Product product)
    {
        await DbSetContext.AddAsync(product);
        return await SaveInDataBaseAsync();
    }

    public async Task<List<Product>> FindAllAsync(
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        IQueryable<Product> query = DbSetContext;

        if (include is not null)
            query = include(query);

        return await query.ToListAsync();
    }
}
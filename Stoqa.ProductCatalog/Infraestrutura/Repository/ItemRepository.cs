using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository;

public sealed class ItemRepository(
    ApplicationContext dbContext
) : BaseRepository<Item>(dbContext), IItemRepository
{
    public async Task<bool> SaveAsync(Item item)
    {
        await DbSetContext.AddAsync(item);
        return await SaveInDataBaseAsync();
    }

    public async Task<List<Item>> FindAllAsync()
    {
        IQueryable<Item> query = DbSetContext;

        return await query.ToListAsync();
    }
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.PaginationHandler;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.ServiceContracts;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository;

public sealed class StockItemRepository(
    ApplicationContext context,
    IPaginationQueryService<StockItem> paginationQueryService)
    : BaseRepository<StockItem>(context), IStockItemRepository
{
    private const int StandardQuantity = 0;
    public async Task<bool> SaveAsync(StockItem stockItem)
    {
        await DbSetContext.AddAsync(stockItem);
        return await SaveInDataBaseAsync();
    }

    public async Task<bool> UpdateAsync(
        Expression<Func<StockItem, bool>> predicate,
        int quantity)
    {
        var result = await DbSetContext.Where(predicate)
            .ExecuteUpdateAsync(setter => setter.SetProperty(o => o.QuantityReserved, quantity)) >= StandardQuantity;

        return result;
    }

    public async Task<StockItem?> FindByPredicate(Expression<Func<StockItem, bool>> predicate,
        Func<IQueryable<StockItem>, IIncludableQueryable<StockItem, object>>? include = null)
    {
        IQueryable<StockItem> query = DbSetContext;

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<PageList<StockItem>> FindAllWithPagination(
        PageParams pageParams,
        Expression<Func<StockItem, bool>>? predicate,
        Func<IQueryable<StockItem>, IIncludableQueryable<StockItem, object>>? include = null)
    {
        IQueryable<StockItem> query = DbSetContext;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        return await paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }
}
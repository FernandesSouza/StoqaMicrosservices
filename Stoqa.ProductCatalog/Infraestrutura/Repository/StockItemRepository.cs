using System.Linq.Expressions;
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
    public async Task<bool> SaveAsync(StockItem stockItem)
    {
        await DbSetContext.AddAsync(stockItem);
        return await SaveInDataBaseAsync();
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
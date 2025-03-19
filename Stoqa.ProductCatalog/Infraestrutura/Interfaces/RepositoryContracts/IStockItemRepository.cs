using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.PaginationHandler;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IStockItemRepository
{
    Task<bool> SaveAsync(StockItem stockItem);
    Task<bool> UpdateAsync(Expression<Func<StockItem, bool>> predicate, int quantity);
    Task<StockItem?> FindByPredicate(
        Expression<Func<StockItem, bool>> predicate,
        Func<IQueryable<StockItem>, IIncludableQueryable<StockItem, object>>? include = null);
    Task<PageList<StockItem>> FindAllWithPagination(
        PageParams pageParams,
        Expression<Func<StockItem, bool>>? predicate,
        Func<IQueryable<StockItem>, IIncludableQueryable<StockItem, object>>? include = null);
}
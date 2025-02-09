using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.PaginationHandler;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IStockItemRepository
{
    Task<bool> SaveAsync(StockItem stockItem);

    Task<PageList<StockItem>> FindAllWithPagination(
        PageParams pageParams,
        Expression<Func<StockItem, bool>>? predicate,
        Func<IQueryable<StockItem>, IIncludableQueryable<StockItem, object>>? include = null);
}
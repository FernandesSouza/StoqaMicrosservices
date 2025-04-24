using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;
using Stoqa.ProductCatalog.Domain.PaginationHandler;
using Stoqa.ProductCatalog.Domain.PaginationHandler.Params;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IStockItemQueryService
{
    Task<PageList<StockItemSimpleResponse>> FindAllWithPaginationAsync(StockItemParams stockItemParams);
}
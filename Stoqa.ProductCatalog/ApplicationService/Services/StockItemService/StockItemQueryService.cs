using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.PaginationHandler;
using Stoqa.ProductCatalog.Domain.PaginationHandler.Params;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.StockItemService;

public sealed class StockItemQueryService(
    IStockItemRepository stockItemRepository,
    IStockItemMapper stockItemMapper) : IStockItemQueryService
{
    public async Task<PageList<StockItemSimpleResponse>> FindAllWithPaginationAsync(StockItemParams stockItemParams)
    {
        var stockItem = await stockItemRepository.FindAllWithPagination(
            stockItemParams,
            st => st.Quantity > 0,
            i => i.Include(it => it.Items));

        return stockItem.Items.Count > 0
            ? stockItemMapper.DomainToPaginationResponse(stockItem)
            : new PageList<StockItemSimpleResponse>();
    }
}
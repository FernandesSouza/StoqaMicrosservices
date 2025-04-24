using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.PaginationHandler;

namespace Stoqa.ProductCatalog.ApplicationService.Mappers;

public sealed class StockItemMapper : IStockItemMapper
{
    public StockItem DtoRequestToDomain(StockItemRegisterRequest stockItemRegisterRequest) =>
        new()
        {
            ProductId = stockItemRegisterRequest.ProductId,
            Quantity = stockItemRegisterRequest.Quantity,
            DepositId = stockItemRegisterRequest.DepositId
        };

    public PageList<StockItemSimpleResponse> DomainToPaginationResponse(PageList<StockItem> stockItems)
    {
        var items = stockItems.Items.Select(SimpleStockItemResponse).ToList();

        return new PageList<StockItemSimpleResponse>(
            items,
            stockItems.TotalCount,
            stockItems.CurrentPage,
            stockItems.PageSize);
    }

    private StockItemSimpleResponse SimpleStockItemResponse(StockItem stockItem) =>
        new()
        {
            ProductId = stockItem.ProductId,
            Quantity = stockItem.Quantity
        };
}
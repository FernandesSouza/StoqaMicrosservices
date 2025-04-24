using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.PaginationHandler;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IStockItemMapper
{
    StockItem DtoRequestToDomain(StockItemRegisterRequest stockItemRegisterRequest);
    PageList<StockItemSimpleResponse> DomainToPaginationResponse(PageList<StockItem> stockItems);
}
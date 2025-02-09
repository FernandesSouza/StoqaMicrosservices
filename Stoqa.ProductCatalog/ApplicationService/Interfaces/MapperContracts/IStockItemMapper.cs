using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IStockItemMapper
{
    StockItem DtoRequestToDomain(StockItemRegisterRequest stockItemRegisterRequest);
}
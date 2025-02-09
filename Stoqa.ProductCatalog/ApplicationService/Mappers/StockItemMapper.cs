using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;

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

}
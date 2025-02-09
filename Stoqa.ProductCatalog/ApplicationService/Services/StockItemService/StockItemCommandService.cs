using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.StockItemService;

public sealed class StockItemCommandService(
    IStockItemRepository stockItemRepository,
    IStockItemMapper stockItemMapper) : IStockItemCommandService
{
    public Task<bool> RegisterAsync(StockItemRegisterRequest stockItemRegisterRequest)
    {
        var stockItem = stockItemMapper.DtoRequestToDomain(stockItemRegisterRequest);
        return stockItemRepository.SaveAsync(stockItem);
    }
}
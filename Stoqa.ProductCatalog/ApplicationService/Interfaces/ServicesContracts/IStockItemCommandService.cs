using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IStockItemCommandService
{
    Task<bool> RegisterAsync(StockItemRegisterRequest stockItemRegisterRequest);
}
namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IStockItemFacadeCommandService
{
    Task<bool> UpdateStockReservedAsync(long stockItemId, int quantity);
}
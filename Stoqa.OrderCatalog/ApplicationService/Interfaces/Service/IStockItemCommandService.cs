namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IStockItemCommandService
{
    Task<bool> ConcurrenceStockItemValidateAsync(string serialCode, long orderId);
}
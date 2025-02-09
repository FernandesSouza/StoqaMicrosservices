using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

public interface IProductCommandSyncService
{
    Task<bool> RegisterAsync(ProductRegisterSyncRequest registerSyncRequest);
}
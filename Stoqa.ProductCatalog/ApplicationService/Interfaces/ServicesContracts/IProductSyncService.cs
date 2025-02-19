using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IProductSyncService
{
    Task SyncToProductAsync(Product product);
}
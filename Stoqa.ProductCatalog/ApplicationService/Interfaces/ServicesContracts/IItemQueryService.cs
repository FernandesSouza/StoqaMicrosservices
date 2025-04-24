using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IItemQueryService
{
    Task<List<ItemSimpleResponse>> FindAllAsync();
}
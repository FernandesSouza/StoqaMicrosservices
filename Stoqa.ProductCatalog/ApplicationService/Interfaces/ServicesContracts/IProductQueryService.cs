using Stoqa.ProductCatalog.ApplicationService.DTOs.ProductDtos.Response;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IProductQueryService
{
    Task<List<ProductSimpleResponse>> FindAllAsync();
}
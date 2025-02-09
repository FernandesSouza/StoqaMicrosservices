using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IProductCommandService
{
    Task<bool> RegisterAsync(ProductRegisterRequestDto productRegister);
}
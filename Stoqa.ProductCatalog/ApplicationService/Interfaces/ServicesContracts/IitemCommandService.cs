using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IItemCommandService
{
    Task<bool> RegisterAsync(ItemRegisterRequest itemRegisterRequest);
}
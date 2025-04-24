using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IItemCommandService
{
    Task<bool> RegisterAsync(ItemRegisterRequest itemRegisterRequest);
    Task<bool> ConcurrenceItemValidateAsync(ItemValidateRequest validate);
}
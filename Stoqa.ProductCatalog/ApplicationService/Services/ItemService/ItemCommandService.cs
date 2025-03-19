using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ItemService;

public sealed class ItemCommandService(
    INotficationHandler notificationHandler,
    IValidate<Item> validate,
    IItemMapper itemMapper,
    IItemRepository itemRepository)
    : BaseService<Item>(notificationHandler, validate), IItemCommandService
{
    public async Task<bool> RegisterAsync(ItemRegisterRequest itemRegisterRequest)
    {
        var domain = itemMapper.DtoToDomain(itemRegisterRequest);

        if (!await EntityValidationAsync(domain))
            return false;

        return await itemRepository.SaveAsync(domain);
    }
}
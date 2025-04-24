using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ItemService;

public sealed class ItemQueryService(
    IItemRepository itemRepository,
        IItemMapper itemMapper) : IItemQueryService
{
    public async Task<List<ItemSimpleResponse>> FindAllAsync()
    {
        var items = await itemRepository.FindAllAsync();

        return items.Count > 0
            ? itemMapper.DomainToSimpleResponse(items)
            : [];
    }
}
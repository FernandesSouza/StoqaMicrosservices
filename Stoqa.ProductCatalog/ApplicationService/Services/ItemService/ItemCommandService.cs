using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Extensions;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ItemService;

public sealed class ItemCommandService(
    INotficationHandler notificationHandler,
    IValidate<Item> validate,
    IItemMapper itemMapper,
    IItemRepository itemRepository,
    IStockItemFacadeCommandService stockItemFacadeCommandService)
    : BaseService<Item>(notificationHandler, validate), IItemCommandService
{
    private const string EntityName = "Item";

    public async Task<bool> RegisterAsync(ItemRegisterRequest itemRegisterRequest)
    {
        var domain = itemMapper.DtoToDomain(itemRegisterRequest);

        if (!await EntityValidationAsync(domain))
            return false;

        return await itemRepository.SaveAsync(domain);
    }

    public async Task<bool> ConcurrenceItemValidateAsync(ItemValidateRequest validate)
    {
        var item = await itemRepository.FindByPredicateAsync(
            i => i.SerialCode == validate.SerialCode);

        if (item is not null)
            return Notification.CreateNotification(
                "Item Validate",
                EMessage.ItemNotFound.GetDescription().FormatTo(EntityName));

        if (item!.OrderId is not null)
            return Notification.CreateNotification(
                "Item Validate",
                EMessage.ItemFoundOrder.GetDescription().FormatTo(EntityName));

        if (item.StatusItem == EStatusItem.Sold)
            return Notification.CreateNotification(
                "Item Validate",
                EMessage.ItemInvalidStatus.GetDescription().FormatTo(EntityName));

        item.StatusItem = EStatusItem.InConference;
        await itemRepository.UpdateAsync(item);

        return await stockItemFacadeCommandService.UpdateStockReservedAsync(item.StockItemId, -1);
    }
}
using System.Text;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Extensions;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.StockItemService;

public sealed class StockItemCommandService(
    IStockItemRepository stockItemRepository,
    INotficationHandler notificationHandler,
    IValidate<StockItem> validate,
    IStockItemMapper stockItemMapper)
    : BaseService<StockItem>(notificationHandler, validate), IStockItemCommandService
{
    public async Task<bool> RegisterAsync(StockItemRegisterRequest stockItemRegisterRequest)
    {
        var stockItem = stockItemMapper.DtoRequestToDomain(stockItemRegisterRequest);

        if (!await EntityValidationAsync(stockItem))
            return false;

        return await stockItemRepository.SaveAsync(stockItem);
    }

    public async Task<bool> ConcurrenceStockItemValidateAsync(string serialCode, long orderId)
    {
        //TODO: MUDANÇA NA IMPLEMENTAÇÃO, NÃO VAI USAR REDIS

        // var cacheItem = await cacheService.GetAsync(serialCode);
        //
        // if (cacheItem is not null)
        //     return Notification.CreateNotification(
        //         "Stock Item Validate",
        //         EMessage.ItemFound.GetDescription().FormatTo(EntityName));
        //
        // if (cacheItem!.OrderId == orderId)
        //     return Notification.CreateNotification(
        //         "Stock Item Validate",
        //         EMessage.ItemFoundOrder.GetDescription().FormatTo(EntityName));
        //
        // var valueToCache = Encoding.UTF8.GetBytes(serialCode);
        //
        // await cacheService.SetAsync(orderId.ToString(), valueToCache);
        // return true;

        return true;
    }
}
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
    : BaseService<StockItem>(notificationHandler, validate), IStockItemCommandService, IStockItemFacadeCommandService
{
    private const string EntityName = "StockItem";

    public async Task<bool> RegisterAsync(StockItemRegisterRequest stockItemRegisterRequest)
    {
        var stockItem = stockItemMapper.DtoRequestToDomain(stockItemRegisterRequest);

        if (!await EntityValidationAsync(stockItem))
            return false;

        return await stockItemRepository.SaveAsync(stockItem);
    }

    public async Task<bool> UpdateStockReservedAsync(long stockItemId, int quantity)
    {
        if (!await stockItemRepository.ExistAsync(c => c.Id == stockItemId))
            return Notification.CreateNotification(
                "Update stock reserved",
                EMessage.ItemNotFound.GetDescription().FormatTo(EntityName));

        return await stockItemRepository.UpdateReservedAsync(st => st.Id == stockItemId, quantity);
    }
}
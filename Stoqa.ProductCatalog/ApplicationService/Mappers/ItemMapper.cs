using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;

namespace Stoqa.ProductCatalog.ApplicationService.Mappers;

public sealed class ItemMapper : IItemMapper
{
    public Item DtoToDomain(ItemRegisterRequest registerRequest) =>
        new()
        {
            SerialCode = registerRequest.SerialCode,
            ProductId = registerRequest.ProductId,
            StatusItem = EStatusItem.InStock,
            CreateDate = registerRequest.CreateDate,
            StockItemId = registerRequest.StockItemId
        };

    public List<ItemSimpleResponse> DomainToSimpleResponse(List<Item> items) =>
        items.Select(SimpleToListDomain).ToList();

    private ItemSimpleResponse SimpleToListDomain(Item item) =>
        new()
        {
            SerialCode = item.SerialCode,
            StatusItem = item.StatusItem
        };
}
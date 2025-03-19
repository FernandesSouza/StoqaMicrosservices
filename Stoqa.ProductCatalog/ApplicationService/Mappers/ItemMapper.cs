using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;
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
            CreateDate = registerRequest.CreateDate
        };
}
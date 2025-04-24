using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IItemMapper
{
    Item DtoToDomain(ItemRegisterRequest registerRequest);
    List<ItemSimpleResponse> DomainToSimpleResponse(List<Item> items);
}
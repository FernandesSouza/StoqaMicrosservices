using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IItemMapper
{
    Item DtoToDomain(ItemRegisterRequest registerRequest);
}
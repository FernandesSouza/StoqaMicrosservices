using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.ApplicationService.Mappers;

public sealed class ProductMapper : IProductMapper
{
    public Product DtoRegisterToDomain(ProductRegisterSyncRequest productRegisterSyncRequest) =>
        new()
        {
            Price = productRegisterSyncRequest.Price,
            Name = productRegisterSyncRequest.Name,
            Active = productRegisterSyncRequest.Active,
            Description = productRegisterSyncRequest.Description,
            Code = productRegisterSyncRequest.Code
        };

}
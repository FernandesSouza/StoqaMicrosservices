using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;

public interface IProductMapper
{
    Product DtoRegisterToDomain(ProductRegisterSyncRequest productRegisterSyncRequest);
}
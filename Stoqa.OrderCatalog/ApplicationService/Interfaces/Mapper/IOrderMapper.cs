using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;

public interface IOrderMapper
{
    Orders DtoRegisterToDomain(OrderSaleRegisterRequest orderSaleRegisterRequest);
    OrderInventoryMessage DomainToDtoResponse(Orders order);
    OrderConferenceResponse DomainToConferenceDtoResponse(Orders order);
}
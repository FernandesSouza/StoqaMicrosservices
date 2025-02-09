using Stoqa.Order.Domain.Enums;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.TransportDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.Mappers;

public sealed class OrderMapper : IOrderMapper
{
    public Orders DtoRegisterToDomain(OrderSaleRegisterRequest orderSaleRegisterRequest) =>
        new()
        {
            Code = orderSaleRegisterRequest.Code,
            Status = EOrderStatus.Created,
            Sale = DtoRegisterToSaleDomain(orderSaleRegisterRequest.Sale!),
            ProductOrders = null,
            CreateDate = default
        };

    public OrderInventoryMessage DomainToDtoResponse(Orders order) =>
        new()
        {
            Code = order.Code,
            Status = order.Status,
            Sale = order.Sale,
            ProductOrders = order.ProductOrders,
        };

    //TODO: SEPARAR RESPONSABILIDADE, CRIAR RESPECTIVOS MAPPERS PRA ESSES CARAS
    private Sale DtoRegisterToSaleDomain(SaleRegisterRequest saleRegisterRequest) =>
        new()
        {
            Invoice = saleRegisterRequest.Invoice,
            Value = saleRegisterRequest.Value,
            Shipping = saleRegisterRequest.Shipping,
            OrderId = saleRegisterRequest.OrderId,
            Transport = DtoRegisterToTransportDomain(saleRegisterRequest.Transport!),
            CustomerId = saleRegisterRequest.CustomerId
        };


    private Transport DtoRegisterToTransportDomain(TransportRegisterRequest transportRegisterRequest) =>
        new()
        {
            TransportType = transportRegisterRequest.TransportType,
            Freight = transportRegisterRequest.Freight,
            TrackingCode = transportRegisterRequest.TrackingCode,
            StandardQuote = transportRegisterRequest.StandardQuote
        };
}
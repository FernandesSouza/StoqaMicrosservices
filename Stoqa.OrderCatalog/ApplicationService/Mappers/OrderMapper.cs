using Stoqa.Order.Domain.Enums;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductOrderDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos.RequestDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos.ResponseDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.TransportDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.Mappers;

//TODO: SEPARAR RESPONSABILIDADE, CRIAR RESPECTIVOS MAPPERS PRA ESSES CARAS
public sealed class OrderMapper : IOrderMapper
{
    public Orders DtoRegisterToDomain(OrderSaleRegisterRequest orderSaleRegisterRequest) =>
        new()
        {
            Code = orderSaleRegisterRequest.Code,
            Status = EOrderStatus.Created,
            Sale = DtoRegisterToSaleDomain(orderSaleRegisterRequest.Sale!),
            ProductOrders = DtoRegisterToDomain(orderSaleRegisterRequest.ProductOrderRequestDto),
            CreateDate = orderSaleRegisterRequest.CreateDate
        };

    public OrderInventoryMessage DomainToDtoResponse(Orders order) =>
        new()
        {
            Code = order.Code,
            ProductOrders = order.ProductOrders
        };

    public OrderConferenceResponse DomainToConferenceDtoResponse(Orders order) =>
        new()
        {
            Id = order.Id,
            Code = order.Code,
            Status = order.Status,
            ProductOrders = DomainToDtoProductOrderDetail(order.ProductOrders!),
            CreateDate = default,
        };

    private List<ProductOrderDetailResponse> DomainToDtoProductOrderDetail(List<ProductOrder> productOrderDetail) =>
        productOrderDetail.Select(SimpleDomainToProductOrderDetail).ToList();

    private ProductOrderDetailResponse SimpleDomainToProductOrderDetail(ProductOrder productOrderDetail) =>
        new()
        {
            OrderId = productOrderDetail.OrderId,
            ProductId = productOrderDetail.ProductId,
            QuantityOrdered = productOrderDetail.QuantityOrdered
        };

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

    private List<ProductOrder> DtoRegisterToDomain(List<ProductOrderRequestDto> productOrderRequestDtos) =>
        productOrderRequestDtos.Select(SingleToDomain).ToList();

    private ProductOrder SingleToDomain(ProductOrderRequestDto productOrderRequestDto) =>
        new()
        {
            OrderId = productOrderRequestDto.OrderId,
            ProductId = productOrderRequestDto.ProductId,
            QuantityOrdered = productOrderRequestDto.QuantityOrdered
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
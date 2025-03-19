using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductOrderDtos;
using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos.RequestDtos;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

public sealed class OrderSaleRegisterRequest
{
    public required string Code { get; init; }
    public EOrderStatus Status { get; set; }
    public SaleRegisterRequest? Sale { get; init; }
    public required List<ProductOrderRequestDto> ProductOrderRequestDto { get; init; }
    public DateTime CreateDate { get; init; }
}
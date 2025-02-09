using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

public sealed class OrderSaleRegisterRequest
{
    public required string Code { get; init; }
    public EOrderStatus Status { get; set; }
    public SaleRegisterRequest? Sale { get; init; }
    public DateTime CreateDate { get; init; }
}
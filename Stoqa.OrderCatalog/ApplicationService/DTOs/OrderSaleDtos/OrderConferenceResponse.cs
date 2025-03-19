using Stoqa.OrderCatalog.ApplicationService.DTOs.SaleDtos.ResponseDtos;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;

public sealed record OrderConferenceResponse
{
    public long Id { get; init; }
    public string? Code { get; init; }
    public EOrderStatus Status { get; set; }
    public List<ProductOrderDetailResponse>? ProductOrders { get; init; }
    public DateTime CreateDate { get; init; }
}
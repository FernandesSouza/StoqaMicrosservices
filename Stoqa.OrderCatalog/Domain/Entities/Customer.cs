using Stoqa.Order.Domain.Entities;
using Stoqa.Order.Domain.Enums;

namespace Stoqa.OrderCatalog.Domain.Entities;

public sealed class Customer
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Document { get; init; }
    public DateTime CreateDate { get; init; }
    public required ECustomerType CustomerType { get; init; }
    public required long AddressId { get; set; }
    public required Address Address { get; init; }
}
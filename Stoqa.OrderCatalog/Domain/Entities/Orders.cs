namespace Stoqa.OrderCatalog.Domain.Entities;

public class Orders
{
    public long Id { get; init; }
    public required string Code { get; init; }
    public Sale? Sale { get; init; }
    public Return? Return { get; init; }
    public List<ProductOrder>? ProductOrders { get; init; }
    public DateTime CreateDate { get; init; }
}
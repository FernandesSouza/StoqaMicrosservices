using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

public interface IProductOrderRepository
{
    Task<bool> SaveAsync(ProductOrder productOrder);
}
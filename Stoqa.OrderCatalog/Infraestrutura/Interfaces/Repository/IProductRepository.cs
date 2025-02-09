using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

public interface IProductRepository
{
    Task<bool> SaveAsync(Product product);
}
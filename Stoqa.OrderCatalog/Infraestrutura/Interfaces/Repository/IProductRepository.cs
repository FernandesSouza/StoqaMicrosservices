using System.Linq.Expressions;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

public interface IProductRepository
{
    Task<bool> SaveAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Expression<Func<Product, bool>> predicate);
}
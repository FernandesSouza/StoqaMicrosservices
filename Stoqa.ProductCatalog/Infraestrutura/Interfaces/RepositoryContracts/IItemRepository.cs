using System.Linq.Expressions;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IItemRepository
{
    Task<bool> SaveAsync(Item item);
    Task<bool> UpdateAsync(Item item);
    Task<List<Item>> FindAllAsync();
    Task<bool> ExistsAsync(Expression<Func<Item, bool>> predicate);
    Task<Item?> FindByPredicateAsync(Expression<Func<Item, bool>> predicate);
}
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IItemRepository
{
    Task<bool> SaveAsync(Item item);
    Task<List<Item>> FindAllAsync();
}
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IProductRepository : IDisposable
{
    Task<bool> SaveAsync(Product product);
    Task<List<Product>> FindAllAsync(Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);
}
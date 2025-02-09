using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

public interface IDepositRepository
{
    Task<bool> SaveAsync(Deposit deposit);
    Task<Deposit?> FindByIdAsync(Expression<Func<Deposit, bool>> predicate,
        Func<IQueryable<Deposit>, IIncludableQueryable<Deposit, object>>? include = null,
        bool toQuery = false);
}
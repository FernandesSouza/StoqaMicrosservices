using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;
using Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository;

public sealed class DepositRepository(
    ApplicationContext context
) : BaseRepository<Deposit>(context), IDepositRepository
{
    public async Task<bool> SaveAsync(Deposit deposit)
    {
        await DbSetContext.AddAsync(deposit);
        return await SaveInDataBaseAsync();
    }

    public async Task<Deposit?> FindByPredicateAsync(
        Expression<Func<Deposit, bool>> predicate,
        Func<IQueryable<Deposit>, IIncludableQueryable<Deposit, object>>? include = null,
        bool toQuery = false)
    {
        IQueryable<Deposit> query = DbSetContext;

        if (toQuery)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }
}
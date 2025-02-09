using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using Stoqa.OrderCatalog.Infraestrutura.Repository.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.Repository;

public sealed class OrderRepository(
    ApplicationContext context
) : BaseRepository<Orders>(context), IOrderRepository
{
    private const int StandardQuantity = 0;

    public async Task<bool> SaveAsync(Orders order)
    {
        await DbSetContext.AddAsync(order);
        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Expression<Func<Orders, bool>> predicate, EOrderStatus status)
    {
        var resul = await DbSetContext.Where(predicate)
            .ExecuteUpdateAsync(setter => setter.SetProperty(o => o.Status, status)) >= StandardQuantity;

        return resul;
    }

    public async Task<Orders?> FindByPredicateAsync(
        Expression<Func<Orders, bool>> predicate,
        Func<IQueryable<Orders>, IIncludableQueryable<Orders, object>>? include = null,
        bool toQuery = false)
    {
        IQueryable<Orders> query = DbSetContext;

        if (toQuery)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }
}
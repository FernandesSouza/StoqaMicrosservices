using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

public interface IOrderRepository
{
    Task<bool> SaveAsync(Orders order);
    Task<bool> UpdateAsync(Expression<Func<Orders, bool>> predicate, EOrderStatus status);

    Task<Orders?> FindByPredicateAsync(Expression<Func<Orders, bool>> predicate,
        Func<IQueryable<Orders>, IIncludableQueryable<Orders, object>>? include = null, bool toQuery = false);
}
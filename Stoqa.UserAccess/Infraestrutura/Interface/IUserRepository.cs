using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.Identity.Domain.Entities;

namespace Stoqa.Identity.Infraestrutura.Interface;

public interface IUserRepository
{
    Task<IdentityResult> SaveAsync(User user);
    Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool toQuery = false);
    Task<bool> ExistAsync(Expression<Func<User, bool>> predicate);

    Task<string> PasswordHashAsync(string password);
}
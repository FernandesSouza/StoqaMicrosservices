using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.Interface;
using Stoqa.Identity.Infraestrutura.ORM;

namespace Stoqa.Identity.Infraestrutura.Repository;

public sealed class UserRepository(
    IdentityContext context,
    UserManager<User> userManager
) : IUserRepository
{
    private DbSet<User> DbSetContext => context.Set<User>();

    public async Task<IdentityResult> SaveAsync(User user) =>
        await userManager.CreateAsync(user);

    public async Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool toQuery = false)
    {
        IQueryable<User> queryable = DbSetContext;

        if (toQuery)
            queryable = queryable.AsNoTracking();

        if (include is not null)
            queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> ExistAsync(Expression<Func<User, bool>> predicate) =>
        await DbSetContext.AnyAsync(predicate);

    public async Task<string> PasswordHashAsync(string password)
    {
        return await Task.FromResult(userManager.PasswordHasher.HashPassword(null, password));
    }


}
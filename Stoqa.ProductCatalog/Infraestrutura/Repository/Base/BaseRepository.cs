using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.Infraestrutura.ORM.Context;

namespace Stoqa.ProductCatalog.Infraestrutura.Repository.Base;

public abstract class BaseRepository<T>(
    ApplicationContext dbContext) : IDisposable where T : class
{
    private const int StandardQuantity = 0;

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    protected DbSet<T> DbSetContext => dbContext.Set<T>();

    protected async Task<bool> SaveInDataBaseAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken) > StandardQuantity;
}
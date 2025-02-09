namespace Stoqa.ProductCatalog.Domain.Interfces;

public interface IUnitOfWork
{
    void CommitTransaction();
    void RollbackTransaction();
    void BeginTransaction();
}
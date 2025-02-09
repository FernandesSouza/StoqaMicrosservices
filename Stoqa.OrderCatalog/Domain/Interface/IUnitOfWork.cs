namespace Stoqa.OrderCatalog.Domain.Interface;

public interface IUnitOfWork
{
    void CommitTransaction();
    void RollbackTransaction();
    void BeginTransaction();
}
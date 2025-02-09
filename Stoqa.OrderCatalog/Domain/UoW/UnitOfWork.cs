using Microsoft.EntityFrameworkCore.Infrastructure;
using Stoqa.OrderCatalog.Infraestrutura.ORM.Context;
using IUnitOfWork = Stoqa.OrderCatalog.Domain.Interface.IUnitOfWork;

namespace Stoqa.OrderCatalog.Domain.UoW;

public sealed class UnitOfWork(
    ApplicationContext applicationContext) 
    : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade = applicationContext.Database;

    public void CommitTransaction()
    {
        try
        {
            _databaseFacade.CommitTransaction();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
    }

    public void RollbackTransaction() => _databaseFacade.RollbackTransaction();

    public void BeginTransaction() => _databaseFacade.BeginTransaction();
}
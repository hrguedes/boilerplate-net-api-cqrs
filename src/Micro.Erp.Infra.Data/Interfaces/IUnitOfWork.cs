namespace Micro.Erp.Infra.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
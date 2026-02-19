using Microsoft.EntityFrameworkCore;
namespace Koala.Portal.Core.UnitOfWork;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task CommitAsync();
    void Commit();
}
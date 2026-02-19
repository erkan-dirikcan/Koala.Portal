using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(string id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    void Delete(TEntity entity);
    TEntity Update(TEntity entity);
}
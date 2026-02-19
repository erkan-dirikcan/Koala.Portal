using System.Linq.Expressions;

namespace Koala.Portal.Core.GetPassRepositories
{
	public interface IGetPassBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByIdAsyc(string id);
		Task<IEnumerable<TEntity>> GetAllAsyc();
		IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
		Task AddAsyc(TEntity entity);
		void Delete(TEntity entity);
		TEntity Update(TEntity entity);
	}
}

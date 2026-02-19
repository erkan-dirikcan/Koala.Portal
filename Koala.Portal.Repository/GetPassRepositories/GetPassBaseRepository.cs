using System.Linq.Expressions;
using Koala.Portal.Core.GetPassRepositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.GetPassRepositories;

public class GetPassBaseRepository<TEntity> : IGetPassBaseRepository<TEntity> where TEntity : class
{
	private readonly SistemCryptorContext _context;
	private readonly DbSet<TEntity> _dbSet;

	public GetPassBaseRepository(SistemCryptorContext context)
	{
		_context = context;
		_dbSet = context.Set<TEntity>();
	}

	public async Task AddAsyc(TEntity entity)
	{
		await _context.AddAsync(entity);
		await _context.SaveChangesAsync();
	}

	public void Delete(TEntity entity)
	{
		_context.Remove(entity);
		_context.SaveChanges();
	}

	public async Task<IEnumerable<TEntity>> GetAllAsyc()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<TEntity?> GetByIdAsyc(string id)
	{
		var entity = await _dbSet.FindAsync(id);
		if (entity != null)
		{
			_context.Entry(entity).State = EntityState.Detached;
		}
		return entity;
	}

	public TEntity Update(TEntity entity)
	{
		_context.Entry(entity).State = EntityState.Modified;
		_context.SaveChanges();
		return entity;
	}

	public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
	{
		return _dbSet.Where(predicate);
	}
}
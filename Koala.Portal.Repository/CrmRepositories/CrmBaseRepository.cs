using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmBaseRepository<TEntity> : ICrmBaseRepository<TEntity> where TEntity : class
    {
        public readonly SistemCrmContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public CrmBaseRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
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

        public async Task<TEntity> GetByIdAsync(string id)
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
}

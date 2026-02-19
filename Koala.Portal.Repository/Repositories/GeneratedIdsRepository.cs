using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class GeneratedIdsRepository : IGeneratedIdsRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<GeneratedIds> _dbSet;
        public GeneratedIdsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<GeneratedIds>();
        }

        public async Task AddAsync(GeneratedIds generatedIds)
        {
            await _context.AddAsync(generatedIds);
        }

        public async Task<GeneratedIds> GetByIdAsync(string id)
        {
            var gId = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (gId != null)
            {
                _context.Entry(gId).State = EntityState.Detached;
            }
            return gId;
        }

        public async Task<GeneratedIds> GetByModuleIdAsync(string id)
        {
            var moduleId = await _dbSet.FirstOrDefaultAsync(x=>x.ModuleId == id);
            if (moduleId != null)
            {
                _context.Entry(moduleId).State = EntityState.Detached;
            }
            return moduleId;
        }
        
        public async Task<IEnumerable<GeneratedIds>> GetGeneratedIdsList()
        {
            return await _dbSet.Include(x => x.Module).ToListAsync();
        }

        public async Task UpdateAsync(GeneratedIds entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<GeneratedIds> Where(Expression<Func<GeneratedIds, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

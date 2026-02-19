using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Module> _dbSet;
        public ModuleRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Module>();
        }

        public async Task AddAsync(Module module)
        {
            await _context.AddAsync(module);
        }

        public bool any()
        {
            return _dbSet.Any();
        }

        public void Delete(Module module)
        {
            _context.Remove(module);
        }

        public async Task<Module> GetByIdAsyc(string id)
        {
            var module =await _dbSet.Include(x=>x.GeneratedIds).Include(x => x.Claims).FirstAsync(x => x.Id == id);
            return module;
        }

        public async Task<IEnumerable<Module>> GetModuleList()
        {
            return await _dbSet.Include(x => x.Claims).ToListAsync();
        }

        public Module UpdateAsync(Module entity)
        {
            var res = _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<Module> Where(Expression<Func<Module, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

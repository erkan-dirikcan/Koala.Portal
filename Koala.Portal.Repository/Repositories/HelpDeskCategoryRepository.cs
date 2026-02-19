using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class HelpDeskCategoryRepository : IHelpDeskCategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<HelpDeskCategory> _dbSet;

        public HelpDeskCategoryRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<HelpDeskCategory>();
        }
        public async Task AddAsync(HelpDeskCategory helpDeskCategory)
        {
            await _context.AddAsync(helpDeskCategory);
        }

        public void Delete(HelpDeskCategory helpDeskCategory)
        {
            _context.Remove(helpDeskCategory);
        }

        public async Task<HelpDeskCategory> GetByIdAsync(string id)
        {
            var hDC= await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (hDC != null)
            {
                _context.Entry(hDC).State = EntityState.Detached;
            }
            return hDC;
        }

        public async Task<HelpDeskCategory> GetCategoriWithProblem(string id)
        {
            var retVal= await _dbSet.Include(x=>x.HelpDeskProblems).FirstOrDefaultAsync(x=>x.Id==id);
            return retVal;

        }

        public async Task<IEnumerable<HelpDeskCategory>> GetHelpDeskCategoryList()
        {
            return await _dbSet.Where(x => x.Status != Core.Dtos.StatusEnum.Deleted).ToListAsync();
        }

        public async Task UpdateAsync(HelpDeskCategory entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<HelpDeskCategory> Where(Expression<Func<HelpDeskCategory, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

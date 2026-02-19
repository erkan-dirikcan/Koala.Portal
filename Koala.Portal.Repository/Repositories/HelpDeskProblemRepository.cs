using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class HelpDeskProblemRepository : IHelpDeskProblemRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<HelpDeskProblem> _dbSet;

        public HelpDeskProblemRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<HelpDeskProblem>();
        }

        public async Task AddAsync(HelpDeskProblem helpDeskProblem)
        {
            await _context.AddAsync(helpDeskProblem);
        }

        public void Delete(HelpDeskProblem helpDeskProblem)
        {
            _context.Remove(helpDeskProblem);
        }

        public async Task<HelpDeskProblem> GetByIdAsync(string id)
        {
            var hDeskProblem = await _dbSet.Include(x=>x.HelpDeskSolitions).FirstOrDefaultAsync(x => x.Id == id);
            if (hDeskProblem != null)
            {
                _context.Entry(hDeskProblem).State = EntityState.Detached;
            }
            return hDeskProblem;
        }

        public async Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemLastAddedList()
        {
            return await _dbSet.Include(x => x.Catogory).OrderByDescending(x => x.CreateTime).Where(x => x.Status != Core.Dtos.StatusEnum.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemList()
        {
            return await _dbSet.Include(x=>x.Catogory).Where(x => x.Status != Core.Dtos.StatusEnum.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemViewOrderList()
        {
            return await _dbSet.Include(x => x.Catogory).OrderByDescending(x=>x.Views).Where(x => x.Status != Core.Dtos.StatusEnum.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemWithCategory(string category)
        {
            return await _dbSet.Where(x => x.CategoryId == category).OrderByDescending(x => x.CreateTime).ToListAsync();
        }

        public async Task UpdateAsync(HelpDeskProblem entity)
        {
            _dbSet.Entry(entity).State=EntityState.Modified;
        }

        public  IQueryable<HelpDeskProblem> Where(Expression<Func<HelpDeskProblem, bool>> predicate)
        {
            return _dbSet.Include(x=>x.HelpDeskSolitions).Where(predicate);
        }
    }
}

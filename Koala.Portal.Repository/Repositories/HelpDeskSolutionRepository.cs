using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class HelpDeskSolutionRepository : IHelpDeskSolutionRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<HelpDeskSolution> _dbSet;

        public HelpDeskSolutionRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<HelpDeskSolution>();
        }

        public async Task AddAsync(HelpDeskSolution helpDeskSolution)
        {
            await _context.AddAsync(helpDeskSolution);
        }

        public void Delete(HelpDeskSolution helpDeskSolution)
        {
            _context.Remove(helpDeskSolution);
        }

        public async Task<HelpDeskSolution> GetByIdAsync(string id)
        {
            var hDS =await _dbSet.FirstOrDefaultAsync(x=>x.Id== id);
            if (hDS!=null)
            {
                _context.Entry(hDS).State= EntityState.Detached;
            }
            return hDS;
        }

        public async Task<IEnumerable<HelpDeskSolution>> GetHelpDeskSolutionList()
        {
            return await _dbSet.Include(x=>x.HelpDeskProblem).Where(x=>x.Status !=Core.Dtos.StatusEnum.Deleted).ToListAsync();
        }

        public async Task UpdateAsync(HelpDeskSolution entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}

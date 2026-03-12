using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ProjectLineRepository : IProjectLineRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ProjectLine> _dbSet;

        public ProjectLineRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProjectLine>();
        }

        public async Task AddAsync(ProjectLine projectLine)
        {
            projectLine.UpdateTime = DateTime.Now;
            projectLine.UpdateUser=projectLine.CreateUser;
            await _dbSet.AddAsync(projectLine);
        }

       
        public void Delete(ProjectLine projectLine)
        {
            _dbSet.Remove(projectLine);
        }
        public async Task<IEnumerable<ProjectLine>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.LineOffcial)
                .Include(x => x.Project)
                .Include(x => x.LineNotes)
                .Include(x => x.LineWorks).ToListAsync();
        }

        public async Task<ProjectLine?> GetByIdAsyc(string id)
        {
            return await _dbSet.Include(x => x.LineOffcial)
                .Include(x => x.Project)
                .Include(x => x.LineNotes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(ProjectLine entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<ProjectLine> Where(Expression<Func<ProjectLine, bool>> predicate)
        {
            return _dbSet
                .Include(x => x.LineWorks)
                .Where(predicate);
        }


        
    }
}

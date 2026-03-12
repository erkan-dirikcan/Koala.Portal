using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Project> _dbSet;
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Project>();
        }
        public async Task AddAsync(Project project)
        {
            await _dbSet.AddAsync(project);
        }
        public void Delete(Project project)
        {
            _dbSet.Remove(project);
        }   
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.ProjectManager)
                .Include(x => x.ProjectFiles)
                .Include(x => x.ProjectLines).ToListAsync();
        }
        public async Task<Project?> GetByCodeAsyc(string code)
        {
            return await _dbSet.Include(x => x.ProjectManager)
               .Include(x => x.ProjectFiles)
               .Include(x => x.ProjectLines)
               .FirstOrDefaultAsync(x => x.ProjectCode == code);
        }
        public async Task<Project?> GetByIdAsyc(string id)
        {
            return await _dbSet.Include(x => x.ProjectManager)
                  .Include(x => x.ProjectFiles)
                  .Include(x => x.ProjectLines)
                  .FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Update(Project entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<Project> Where(Expression<Func<Project, bool>> predicate)
        {
            return _dbSet.Include(x => x.ProjectManager)
                .Include(x => x.ProjectFiles)
                .Include(x => x.ProjectLines)
                .Where(predicate);
        }
    }
}

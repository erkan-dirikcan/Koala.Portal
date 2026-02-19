using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ProjectLineWorkRepository : IProjectLineWorkRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ProjectLineWork> _dbSet;
        public async Task AddAsync(ProjectLineWork projectLine)
        {
            _dbSet.Add(projectLine);
        }

        public async Task<ProjectLineWork?> GetByIdAsyc(string id)
        {
            return await _dbSet.Include(x => x.Line)
                 .Include(x => x.DeliveredPerson)
                 .Include(x => x.WorkFirmOffcial)
                 .Include(x => x.WorkPersons)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(ProjectLineWork entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<ProjectLineWork?> Where(Expression<Func<ProjectLineWork, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

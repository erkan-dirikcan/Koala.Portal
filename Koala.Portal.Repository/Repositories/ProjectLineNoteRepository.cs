using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ProjectLineNoteRepository : IProjectLineNoteRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ProjectLineNote> _dbSet;

        public ProjectLineNoteRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProjectLineNote>();
        }
        public async Task AddAsync(ProjectLineNote projectLineNote)
        {
            _dbSet.Add(projectLineNote);
        }

        public void Delete(ProjectLineNote projectLineNote)
        {
            _dbSet.Remove(projectLineNote);
        }

        public async Task<ProjectLineNote> GetByIdAsyc(string id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Update(ProjectLineNote entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<ProjectLineNote> Where(Expression<Func<ProjectLineNote, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


    }
}

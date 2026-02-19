using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class ProjectFileRepository : IProjectFileRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ProjectFiles> _dbSet;
        public ProjectFileRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProjectFiles>();
        }
        public void AddFile(ProjectFiles projectFiles)
        {
            _dbSet.Add(projectFiles);
        }

        public void DeleteFile(ProjectFiles projectFiles)
        {
            _dbSet.Remove(projectFiles);
        }

        public async Task<IEnumerable<ProjectFiles>> GetAllFiles(string projectId)
        {
            return await _dbSet.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<ProjectFiles> GetFile(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

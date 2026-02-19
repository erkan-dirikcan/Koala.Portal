using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class ApplicationModulesRepository(AppDbContext context) : IApplicationModulesRepository
    {
        private readonly DbSet<ApplicationModules> _dbSet = context.Set<ApplicationModules>();

        public async Task<List<ApplicationModules>> GetApplicationModulesListAsync(string applicationId)
        {
            var res =await _dbSet.Where(x => x.ApplicationId == applicationId).ToListAsync();
            return res;
        }

        public async Task CreateModuleForApplicationAsync(ApplicationModules model)
        {
            await _dbSet.AddAsync(model);
        }

        public void UpdateModuleForApplication(ApplicationModules model)
        {
           _dbSet.Entry(model).State= EntityState.Modified;
        }

        public async Task<ApplicationModules?> GetApplicationModulesAsync(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

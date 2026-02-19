using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class ApplicationFirmRepository : IApplicationFirmRepository
    {
        private readonly AppDbContext _context;
        private DbSet<ApplicationFirms> _dbSet;
        public ApplicationFirmRepository(AppDbContext appDbContext = null)
        {
            _context = appDbContext;
            _dbSet=_context.Set<ApplicationFirms>();
        }
        public async Task AddAsync(ApplicationFirms applicationFirm)
        {
            await _dbSet.AddAsync(applicationFirm);
        }

        public async Task<ApplicationFirms> FindApplicationFirm(string Id) => await _dbSet.Include(x => x.Application).Include(x => x.Firm).FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<List<ApplicationFirms>> GetApplicationFirms(string applicationId)
        {
            return await _dbSet.Include(x=>x.Application).Include(x=>x.Firm).Where(x=>x.ApplicationId==applicationId).ToListAsync();
        }

        public void Update(ApplicationFirms applicationFirm)
        {
            _dbSet.Entry(applicationFirm).State=EntityState.Modified;
        }
    }
}

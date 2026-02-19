using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Repository.Repositories
{
    public class ApplicationLicencesRepository : IApplicationLicencesRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ApplicationLicences> _dbSet;


        public ApplicationLicencesRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ApplicationLicences>();
        }

        public async Task<IEnumerable<ApplicationLicences>> GetApplicationLicencesAsync(string applicationGuid)
        {
            return await _dbSet.Include(x => x.Applications).Where(x => x.Applications.AppId == applicationGuid).ToListAsync();
        }

        public async Task<List<ApplicationLicences>> GetWaitingLicences()
        {
            return await _dbSet.Include(x => x.Applications).Where(x => x.licenceStatus==ApplicationLicenceStatusEnum.AcceptWaiting).ToListAsync();
        }

        public async Task AddLicenceRequestAsync(ApplicationLicences entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateLicenceRequestAsync(ApplicationLicences entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public async Task<ApplicationLicences> GetById(string id)
        {
            var entity = await _dbSet.Include(x => x.Applications).FirstOrDefaultAsync(x => x.Id == id);
            return entity;

        }

        public async Task<ApplicationLicences> FindMacLicence(ApplicationCheckLicenceViewModel model)
        {
            var entity = await _dbSet.Include(x => x.Applications).FirstOrDefaultAsync(x => x.CpuId == model.CpuId && 
                                                                                            x.MainboardId == model.MainboardId && 
                                                                                            x.PcName == model.PcName
                                                                                            );
            return entity;
        }
    }
}

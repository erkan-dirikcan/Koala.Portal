using System.Linq.Expressions;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class FirmRepository :  IFirmRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<CrmFirm> _dbSet;
        public FirmRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<CrmFirm>();
        }

        public async Task AddRangeAsync(List<CrmFirm> firms)
        {
            await _context.AddRangeAsync(firms);
        }

        public CrmFirm? GetFirmInfoById(string id)
        {
            var res = _dbSet
                .Include(x => x.Contacts)
                .Include(x => x.Phones)
                .FirstOrDefault(x => x.Id == id);
            return res;
        }
        public async Task UpdateFirmAsync(CrmFirm entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<CrmFirm> Where(Expression<Func<CrmFirm, bool>> predicate)
        {
            return _dbSet.Include(x => x.Contacts)
                .Include(x => x.Phones)
                .Where(x => x.InUse == true);
        }

        public async Task<IEnumerable<CrmFirm>> GetAllAsync()
        {
            try
            {
                var res = await _dbSet
                        .Include(x => x.Contacts)
                        .Include(x => x.Phones)
                        .ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

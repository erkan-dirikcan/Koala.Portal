using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class VacationRequestRepository : IVacationRequestRepository
    {
        public readonly AppDbContext _context;
        public readonly DbSet<VacationRequest> _dbSet;

        public VacationRequestRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<VacationRequest>();
        }
        public async Task AddAsyc(VacationRequest entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<IEnumerable<VacationRequest>> GetAllAsync()
        {
            return await _dbSet.Include(x=>x.User).Include(x=>x.VacationType).ToListAsync();
        }

        public async Task<VacationRequest?> GetByIdAsyc(string id)
        {
            //var entity = await _dbSet.Include(x => x.User).Include(x => x.VacationType).FindAsync(id);
            //if (entity != null)
            //{
            //    _context.Entry(entity).State = EntityState.Detached;
            //}
            return null; //entity;
        }

        public VacationRequest Update(VacationRequest entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<VacationRequest> Where(Expression<Func<VacationRequest, bool>> predicate)
        {
            return _dbSet.Include(x => x.User).Include(x => x.VacationType).Where(predicate);
        }
    }
}

using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        public readonly AppDbContext _context;
        public readonly DbSet<Claims> _dbSet;

        public ClaimRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Claims>();
        }


        public async Task AddAsync(Claims claims)
        {
            await _context.AddAsync(claims);
        }

        public void Delete(Claims claims)
        {
             _context.Remove(claims);
        }

        public async Task<IEnumerable<Claims>> GetAllAsync()
        {
            return await _dbSet.Include(x=>x.Module).ToListAsync();
        }

        public async Task<Claims> GetByIdAsyc(string id)
        {
            var claim = await _dbSet.FirstOrDefaultAsync(x=>x.Id==id);
            if (claim != null)
            {
                _context.Entry(claim).State = EntityState.Detached;
            }
            return claim;
        }

        public async Task UpdateAsync(Claims claims)
        {
            var res= _context.Entry(claims).State = EntityState.Modified;
        }

        public IQueryable<Claims> Where(Expression<Func<Claims, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

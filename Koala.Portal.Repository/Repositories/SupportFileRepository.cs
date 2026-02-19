using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class SupportFileRepository:ISupportFileRepository
    {
        public readonly AppDbContext _context;
        public readonly DbSet<SupportFile> _dbSet;

        public SupportFileRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<SupportFile>();
        }

        public async Task<SupportFile> GetBySupportIdAsyc(string ticketId)
        {
            var res = await _dbSet.FirstOrDefaultAsync(x => x.TicketId == ticketId);
            return res;
        }

        public async Task<SupportFile> GetByIdAsyc(string fileId)
        {
            var res = await _dbSet.FirstOrDefaultAsync(x => x.Id == fileId);
            return res;
        }
    }
}

using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmTicketHistoryRepository : ICrmTicketHistoryRepository
    {
        private readonly SistemCrmContext _context;
        private readonly DbSet<EX_Ticket_History> _dbSet;

        public CrmTicketHistoryRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet = _context.Set<EX_Ticket_History>(); ;
        }

        public async Task AddAsync(EX_Ticket_History model)
        {
            _context.EX_Ticket_History.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}

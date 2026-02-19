using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmSupportStateRepository : ICrmSupportStatesRepository
    {
        private readonly SistemCrmContext _context;
        public readonly DbSet<CT_Ticket_States> _dbSet;

        public CrmSupportStateRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet = context.Set<CT_Ticket_States>();
        }
        public async Task<IQueryable<CT_Ticket_States>> WhereAsync(Expression<Func<CT_Ticket_States, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<CT_Ticket_States>> GetAllAsync()
        {
            return _dbSet.Where(x => x.GCRecord == null).AsEnumerable();
        }

        public async Task<CT_Ticket_States?> GetByOidAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Oid == id && x.IsActive == true && x.GCRecord == null);
        }
    }
}

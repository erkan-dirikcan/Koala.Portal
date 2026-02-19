using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories;

public class CrmSupportTypeRepository : CrmBaseRepository<CT_Ticket_Types>, ICrmSupportTypeRepository
{
    private readonly SistemCrmContext _context;
    public readonly DbSet<CT_Ticket_Types> _dbSet;
    public CrmSupportTypeRepository(SistemCrmContext context) : base(context)
    {
        _context = context;
        _dbSet = context.Set<CT_Ticket_Types>();
    }

    public async Task<IEnumerable<CT_Ticket_Types>> GetAllAsync()
    {
        return _dbSet.Where(x => x.GCRecord == null).AsEnumerable();
    }

    public async Task<CT_Ticket_Types?> GetByOidAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Oid == id && x.IsActive == true && x.GCRecord == null);
    }

    public async Task<IQueryable<CT_Ticket_Types>> WhereAsync(Expression<Func<CT_Ticket_Types, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }
}
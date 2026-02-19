using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories;

public class CrmPhoneRepository : ICrmPhoneRepository
{
    SistemCrmContext _context;
    private readonly DbSet<PO_Phone_Number> _dbSet;

    public CrmPhoneRepository(SistemCrmContext context)
    {
        _context = context;
        _dbSet = context.Set<PO_Phone_Number>();
    }
    public IQueryable<PO_Phone_Number> Where(Expression<Func<PO_Phone_Number, bool>> predicate)
    {
        return _dbSet.Include(x => x.RelatedContactNavigation)
                     .Include(x => x.RelatedFirmNavigation)
                     .Where(predicate);
    }
}
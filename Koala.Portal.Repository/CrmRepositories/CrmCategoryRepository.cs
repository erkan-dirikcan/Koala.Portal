using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmCategoryRepository : ICrmCategoryRepository
    {
        SistemCrmContext _context;

        public CrmCategoryRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet = context.Set<CT_Activity_Category>();
        }

        public readonly DbSet<CT_Activity_Category> _dbSet;
        public IQueryable<CT_Activity_Category> Where(Expression<Func<CT_Activity_Category, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

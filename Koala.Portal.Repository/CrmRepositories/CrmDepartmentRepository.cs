using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmDepartmentRepository : ICrmDepartmentRepository
    {
        SistemCrmContext _context;
        public readonly DbSet<CT_User_Departments> _dbSet;

        public CrmDepartmentRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet =context.Set<CT_User_Departments>();
        }

        public IQueryable<CT_User_Departments> Where(Expression<Func<CT_User_Departments, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}

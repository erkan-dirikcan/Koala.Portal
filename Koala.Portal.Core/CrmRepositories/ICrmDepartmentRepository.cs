using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories
{
    public interface ICrmDepartmentRepository
    {
        IQueryable<CT_User_Departments> Where(Expression<Func<CT_User_Departments, bool>> predicate);
    }
}

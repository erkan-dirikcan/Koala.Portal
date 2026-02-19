using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmServices
{
    public interface ICrmDepartmentService
    {
       Response<List<CrmDepartmentInfoViewModel>> Where(Expression<Func<CT_User_Departments, bool>> predicate);
    }
}

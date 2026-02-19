using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmServices
{
    public interface ICrmCategoryService
    {
        Response<List<CrmCategoryInfoViewModels>> Where(Expression<Func<CT_Activity_Category, bool>> predicate);
    }
}

using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories
{
    public interface ICrmCategoryRepository
    {
        IQueryable<CT_Activity_Category> Where(Expression<Func<CT_Activity_Category, bool>> predicate);
    }
}

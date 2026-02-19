using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IHelpDeskCategoryRepository
    {
        IQueryable<HelpDeskCategory> Where(Expression<Func<HelpDeskCategory, bool>> predicate);
        Task<IEnumerable<HelpDeskCategory>> GetHelpDeskCategoryList();
        Task<HelpDeskCategory> GetByIdAsync(string id);
        Task AddAsync(HelpDeskCategory helpDeskCategory);
        Task UpdateAsync(HelpDeskCategory entity);
        void Delete(HelpDeskCategory helpDeskCategory);
        Task<HelpDeskCategory> GetCategoriWithProblem(string id);
    }
}

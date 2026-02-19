using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IHelpDeskProblemRepository
    {
        IQueryable<HelpDeskProblem> Where(Expression<Func<HelpDeskProblem, bool>> predicate);
        Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemList();
        Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemWithCategory(string category);
        Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemViewOrderList();
        Task<IEnumerable<HelpDeskProblem>> GetHelpDeskProblemLastAddedList();
        Task<HelpDeskProblem> GetByIdAsync(string id);
        Task AddAsync(HelpDeskProblem helpDeskProblem);
        Task UpdateAsync(HelpDeskProblem entity);
        void Delete(HelpDeskProblem helpDeskProblem);
    }
}
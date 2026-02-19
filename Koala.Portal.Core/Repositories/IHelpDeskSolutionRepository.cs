using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface IHelpDeskSolutionRepository
    {
        Task<IEnumerable<HelpDeskSolution>> GetHelpDeskSolutionList();
        Task<HelpDeskSolution> GetByIdAsync(string id);
        Task AddAsync(HelpDeskSolution helpDeskSolution);
        Task UpdateAsync(HelpDeskSolution entity);
        void Delete(HelpDeskSolution helpDeskSolution);
    }
}

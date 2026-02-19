using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface IVacationHistoryRepository
    {
        Task AddVacationHistoryAsync(VacationHistory model);
    }
}

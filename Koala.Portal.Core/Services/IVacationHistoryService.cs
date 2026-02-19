using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IVacationHistoryService
    {
        Task<Response> AddVacationHistoryAsync(AddVacationHistoryViewModel model);
    }
}

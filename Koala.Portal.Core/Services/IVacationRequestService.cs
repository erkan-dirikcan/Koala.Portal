
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IVacationRequestService
    {
        Task<Response<List<VacationRequestListViewModel>>> GetVacationRequests();
        Task<Response<VacationRequestDetailViewModel?>> GetByIdAsyc(string id);
        Task<Response> CreateRequestAsyc(VacationRequestCreateViewModel model, string userId);
        Task<Response> UpdateRequestAsyc(VacationRequestRevisionViewModel model, string userId);
        Task<Response> RevisionRequestAsyc(VacationRequestRevisionRequestViewModel model, string userId);
        Task<Response> CancelAsyc(VacationRequestCancelViewModel model, string userId);

    }
}

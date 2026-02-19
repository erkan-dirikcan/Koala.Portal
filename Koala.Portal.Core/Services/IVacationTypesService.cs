using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IVacationTypesService
    {
        Task<Response<VacationTypesViewModel>?> GetByIdAsyc(string id);
        Task<Response<IEnumerable<VacationTypesViewModel>>> GetAllAsync();
        Task<Response<VacationTypesViewModel>> AddAsyc(VacationTypesCreateViewModel dto);
        Task<Response> ChangeStatus(VacationTypesChangeStatusViewModel dto);
        Task<Response> UpdateAsyc(VacationTypesViewModel dto, string id);
    }
}

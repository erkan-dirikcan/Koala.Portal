using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IFirmService
    {
        Task<Response<List<InfoCrmFirmViewModel>>> GetFirmList();
        Task<Response> AddRangeAsync(List<CreateCrmFirmViewModel> firms);
        Task<Response<InfoCrmFirmViewModel>> GetFirmByIdAsync(string id);
        Task<Response<SupportListInfoCrmFirmViewModel>> GetFirmByOidAsync(string oid);
        //Task<Response<InfoCrmFirmViewModel>> UpdateFirmAsync(string id);
    }
}

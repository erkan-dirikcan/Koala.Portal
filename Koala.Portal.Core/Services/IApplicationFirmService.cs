using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IApplicationFirmService
    {
        Task<Response> AddAsync(AddApplicationFirmsViewModel model);
        Task<Response> UpdateExpDate (UpdateExpDateApplicationFirmsViewModel model);
        Task<Response<List<GetApplicationFirmListViewModel>>> GetApplicationFirms(string ApplicationId);


    }
}

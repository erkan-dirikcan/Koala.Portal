using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services;

public interface IApplicationsService
{
    Task<Response> AddAsync(CreateApplicationsViewModel model);
    Task<Response<List<ApplicationsListViewModel>>> GetApplicationList();
    Task<Response<List<ApplicationsListViewModel>>> GetApplicationListForModule();
    Task<Response> UpdateAsync(UpdateApplicationsViewModel model);
    Task<Response> ChangeStatusAsync(ApplicationsChangeStatusViewModel model);
    Task<Response<DetailApplicationsViewModel>> GetByIdAsync(string id);
    Task<Response<DetailApplicationsViewModel>> GetByGuidAsync(string applicationGuid);
    Task<Response<ApplicationsAddExpDateViewModel>> GetExpDateInfoAsync(string id);
    Task<Response> UpdateExpDateInfoAsync(ApplicationsAddExpDateViewModel model);
    Task<Response<UpdateApplicationsViewModel>> GetUpdateDataAsync(string id);
    Task<Response<string>> EncryptData(string data, string applicationId);
    Task<Response<string>> DecryptData(string data, string applicationId);
}
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services;

public interface IApplicationModulesService
{
    Task<Response<List<ApplicationModulesListViewModel>>> GetApplicationModulesListAsync(string applicationId);
    Task<Response> CreateModuleForApplicationAsync(CreateApplicationModulesViewModel model);
    Response UpdateModuleForApplication(ApplicationModulesListViewModel model);
    Task<Response<List<ApplicationModulesDecryptedViewModel?>>> DeCryptApplicationModulesJsonAsync(ApplicationModulesDecrypJsonViewModel encryptedText);
}
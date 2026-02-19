using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface IApplicationModulesRepository
    {
        Task<List<ApplicationModules>> GetApplicationModulesListAsync(string applicationId);
        Task CreateModuleForApplicationAsync(ApplicationModules model);
        void UpdateModuleForApplication(ApplicationModules model);
        Task<ApplicationModules?> GetApplicationModulesAsync(string id);
    }
}

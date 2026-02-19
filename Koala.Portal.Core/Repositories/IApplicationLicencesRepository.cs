using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Repositories;

public interface IApplicationLicencesRepository
{
    Task<IEnumerable<ApplicationLicences>> GetApplicationLicencesAsync(string applicationGuid);
    Task<List<ApplicationLicences>> GetWaitingLicences();
    Task AddLicenceRequestAsync(ApplicationLicences entity);
    Task UpdateLicenceRequestAsync(ApplicationLicences entity);
    Task<ApplicationLicences> GetById(string id);
    Task<ApplicationLicences> FindMacLicence(ApplicationCheckLicenceViewModel model);

}
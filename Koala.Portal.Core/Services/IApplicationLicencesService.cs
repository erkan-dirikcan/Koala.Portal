using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services;

public interface IApplicationLicencesService
{
    Task<Response<IEnumerable<ApplicationLicencesListViewModel>>> GetApplicationLicencesAsync(string applicationGuid);
    //Task<Response<>>
    Task<Response<ApiLicenceResultViewModel>> AddLicenceRequestAsync(ApplicationLicencesRequestViewModel model);
    Task<Response<List<ApplicationLicencesListViewModel>>> GetWaitingLicences();
    Task<Response> ConfirmLicence(ConfirmApplicationLicencesViewModel model);
    Task<Response<DetailApplicationLicencesViewModels>> GetLiceceByIdAsync(string  id);
    Task<Response<LicanceCryptionJosonViewModel>> CheckApplicationLicence(ApplicationCheckLicenceViewModel model);
    Task<Response<ApplicationLicenceCountViewModel>> GetApplicationLicanceCount(string id);
}
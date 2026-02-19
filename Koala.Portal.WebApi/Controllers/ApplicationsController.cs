using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApplicationLicenceController : ControllerBase
    {
        //private readonly IApplicationsService _applicationsService;
        private readonly IApplicationLicencesService _applicationLicencesService;
        private readonly IApplicationsService _applicationService;
        //private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public ApplicationLicenceController(IApplicationLicencesService applicationLicencesService, IApplicationsService applicationService)
        {
            //_unitOfWork = unitOfWork;
            _applicationLicencesService = applicationLicencesService;
            _applicationService = applicationService;
            //_applicationsService = applicationsService;
        }

        [HttpPost]
        public async Task<Response<LicanceCryptionJosonViewModel>> CheckLicence(ApplicationCheckLicenceViewModel model)
        {
            return await _applicationLicencesService.CheckApplicationLicence(model);
        }

        [HttpPost]
        public async Task<Response<ApiLicenceResultViewModel>> CreateApplicationLicencesRequest(ApplicationLicencesRequestViewModel model)
        {
            return await _applicationLicencesService.AddLicenceRequestAsync(model);
        }

        [HttpPost]
        public async Task<Response<string>> Encryption(string data, string applicationId)
        {
           return await _applicationService.EncryptData(data, applicationId);
        }
        [HttpPost]
        public async Task<Response<string>> Decryption(string data, string applicationId)
        {
            return await _applicationService.DecryptData(data, applicationId);
        }
    }
}

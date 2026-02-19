using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmSelectListService : ICrmSelectListService
    {
        private readonly ICrmSelectListRepository _crmSelectListRepository;

        public CrmSelectListService(ICrmSelectListRepository crmSelectListRepository)
        {
            _crmSelectListRepository = crmSelectListRepository;
        }

        public async Task<Response<List<SelectListItem>>> GetUserSelectList(bool withMail, string selected = "")
        {
            return await _crmSelectListRepository.GetUserSelectList(withMail, selected);
        }

        public async Task<Response<List<SelectListItem>>> GetFirmSelectList(string selected = "")
        {
            return await _crmSelectListRepository.GetFirmSelectList(selected);
        }

        public async Task<Response<List<SelectListItem>>> GetFirmContactListWithOid(string firmOid, string selected = "")
        {
            return await _crmSelectListRepository.GetFirmContactListWithOid(firmOid, selected);
        }
        public async Task<Response<List<SelectListItem>>> GetFirmContactList(string firmOid, string selected = "")
        {
            return await _crmSelectListRepository.GetFirmContactListWithOid(firmOid, selected);
        }
        public async Task<Response<List<SelectListItem>>> GetFirmSupportList(string firmOid, string selected)
        {
            return await _crmSelectListRepository.GetFirmSupportList(firmOid, selected);
        }

        public async Task<Response<List<SelectListItem>>> GetFirmContactMailList(string contactOid, string selected = "")
        {
            return await _crmSelectListRepository.GetFirmContactMailList(contactOid, selected);
        }

        public async Task<Response<List<SelectListItem>>> GetSupportDepartmentList(string selected = "")
        {
            return await _crmSelectListRepository.GetSupportDepartmentList(selected);
        }

        public async Task<Response<List<SelectListItem>>> GetDepartmentUserSelectList(string departmentOid, string selected = "")
        {
            return await _crmSelectListRepository.GetDepartmentUserSelectList(departmentOid, selected);
        }

        public async Task<Response<List<SelectListItem>>> GetSupportCategoryList(string selected = "")
        {
            return await _crmSelectListRepository.GetSupportCategoryList(selected);
        }

        public async Task<Response<List<SelectListItem>>> GetSupportSubCategoryList(string categoryOid, string selected = "")
        {
            return await _crmSelectListRepository.GetSupportSubCategoryList(categoryOid, selected);
        }

        public async Task<Response<List<SelectListItem>>> GetSupportTypeSelectList(string selected = "")
        {
            return await _crmSelectListRepository.GetSupportTypeSelectList(selected);
        }

        public async Task<Response<List<SelectListItem>>> GetSupportStateSelectList(List<string> selected)
        {
            
            return await _crmSelectListRepository.GetSupportStateSelectList(selected);
        }
    }
}

using Koala.Portal.Core.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmSelectListRepository
{
    Task<Response<List<SelectListItem>>> GetUserSelectList(bool withMail,string selected = "");
    Task<Response<List<SelectListItem>>> GetFirmSelectList(string selected = "");
    Task<Response<List<SelectListItem>>> GetFirmContactListWithOid(string firmOid, string selected = "");
    Task<Response<List<SelectListItem>>> GetFirmContactMailList(string contactOid, string selected = "");
    Task<Response<List<SelectListItem>>> GetFirmSupportList(string firmOid, string selected);
    Task<Response<List<SelectListItem>>> GetSupportDepartmentList(string selected = "");
    Task<Response<List<SelectListItem>>> GetDepartmentUserSelectList(string departmentOid, string selected = "");
    Task<Response<List<SelectListItem>>> GetSupportCategoryList(string selected = "");
    Task<Response<List<SelectListItem>>> GetSupportSubCategoryList(string categoryOid, string selected = "");
    Task<Response<List<SelectListItem>>> GetSupportTypeSelectList(string selected = "");
    Task<Response<List<SelectListItem>>> GetSupportStateSelectList(List<string> selected);
}
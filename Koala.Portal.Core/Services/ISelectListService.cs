using Koala.Portal.Core.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Core.Services;

public interface ISelectListService
{
    public Task<Response<List<SelectListItem>>> GetAgendaTypeSelectList(string selected="");
    public Task<Response<List<SelectListItem>>> GetFixtureSelectList(string selected="");
    public Task<Response<List<SelectListItem>>> GetFirmSelectList(string selected="");
    public Task<Response<List<SelectListItem>>> GetFirmContactSelectList(string firmId, string selected="");
    public Task<Response<List<SelectListItem>>> GetUserSelectList(string selected="");
    public Task<Response<List<SelectListItem>>> GetCategorySelectList(string selected = "");
    public Task<Response<List<SelectListItem>>> GetProblemSelectList(string selected = "");
    public Task<Response<List<SelectListItem>>> GetModuleSelectList(string selected = "");
    //public Response<List<SelectListItem>> GetPriorityEnumSelectList(PriorityEnum selected);
}
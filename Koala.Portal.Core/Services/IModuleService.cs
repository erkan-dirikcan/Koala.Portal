using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Core.Services;

public interface IModuleService
{
    bool any();
    Task<Response> AddAsync(CreateModuleListViewModels model);
    Task<Response> Delete(string id);
    Task<Response<GetModuleListViewModels>> UpdateAsync(UpdateModuleViewModels model,string id);
    Task<Response<GetModuleListViewModels>> GetByIdAsync(string id);
    Task<Response<UpdateModuleViewModels>> GetUpdateInfoAsync(string id);
    Task<Response<List<GetModuleListViewModels>>> GetModuleList();
    Response<List<SelectListItem>> GetModuleSelectList(string selected = "");
    Response<List<ClaimListForModuleViewModels>> GetClaimToModule(string id);
    Task<Response> AddClaimToModule(CreateClaimViewModels claim);
}
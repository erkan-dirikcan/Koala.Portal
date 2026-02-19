using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.GetPassViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Core.GetPassServices;

public interface IGetPassUserService
{
	Task<Response<List<SelectListItem>>> GetUserSkeySelectListAsync(string? isSelected="");
	Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoByIdAsync(string id);
    Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoByEmailAsync(string email);
    Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoBysKeyAsync(string sKey);
}
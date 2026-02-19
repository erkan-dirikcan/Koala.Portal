using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IHelpDeskCategoryService
    {
        Task<Response<List<HelpDeskCategoryInfoViewModels>>> GetHelpDeskCategoryList();
        Task<Response<HelpDeskCategoryInfoViewModels>> GetByIdAsync(string id);
        Task<Response<HelpDeskCategoryUpdateViewModel>> GetUpdateInfoAsync(string id);
        Task<Response> ChangeStatusAsync(HelpDeskCategoryChangeStatusViewModel model);
        Task<Response> AddAsync(HelpDeskCategoryCreateViewModel model);
        Task<Response<HelpDeskCategoryInfoViewModels>> UpdateAsync(HelpDeskCategoryUpdateViewModel model, string id);
        Task<Response> Delete(string id);

    }
}

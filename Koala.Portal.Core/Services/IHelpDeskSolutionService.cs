using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IHelpDeskSolutionService
    {
        Task<Response<List<HelpDeskSolitionInfoViewModels>>> GetHelpDeskSolutionList();
        Task<Response<HelpDeskSolitionInfoViewModels>> GetByIdAsync(string id);
        Task<Response<HelpDeskSolitionUpdateViewModel>> GetUpdateInfoAsync(string id);
        Task<Response> ChangeStatusAsync(HelpDeskSolitionChangeStatusViewModel model);
        Task<Response> AddAsync(HelpDeskSolitionCreateViewModel model);
        Task<Response<HelpDeskSolitionInfoViewModels>> UpdateAsync(HelpDeskSolitionUpdateViewModel model, string id);
        Task<Response> Delete(string id);
    }
}

using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IHelpDeskProblemService
    {
        Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemList();
        Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemViewOrderList();
        Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemLastAddedList();
        Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemWithCategory(string category);
        Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskFilterList(string tag);
        Task<Response<HelpDeskProblemInfoViewModels>> GetByIdAsync(string id);
        Task<Response<HelpDeskProblemDetailInfoViewModels>>DetailInfo (string id);
        Task<Response<HelpDeskProblemUpdateViewModel>> GetUpdateInfoAsync(string id);
        Task<Response> ChangeStatusAsync(HelpDeskProblemChangeStatusViewModel model);
        Task<Response> AddAsync(HelpDeskProblemCreateViewModel model);
        Task<Response<HelpDeskProblemInfoViewModels>> UpdateAsync(HelpDeskProblemUpdateViewModel model, string id);
        Task<Response> Delete(string id);
    }
}

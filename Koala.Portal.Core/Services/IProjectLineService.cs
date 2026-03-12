using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IProjectLineService
    {
        Task<Response> AddAsync(AddProjectLineViewModel model);
        Task<Response> UpdateAsync(UpdateProjectLineViewModel model, string id);
        Task<Response> DeleteAsync(string id);
        Task<Response> ChangeStateStatusAsync(ProjectLineChangeStateStatusViewModel model);
        Task<Response<List<ProjectLineListViewModel>>> GetProjectLineListAsync(string projectId);
        Task<Response<ProjectLineDetailViewModel>> GetProjectLineDetailAsync(string id);

        Task<Response<List<ProjectLineNoteViewModel>>> GetProjectLineNotesAsync(string projectLineId);
        Task<Response> AddProjectLineNote(AddProjectLineNoteViewModel model);
        Task<Response> UpdateProjectLineNote(UpdateProjectLineNoteViewModel model);
        Task<Response> DeleteProjectLineNoteAsync(string id);
    }
}

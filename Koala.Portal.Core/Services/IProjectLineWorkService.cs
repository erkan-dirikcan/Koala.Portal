using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IProjectLineWorkService
    {
        Task<Response> AddAsync(AddProjectLineWorkViewModel model);
        Task<Response> UpdateAsync(UpdateProjectLineWorkViewModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response<List<ProjectLineWorkListViewModel>>> GetProjectLineWorkListAsync(string projectLineId);
        Task<Response<ProjectLineWorkDetailViewModel>> GetProjectLineWorkDetailAsync(string id);
        Task<Response> ChangeWorkStateAsync(ProjectLineWorkChangeStateViewModel model);
        Task<Response> ComplateWorkAsync(ProjectLineWorkComplateViewModel model);
    }
}

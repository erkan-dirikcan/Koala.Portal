using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IProjectService
    {
        Task<Response<string>> AddAsync(AddProjectViewModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response<ProjectDetailViewModel>> UpdateAsync(UpdateProjectViewModel model, string id);
        Task<Response<List<ProjectListViewModel>>> GetProjectListAsync();
        Task<Response<List<ProjectListViewModel>>> GetFirmProjectListAsync(string firmId);
        Task<Response<List<ProjectListViewModel>>> GetFirmProjectListByFirmOidAsync(string firmOid);
        Task<Response<ProjectDetailViewModel>> GetProjectByIdAsync(string id);
        Task<Response<ProjectDetailViewModel>> GetProjectByCodeAsync(string code);

        Task<Response> AddFileToProject(AddProjectFilesViewModel model);
        Task<Response> DeleteFileToProject(string fileId);
        Task<Response<List<ProjectFilesListViewModel>>> GetAllProjectFiles(string projectId);
        Task<Response<ProjectFilesListViewModel>> GetProjectFile(string fileId);

    }
}

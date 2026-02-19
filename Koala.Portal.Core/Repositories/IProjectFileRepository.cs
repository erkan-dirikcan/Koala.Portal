using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface IProjectFileRepository
    {
        void AddFile(ProjectFiles projectFiles);
        void DeleteFile(ProjectFiles projectFiles);
        Task<IEnumerable<ProjectFiles>> GetAllFiles(string projectId);
        Task<ProjectFiles> GetFile(string id);


    }
}

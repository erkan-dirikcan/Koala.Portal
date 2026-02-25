using Microsoft.AspNetCore.Http;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ProjectFilesListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string UrlSlug { get; set; }
    }

    public class AddProjectFilesViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string UrlSlug { get; set; }
        public IFormFile? File { get; set; }
        public string? CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class RemoveProjectFilesViewModel
    {
        public string Id { get; set; }
    }
}

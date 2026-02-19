using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ProjectFiles
    {

        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string UrlSlug { get; set; }
        public virtual Project Project { get; set; }
    }
}

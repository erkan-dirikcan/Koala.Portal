using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ApplicationModules
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ApplicationId { get; set; }
        public string? Name { get; set; }
        public string? Desctiption { get; set; }
        public virtual Applications  Application { get; set; }
    }
}

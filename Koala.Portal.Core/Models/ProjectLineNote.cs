using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ProjectLineNote : CommonProperty
    {
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();
        
        public string ProjectLineId { get; set; }      
        public string UserId { get; set; }
        public string? Title { get; set; }
        public string? ReportNote { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }

        public virtual ProjectLine ProjectLine { get; set; }
    }

}

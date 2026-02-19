using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class HelpDeskSolution : CommonProperty
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string SolitionNumber { get; set; }
        public string HelpDeskProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; } 
        public bool CustomerCanSee { get; set; } = false;
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public virtual HelpDeskProblem HelpDeskProblem { get; set; }
    }
}

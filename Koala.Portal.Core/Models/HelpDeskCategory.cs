using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class HelpDeskCategory : CommonProperty
    {

        public HelpDeskCategory()
        {
            HelpDeskProblems = new HashSet<HelpDeskProblem>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public virtual ICollection<HelpDeskProblem> HelpDeskProblems { get; set; }
        public virtual ICollection<HelpDeskCategory> Children { get; set; } = new HashSet<HelpDeskCategory>();
        public virtual HelpDeskCategory? Parent { get; set; }
    }
}

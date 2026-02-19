using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class HelpDeskProblem : CommonProperty
    {

        public HelpDeskProblem()
        {
            HelpDeskSolitions = new HashSet<HelpDeskSolution>();
            Catogory = new HashSet<HelpDeskCategory>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();

        public string CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Views { get; set; }

        public virtual ICollection<HelpDeskCategory> Catogory { get; set; }


        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public virtual ICollection<HelpDeskSolution> HelpDeskSolitions { get; set; }
    }
}

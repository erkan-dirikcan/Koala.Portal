using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AgendaType
    {
        public AgendaType()
        {
            Agenda = new HashSet<Agenda>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Name { get; set; }
        public string Description { get; set; }
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string BorderColor { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}

using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AgendaUsers
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string UserId { get; set; }
        public string AgendaId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Agenda Agenda { get; set; }
    }
}

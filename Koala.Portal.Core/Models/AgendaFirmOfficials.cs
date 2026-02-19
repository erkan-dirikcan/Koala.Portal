using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AgendaFirmOfficials
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Oid { get; set; }
        public string AgendaId { get; set; }

        public string FullName { get; set; }

        public virtual Agenda? Agenda { get; set; }
    }
}

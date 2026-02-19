using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AgendaFixtures
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string AgendaId { get; set; }
        public string FixtureId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public int? StartKm { get; set; }
        public int? LastKm { get; set; }
        public virtual Agenda Agenda { get; set; }
        public virtual Fixture Fixture  { get; set; }
    }
}

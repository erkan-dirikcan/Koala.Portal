using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class Fixture
    {
        public Fixture()
        {
            AgendaFixtures = new HashSet<AgendaFixtures>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVehicle { get; set; }=false;
        public virtual ICollection<AgendaFixtures> AgendaFixtures { get; set; }
    }
}

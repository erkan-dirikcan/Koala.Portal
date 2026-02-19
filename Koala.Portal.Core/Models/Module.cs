using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class Module
    {
        public Module()
        {
            GeneratedIds = new HashSet<GeneratedIds>();
            Claims = new HashSet<Claims>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string Description { get; set; }
                      
        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public virtual ICollection<GeneratedIds> GeneratedIds { get; set; }
        public virtual ICollection<Claims> Claims { get; set; }

    }
}

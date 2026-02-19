using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class EmailTemplate:CommonProperty
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;

    }
}

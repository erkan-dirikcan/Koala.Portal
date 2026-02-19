using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class VacationTypes
    {
        public string Id { get; set; }=Tools.CreateGuidStr();
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }=StatusEnum.Active;
        public virtual List<VacationRequest> Vacations { get; set; }
    }
}

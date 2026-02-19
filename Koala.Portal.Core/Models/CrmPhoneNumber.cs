using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class CrmPhoneNumber
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Oid { get; set; }

        public string? RelatedFirm { get; set; }

        public string? RelatedContact { get; set; }

        public string? AreaCode { get; set; }

        public string? Number { get; set; }

        public string? Extension { get; set; }
        public virtual CrmFirm? RelatedFirmNavigation { get; set; }
        public virtual CrmFirmContact? RelatedContactNavigation { get; set; }
    }
}

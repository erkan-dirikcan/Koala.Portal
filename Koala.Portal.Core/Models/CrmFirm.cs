using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class CrmFirm
    {
        public CrmFirm()
        {
            Contacts = new HashSet<CrmFirmContact>();
        }
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public virtual ICollection<CrmFirmContact> Contacts { get; set; }
        public virtual ICollection<CrmPhoneNumber> Phones { get; set; }
        public virtual ICollection<ApplicationLicences> Licences { get; set; }
        public virtual ICollection<ApplicationFirms> Applications { get; set; }


        public string GetUrlSlug()
        {
            return $"{Oid}";
        }
        public string GetFormatName()
        {
            return $"({Oid}) - {Title}";
        }

    }
}

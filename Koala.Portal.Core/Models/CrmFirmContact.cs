using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class CrmFirmContact
    {
        public CrmFirmContact()
        {
            Phones = new HashSet<CrmPhoneNumber>();
        }
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Oid { get; set; }
        public string FirmId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool InUse { get; set; } = false;
        public bool SupportTicket { get; set; } = false;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public virtual CrmFirm Firm { get; set; }

        /// <summary>
        /// Telefon Numaraları
        /// </summary>
        public virtual ICollection<CrmPhoneNumber> Phones { get; set; }

        public string GetFirmDisplayName()
        {
            return $"({Firm.Code}) - {Firm.Title}";
        }
        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }

        public string GetPhones()
        {
            if (Phones.Count < 1)
            {
                return "CRM Telefon Kaydı Girilmemiş";
            }

            return string.Join("\r\n", Phones.Select(p => $"{p.AreaCode}{p.Number}{p.Extension}"));
        }

    }
}

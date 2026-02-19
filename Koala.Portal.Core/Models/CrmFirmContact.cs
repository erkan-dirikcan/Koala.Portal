using System.Text;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class CrmFirmContact
    {
        public CrmFirmContact()
        {
            PersonProjects = new HashSet<Project>();
            PersonProjectLines = new HashSet<ProjectLine>();
            PersonProjectLineWorks = new HashSet<ProjectLineWork>();
            PersonDeliveredProjectLineWorks = new HashSet<ProjectLineWork>();
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
        /// Yöneticisi Olduğu Firma Projeleri
        /// </summary> 
        public virtual ICollection<Project> PersonProjects { get; set; }
        /// <summary>
        /// Sorumlu Olduğu Firma Proje Fazları
        /// </summary>
        public virtual ICollection<ProjectLine> PersonProjectLines { get; set; }
        /// <summary>
        /// Sorumlu olduğu Proje işleri
        /// </summary>
        public virtual ICollection<ProjectLineWork> PersonProjectLineWorks { get; set; }
        /// <summary>
        /// Teslim Edilen Proje İşleri
        /// </summary>
        public virtual ICollection<ProjectLineWork> PersonDeliveredProjectLineWorks { get; set; }
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
            if (Phones.Count<1)
            {
                return "CRM Telefon Kaydı Girilmemiş";

            }
            var sb = new StringBuilder();
            var ph = Phones.ToArray();
                
            for (int i = 0; i < ph.Length; i++)
            {
                sb.Append($"{ph[i].AreaCode}");
                sb.Append($"{ph[i].Number}");
                sb.Append($"{ph[i].Extension}");
                if (i<ph.Length-1)
                {
                    sb.Append("\r\n");
                }
            }

            return sb.ToString();

        }

    }
}

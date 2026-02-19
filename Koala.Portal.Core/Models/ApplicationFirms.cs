using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ApplicationFirms
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ApplicationId { get; set; }
        public string FirmId { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi (Paket Uygulamalar İçin Geçerli)
        /// </summary>
        public DateTime? ExpDate { get; set; }
        public virtual Applications? Application { get; set; }
        public virtual CrmFirm? Firm { get; set; }

    }
}

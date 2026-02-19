using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ApplicationLicences
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; } = Tools.CreateGuidStr();
        /// <summary>
        /// Lisansın Sahibi Olan CRM Firması
        /// </summary>
        public string? LisansFirmId { get; set; }
        /// <summary>
        /// Uygulama Adı (Talep Gelince Uygulama Kendisi Göndeirr)
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationId { get; set; }
        /// <summary>
        /// Talep Onaylandığında Portal Tarafından Oluşturulur
        /// </summary>
        public string LicenceCode { get; set; }
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar CPU Seri Numarası (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string CpuId { get; set; }
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar Anakart Seri Numarası (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string MainboardId { get; set; }
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar Adı (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string PcName { get; set; }
        /// <summary>
        /// Uygulama Lisansının Onay Durumunu Gösterir
        /// </summary>
        public ApplicationLicenceStatusEnum licenceStatus { get; set; }
        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Pasive;
        /// <summary>
        /// Uygulama Lisansının Talep Edildiği Sisteme Eklendiği Tarih
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Onaylayan Kullanıcı Id Bilgisi
        /// </summary>
        public string? ApprovedByUserId { get; set; }
        /// <summary>
        /// Çoklu modül lisansı barındıran uygulamalar için kullanılır.
        /// </summary>
        public string? ModulesCryptedJson { get; set; }
        /// <summary>
        /// Onaylayan Kullanıcı
        /// </summary>
        public virtual AppUser? ApprovedByUser { get; set; }
        /// <summary>
        /// Lisansın Dahil Olduğu Uygulama
        /// </summary>
        public virtual CrmFirm? LicancedFirm { get; set; }
        /// <summary>
        /// Lisansın Dahil Olduğu Uygulama
        /// </summary>
        public virtual Applications Applications { get; set; }


    }
}

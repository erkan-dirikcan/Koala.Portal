using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    
    public class CreateApplicationLicencesViewModels
    { 
        /// <summary>
        /// Uygulama Adı (Talep Gelince Uygulama Kendisi Göndeirr)
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationId { get; set; }
       
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar CPU Seri Numarası (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string CpuId { get; set; }
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar Anakart Seri Numarası (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string MainboardId { get; set; }
        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Pasive;
        /// <summary>
        /// Uygulama Lisansının Talep EdildiğiSisteme Eklendiği Tarih
        /// </summary>       

    }
    public class UpdateApplicationLicencesViewModels
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; } = Tools.CreateGuidStr();
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
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        /// <summary>
        /// Uygulama Lisansının Talep EdildiğiSisteme Eklendiği Tarih
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Onaylayan Kullanıcı Id Bilgisi
        /// </summary>
        public string ApprovedByUserId { get; set; }
        /// <summary>
        /// Onaylayan Kullanıcı
        /// </summary>
        public virtual AppUser ApprovedByUser { get; set; }
        /// <summary>
        /// Lisansın Dahil Olduğu Uygulama
        /// </summary>
        public virtual Applications Applications { get; set; }
    }
    public class DetailApplicationLicencesViewModels
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ApplicationName { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationId { get; set; }
        public string LicenceCode { get; set; }
        public string PcName { get; set; }
        public string CpuId { get; set; }
        public string MainboardId { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public string CreateDate { get; set; }
        public UserInfoViewModel ApprovedByUser { get; set; }
    }
    public class ApplicationLicencesListViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
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
        /// Uygulama İçin İzin Verilen Aktif Lisans Sayısı
        /// </summary>
        public int MaxUserCount { get; set; }
        /// <summary>
        /// Uygulamanın Aktif Lisans Sayısı
        /// </summary>
        public int ActiveUserCount { get; set; }
        /// <summary>
        /// Uygulamanın Çalışacağı Bilgisayar Adı (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string PcName { get; set; }
        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Uygulama Lisansının Talep EdildiğiSisteme Eklendiği Tarih
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Onaylayan Kullanıcı Id Bilgisi
        /// </summary>
        public UserListViewModel? ApprovedByUser { get; set; }
    }
    public class ApplicationLicencesRequestViewModel
    {
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationGuid { get; set; }
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
        /// Lisansın Sahibi Olan CRM Firması
        /// </summary>
        public string? LisansFirmId { get; set; }

    }
    public class LicanceCryptionJosonViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ApplicationName { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationId { get; set; }

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
        /// Uygualama Son Kullanım Tarihi
        /// </summary>
        public DateTime? ExpDate { get; set; }
        /// <summary>
        /// Çoklu modül lisansı barındıran uygulamalar için kullanılır.
        /// </summary>
        public string? ModulesCryptedJson { get; set; }

        public bool IsActive { get; set; }
        public ApplicationLicenceStatusEnum ApplicationLicenceStatus { get; set; }
    }
    public class ConfirmApplicationLicencesViewModel
    {

        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; } = Tools.CreateGuidStr();
        /// <summary>
        /// Onaylayan Kullanıcı Id Bilgisi
        /// </summary>
        public string? ApprovedByUserId { get; set; }
        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; }
        public ApplicationLicenceStatusEnum ApplicationLicenceStatus { get; set; }

    }
    public class ApplicationCheckLicenceViewModel
    {

        public string? LicenceCode { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi (Telep Gelince Uygulama Kendisi Gönderir)
        /// </summary>
        public string ApplicationId { get; set; }

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
    }

    public class ApplicationLicenceCountViewModel
    {
        public string Id { get; set; }
        public int ActiveLicanceCount{ get; set; }
        public int MaxLicanceCount { get; set; }
    }

    public class ApiLicenceResultViewModel
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool Approved { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Code { get; set; }


    }
}

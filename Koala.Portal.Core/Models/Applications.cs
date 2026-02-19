using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class Applications
    {
        public Applications()
        {
            ApplicationLicences = new HashSet<ApplicationLicences>();
        }
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; } = Tools.CreateGuidStr();
        /// <summary>
        /// Uygulama Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Uygulama Açıklaması
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Uygulama Guid Bilgisi
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi
        /// </summary>
        public DateTime? ExpDate { get; set; }
        /// <summary>
        /// En Fazla Kullanıcı Sayısı
        /// </summary>
        public int MaxUserCount { get; set; }
        /// <summary>
        /// Uygulama Şifreleme algoritması Secret Key
        /// </summary>
        public string ApplicationSecretKey { get; set; }
        /// <summary>
        /// Uygulama birden fazla firmaya lisanslanan paket uygulama ise True Değeri alır
        /// </summary>
        public bool IsPackageApplication { get; set; }
        /// <summary>
        /// Uygulama birden çok modül barındırıyor ise ve her modül sayısı Lisans ile belirleniyor ise True değeri alır.
        /// </summary>
        public bool IsMultiModuleApplication { get; set; }

        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; } =  StatusEnum.Active;
        /// <summary>
        /// Kullanılan Uygulama Lisansları
        /// </summary>
        public virtual ICollection<ApplicationLicences> ApplicationLicences { get; set; }
        /// <summary>
        /// Çoklu Kullanımda Kullanan Firmalar
        /// </summary>
        public virtual ICollection<ApplicationFirms> Firms { get; set; }
        /// <summary>
        /// Uygulama İçerisinde Barındırılan Modüller
        /// </summary>
        public virtual ICollection<ApplicationModules> Modules { get; set; }

        public int GetActiveUserCount()
        {
            var count = ApplicationLicences.Count(x => x.Status == StatusEnum.Active);
            return count;
        }
    }
}

using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ApplicationsListViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Uygulama Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Uygulama Açıklaması
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi
        /// </summary>
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// En Fazla Kullanıcı Sayısı
        /// </summary>
        public int MaxUserCount { get; set; }
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
        public StatusEnum Status { get; set; }

    }
    public class CreateApplicationsViewModel
    {
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
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// En Fazla Kullanıcı Sayısı
        /// </summary>
        public int MaxUserCount { get; set; }
        /// <summary>
        /// Uygulama birden çok modül barındırıyor ise ve her modül sayısı Lisans ile belirleniyor ise True değeri alır.
        /// </summary>
        public bool IsMultiModuleApplication { get; set; }
        /// <summary>
        /// Uygulama birden fazla firmaya lisanslanan paket uygulama ise True Değeri alır
        /// </summary>
        public bool IsPackageApplication { get; set; }
        /// <summary>
        /// Uygulama Şifreleme algoritması Secret Key
        /// </summary>
        /// 
        public string ApplicationSecretKey { get; set; }
    }

    
    public class UpdateApplicationsViewModel
    {
      
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
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
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// En Fazla Kullanıcı Sayısı
        /// </summary>
        public int MaxUserCount { get; set; }
        /// <summary>
        /// Uygulama birden çok modül barındırıyor ise ve her modül sayısı Lisans ile belirleniyor ise True değeri alır.
        /// </summary>
        public bool IsMultiModuleApplication { get; set; }
        /// <summary>
        /// Uygulama birden fazla firmaya lisanslanan paket uygulama ise True Değeri alır
        /// </summary>
        public bool IsPackageApplication { get; set; }
        /// <summary>
        /// Uygulama Şifreleme algoritması Secret Key
        /// </summary>
        /// 
        public string ApplicationSecretKey { get; set; }

    }
    public class ApplicationsChangeStatusViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Uygulama Durumu
        /// </summary>
        public StatusEnum Status { get; set; }
    }
    public class DetailApplicationsViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Uygulama Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Uygulama Açıklaması
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi
        /// </summary>
        public DateTime ExpDate { get; set; }
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
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Kullanılan Uygulama Lisansları
        /// </summary>
        public List<ApplicationLicencesListViewModel> ApplicationLicences { get; set; }
        public List<ApplicationModulesListViewModel> Modules { get; set; }
    }
    public class ApplicationsAddExpDateViewModel
    {
        /// <summary>
        /// Kimlik Bilgisi
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Uygulama Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Uygulama Açıklaması
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi
        /// </summary>
        public DateTime ExpDate { get; set; }
       
      
    }
}

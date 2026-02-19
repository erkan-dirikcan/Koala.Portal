using Koala.Portal.Core.ViewModels.PortalViewModels;
namespace Koala.Portal.Core.ViewModels.CrmViewModels
{
    public class CreateCrmFirmViewModel
    {
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;

        public List<CreateCrmFirmContacViewModel> Contacts { get; set; }

        public List<CreateCrmPhoneViewModel> Phones { get; set; }
    }

    public class UpdateCrmFirmViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;
        public List<UpdateCrmFirmContactViewModel> Contacts { get; set; }
        public List<UpdateCrmPhoneViewModel> Phones { get; set; }

    }

    public class InfoCrmFirmViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;
        public string? EmailAddress1 { get; set; }
        public List<DetailedInfoCrmFirmContactViewModel> Contacts { get; set; }
        public List<ProjectListViewModel> FirmProjects { get; set; }
        public List<CrmPhonesInfoViewModel> Phones { get; set; }
    }

    public class SupportListInfoCrmFirmViewModel
    {
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;
        public DateTime? LogoSupportExpDate { get; set; }
        public bool LogoSupport { get; set; }
        public DateTime? NewLogoSupportExpDate { get; set; }
        public bool NewLogoSupport { get; set; }
        public DateTime? TecnicalSupportExpDate { get; set; }
        public bool TecnicalSupport { get; set; }
        public DateTime? NewTecnicalSupportExpDate { get; set; }
        public bool NewTecnicalSupport { get; set; }
        public List<DetailedInfoCrmFirmContactViewModel> Contacts { get; set; }
        public List<CrmPhonesInfoViewModel> Phones { get; set; }

    }

    public class CrmPhoneFirmInfoViewModel
    {
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Phone { get; set; }
        public bool InUse { get; set; } = false;
        public DateTime? LogoSupportExpDate { get; set; }
        public bool LogoSupport { get; set; }
        public DateTime? NewLogoSupportExpDate { get; set; }
        public bool NewLogoSupport { get; set; }
        public DateTime? TecnicalSupportExpDate { get; set; }
        public bool TecnicalSupport { get; set; }
        public DateTime? NewTecnicalSupportExpDate { get; set; }
        public bool NewTecnicalSupport { get; set; }

    }

    public class FirmSupportStatusViewModel
    {
        public DateTime? LogoSupportExpDate { get; set; }
        public bool LogoSupport { get; set; }
        public DateTime? NewLogoSupportExpDate { get; set; }
        public bool NewLogoSupport { get; set; }
        public DateTime? TecnicalSupportExpDate { get; set; }
        public bool TecnicalSupport { get; set; }
        public DateTime? NewTecnicalSupportExpDate { get; set; }
        public bool NewTecnicalSupport { get; set; }

    }

    public class CrmFirmListViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }

    public class CrmPhoneNumberListViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string? AreaCode { get; set; }
        public string? Number { get; set; }
        public string? Extension { get; set; }
    }

    //=========================3GX==============================================
    public class GetFirm3cxInfoByPhoneViewModel
    {
        /// <summary>
        /// Telefon Numarası
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Arama Tipi Inbound veya Outbound Olabilir
        /// </summary>
        public string? CallDirection { get; set; } = "Inbound";
    }
    public class GetFirm3cxInfoByEmailViewModel
    {
        public string Email { get; set; }
    }
    public class Firm3cxInfoViewModel
    {
        /// <summary>
        /// Telefon Numarası Crm Id Bilgisi
        /// </summary>
        public string Oid { get; set; }
        /// <summary>
        /// İlişkili Firma Kodu
        /// </summary>
        public string? FirmCode { get; set; }
        /// <summary>
        /// İlişkili Firma Ünvanı
        /// </summary>
        public string? FirmTitle { get; set; }
        /// <summary>
        /// İlişkili Yetkili Adı
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// İlişkili Yetkili Soyadı
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// İlişkili Yetkili E-Posta Adresi
        /// </summary>
        public string? EmailAddress1 { get; set; }
        /// <summary>
        /// Telefon Numarası
        /// </summary>
        public string? Number1 { get; set; }
        /// <summary>
        /// Firma Url Adresi
        /// </summary>
        public string? UrlSlug { get; set; }
        /// <summary>
        /// Yetkili İd Bilgisi
        /// </summary>
        public string? ContactId { get; set; }
    }
}

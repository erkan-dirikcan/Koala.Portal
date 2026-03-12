using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AddProjectLineWorkViewModel
    {
        public string LineId { get; set; }
        public string? CreateUserId { get; set; }
        /// <summary>
        /// İş Firma Yetkilisi
        /// </summary>
        public string? LineFirmOfficialId { get; set; }
        /// <summary>
        /// İş Adı
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Rapor Açıklaması
        /// </summary>
        public string? ReportDescription { get; set; }
        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Servis Süresinden Düşsün mü?
        /// </summary>
        public bool LetTimeDeduct { get; set; } = false;
        /// <summary>
        /// Öncelik
        /// </summary>
        public PriorityEnum Priority { get; set; }
        /// <summary>
        /// Sıra Numarası
        /// </summary>
        public int RowOrder { get; set; } = 0;
        /// <summary>
        /// İş Yapacak Personel ID
        /// </summary>
        public string? AssignedTo { get; set; }
        /// <summary>
        /// İş Yapacak Personel CRM OID
        /// </summary>
        public string? AssignedToCrmOid { get; set; }
        /// <summary>
        /// Departman OID
        /// </summary>
        public string? DepartmentOid { get; set; }
        /// <summary>
        /// Destek Kaydı Oluşturulsun mu?
        /// </summary>
        public bool CreateSupportTicket { get; set; } = false;

        /// <summary>
        /// Tahmini Süre (Dakika)
        /// </summary>
        public int? EstimatedTime { get; set; }
        /// <summary>
        /// İlişki Destek Kaydı
        /// </summary>
        public CrmCreateSupportViewModel? ReleatedSupport { get; set; }
        /// <summary>
        /// Çalışan Kullanıcılar
        /// </summary>
        public List<AddProjectPersonViewModel>? WorkPersons { get; set; }
    }
    public class UpdateProjectLineWorkViewModel
    {
        public string Id { get; set; }
        public string? LastUpdateUserId { get; set; }
        /// <summary>
        /// İş Firma Yetkilisi
        /// </summary>
        public string? LineFirmOfficialId { get; set; }
        /// <summary>
        /// İş Adı
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Servis Süresinden Düşsün mü?
        /// </summary>
        public bool LetTimeDeduct { get; set; }
        /// <summary>
        /// Öncelik
        /// </summary>
        public PriorityEnum Priority { get; set; }
        /// <summary>
        /// Sıra Numarası
        /// </summary>
        public int RowOrder { get; set; }
        /// <summary>
        /// Tahmini Süre (Dakika)
        /// </summary>
        public int? EstimatedTime { get; set; }
        /// <summary>
        /// Harcanan Süre (Dakika)
        /// </summary>
        public int? TimeSpend { get; set; }
        /// <summary>
        /// İş Durumu
        /// </summary>
        public ProjectLineWorkStatusEnum WorkStatus { get; set; }
        /// <summary>
        /// İptal Açıklaması
        /// </summary>
        public string? CancelDescription { get; set; }
        /// <summary>
        /// Çalışan Kullanıcılar
        /// </summary>
        public List<AddProjectPersonViewModel>? WorkPersons { get; set; }
    }
    public class ProjectLineWorkDetailViewModel
    {
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();
        public string LineId { get; set; }
        public string Line { get; set; }
        /// <summary>
        /// İş Firma Yetkilisi
        /// </summary>
        public string? LineFirmOfficialId { get; set; }
        public string? LineFirmOfficialName { get; set; }
        /// <summary>
        /// Teslim Edilen Firma Çalışanı
        /// </summary>
        public string? DeliveredPersonOid { get; set; }
        public string? DeliveredPersonName { get; set; }
        /// <summary>
        /// İş Adı
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Rapor Açıklaması, İş Tamamlandıktan Sonra İşi Kapatan Tarafından Yazılır
        /// </summary>
        public string? ReportDescription { get; set; }
        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Harcanan Süre
        /// </summary>
        public int? TimeSpend { get; set; }
        /// <summary>
        /// Servis Süresinden Düşsün mü?
        /// </summary>
        public bool LetTimeDeduct { get; set; } = false;
        /// <summary>
        /// İş Durumu
        /// </summary>
        public ProjectLineWorkStatusEnum WorkStatus { get; set; }
        /// <summary>
        /// Öncelik
        /// </summary>
        public PriorityEnum Priority { get; set; } = PriorityEnum.Normal;
        /// <summary>
        /// İptal Açıklaması
        /// </summary>
        public string? CancelDescription { get; set; }
        /// <summary>
        /// Sıra Numarası
        /// </summary>
        public int RowOrder { get; set; } = 0;
        /// <summary>
        /// İlişki Destek Kaydı
        /// </summary>
        public List<CrmSupportListViewModel> ReleatedSupport { get; set; }
        /// <summary>
        /// Çalışan Kullanıcılar
        /// </summary>
        public List<AddProjectPersonViewModel>? WorkPersons { get; set; }
    }
    public class ProjectLineWorkListViewModel
    {
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();

        public string? LineFirmOfficial { get; set; }
        /// <summary>
        /// Teslim Edilen Firma Çalışanı
        /// </summary>
        public string? DeliveredPerson { get; set; }
        /// <summary>
        /// İş Adı
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Rapor Açıklaması
        /// </summary>

        public int? TimeSpend { get; set; }
        /// <summary>
        /// Tahmini Süre (Dakika)
        /// </summary>
        public int? EstimatedTime { get; set; }
        /// <summary>
        /// Servis Süresinden Düşsün mü?
        /// </summary>
        public bool LetTimeDeduct { get; set; } = false;
        /// <summary>
        /// İş Durumu
        /// </summary>
        public ProjectLineWorkStatusEnum WorkStatus { get; set; }
        /// <summary>
        /// Öncelik
        /// </summary>
        public PriorityEnum Priority { get; set; } = PriorityEnum.Normal;
        /// <summary>
        /// İptal Açıklaması
        /// </summary>
        public string? CancelDescription { get; set; }
        /// <summary>
        /// Sıra Numarası
        /// </summary>
        public int RowOrder { get; set; }
    }
    public class ProjectLineWorkChangeStateViewModel
    {
        public string Id { get; set; }
        public ProjectLineWorkStatusEnum WorkStatus { get; set; }
        public string UpdateUserId { get; set; }
    }
    public class ProjectLineWorkComplateViewModel
    {
        public string Id { get; set; }
        /// <summary>
        /// Teslim Edilen Firma Çalışanı
        /// </summary>
        public string? DeliveredPersonOid { get; set; }
        /// <summary>
        /// Rapor Açıklaması
        /// </summary>
        public string? ReportDescription { get; set; }
        /// <summary>
        /// Son Güncelleme Yapan Kullanıcı
        /// </summary>
        public string UpdateUserId { get; set; }
    }
}

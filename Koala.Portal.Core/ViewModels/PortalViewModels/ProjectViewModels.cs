using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ProjectListViewModel
    {
        public string Id { get; set; }
        /// <summary>
        /// Proje Kodu
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Proje Adı
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Proje Açıklaması
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Proje Yöneticisi
        /// </summary>
        public string? ProjectManager { get; set; }
        /// <summary>
        /// Proje Firması
        /// </summary>
        public string Firm { get; set; }
        /// <summary>
        /// Firma Proje Yöneticisi
        /// </summary>
        public string? FirmPerson { get; set; }
        /// <summary>
        /// Proje Başlama Zamanı
        /// </summary>
        public string? StartDate { get; set; }
        /// <summary>
        /// Proje Termin Tarihi
        /// </summary>
        public string? DueDate { get; set; }
        /// <summary>
        /// Proje Durum Kodu
        /// </summary>
        public ProjectStatusEnum ProjectStatus { get; set; } = ProjectStatusEnum.Created;


    }
    public class AddProjectViewModel
    {
        /// <summary>
        /// Proje Adı
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Proje Açıklaması
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Proje Yöneticisi
        /// </summary>
        public string? ProjectManagerId { get; set; }
        /// <summary>
        /// Proje Firması
        /// </summary>
        public string FirmId { get; set; }
        /// <summary>
        /// Firma Proje Yöneticisi
        /// </summary>
        public string? FirmPersonId { get; set; }
        /// <summary>
        /// Taahüt Edilen Eğitim, Destek, Rapor Hazırlama Süresi
        /// </summary>
        public int? ServiceHour { get; set; }
        /// <summary>
        /// Proje Termin Tarihi
        /// </summary>
        public string? DueDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime CreateTime { get; set; }

    }
    public class UpdateProjectViewModel
    {
        public string Id { get; set; }
        /// <summary>
        /// Proje Adı
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Proje Açıklaması
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Proje Yöneticisi
        /// </summary>
        public string? ProjectManagerId { get; set; }
        /// <summary>
        /// Proje Firması
        /// </summary>
        public string FirmId { get; set; }
        /// <summary>
        /// Firma Proje Yöneticisi
        /// </summary>
        public string? FirmPersonId { get; set; }
        /// <summary>
        /// Taahüt Edilen Eğitim, Destek, Rapor Hazırlama Süresi
        /// </summary>
        public int? ServiceHour { get; set; }
        /// <summary>
        /// Proje Termin Tarihi
        /// </summary>
        public string? DueDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    public class ProjectDetailViewModel
    {
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();
        /// <summary>
        /// Proje Kodu
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Proje Adı
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Proje Açıklaması
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Proje Yöneticisi
        /// </summary>
        public string? ProjectManagerId { get; set; }
        /// <summary>
        /// Proje Firması
        /// </summary>
        public string FirmId { get; set; }
        /// <summary>
        /// Firma Proje Yöneticisi
        /// </summary>
        public string? FirmPersonId { get; set; }
        /// <summary>
        /// Taahüt Edilen Eğitim, Destek, Rapor Hazırlama Süresi
        /// </summary>
        public int? ServiceHour { get; set; }
        /// <summary>
        /// Toplam Harcanan Süre
        /// </summary>
        public int? EstimatedHour { get; set; }
        /// <summary>
        /// İptal Açıklaması
        /// </summary>
        public string? CancelDescription { get; set; }
        /// <summary>
        /// Proje Başlama Zamanı
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Proje Bitiş Zamanı
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Proje Termin Tarihi
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Proje Durum Kodu
        /// </summary>
        public ProjectStatusEnum ProjectStatus { get; set; } = ProjectStatusEnum.Created;
        /// <summary>
        /// Proje Devam Durumu
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Active;


        public UserListViewModel? ProjectManager { get; set; }
        public CrmFirmListViewModel Firm { get; set; }
        public CrmFirmContactListViewModel? FirmPerson { get; set; }

        public List<ProjectFilesListViewModel> ProjectFiles { get; set; }
        public List<ProjectLineListViewModel> ProjectLines { get; set; }
    }
    public class ProjectChanegeStatusViewModel
    {
        public string Id { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public StatusEnum Status { get; set; }
    }
    public class ProjectChanegeStateStatusViewModel
    {
        public string Id { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public ProjectStatusEnum ProjectStatus { get; set; }
    }

    /// <summary>
    /// Project List Filters ViewModel - for filtering projects in Index page
    /// </summary>
    public class ProjectListFiltersViewModel
    {
        public string? StatusFilter { get; set; }
        public string? ManagerFilter { get; set; }
        public string? FirmFilter { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SearchTerm { get; set; }
    }
}

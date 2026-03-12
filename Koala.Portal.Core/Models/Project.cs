using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class Project : CommonProperty
    {
        public Project()
        {
            ProjectFiles = new HashSet<ProjectFiles>();
            ProjectLines=new HashSet<ProjectLine>();
        }

        public string Id { get; set; } = Tools.CreateGuidStr();
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
        public StatusEnum Status { get; set; }  = StatusEnum.Active;


        public virtual AppUser? ProjectManager { get; set; }
        public virtual ICollection<ProjectFiles> ProjectFiles { get; set; }
        public virtual ICollection<ProjectLine> ProjectLines { get; set; }

        public string GetManagerFullName()
        {
            return ProjectManager != null ? $"{ProjectManager.Name} {ProjectManager.Lastname}" : "";
        }
        public string GetFirmPersonFullName()
        {
            return ""; // Service katmanında doldurulacak
        }
        public string? GetFirmDisplayName()
        {
            return ""; // Service katmanında doldurulacak
        }
        public string? GetStartDateStr()
        {
            return StartDate?.ToString("dd-MM-yyyy");
        }
        public string? GetEndDateStr()
        {
            return EndDate?.ToString("dd-MM-yyyy");
        }
        public string? GetDueDateStr()
        {
            return DueDate?.ToString("dd-MM-yyyy");
        }
    }
}

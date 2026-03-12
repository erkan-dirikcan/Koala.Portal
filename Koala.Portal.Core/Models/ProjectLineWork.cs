using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ProjectLineWork : CommonProperty
    {
        public ProjectLineWork()
        {
            WorkPersons = new HashSet<ProjectPerson>();
            UpdateUser = CreateUser;
            UpdateTime = CreateTime;
        }
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();
        public string LineId { get; set; }
        public string? ReleatedSupportId { get; set; }
        public string? ReleatedSupportOid { get; set; }

        /// <summary>
        /// İş Firma Yetkilisi
        /// </summary>
        public string? LineFirmOfficialId { get; set; }
        /// <summary>
        /// Teslim Edilen Firma Çalışanı
        /// </summary>
        public string? DeliveredPersonOid { get; set; }
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
        /// Harcanan Süre (Dakika)
        /// </summary>
        public int? TimeSpend { get; set; }
        /// <summary>
        /// Tahmini Süre (Dakika)
        /// </summary>
        public int? EstimatedTime { get; set; }
        /// <summary>
        /// Servis Süresinden Düşsün mü?
        /// </summary>
        public bool LetTimeDeduct { get; set; }=false;
        /// <summary>
        /// İş Durumu
        /// </summary>
        public ProjectLineWorkStatusEnum WorkStatus { get; set; } = ProjectLineWorkStatusEnum.NotStarted;
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
        public int RowOrder { get; set; }=0;

        public ProjectLine Line { get; set; }
        /// <summary>
        /// Çalışan Kullanıcılar
        /// </summary>
        public virtual ICollection<ProjectPerson> WorkPersons { get; set; }

    }
}

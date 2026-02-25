using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ProjectLine : CommonProperty
    {
        public ProjectLine()
        {
            LineWorks=new HashSet<ProjectLineWork>();
            LineNotes = new HashSet<ProjectLineNote>();
        }
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();
        public string ProjectId { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? Title { get; set; }
        /// <summary>
        /// Rapar Açıklaması, Fazda Tamamlandıktan Sonra Faz Sorunlusu Tarafından Yazılır.
        /// </summary>
        public string? ReportDescription { get; set; }
        /// <summary>
        /// Faz Açıklaması
        /// </summary>
        public string? Description { get; set; }
        public int? ServiceTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }= PriorityEnum.Normal;
        public ProjectLineStatusEnum StateStatus { get; set; } = ProjectLineStatusEnum.NotStarted;
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public string? CancelDescription { get; set; }
        public int? RowOrdwer { get; set; }


        public virtual Project Project { get; set; }
        public virtual AppUser? LineOffcial { get; set; }
        public virtual CrmFirmContact? LineFirmOfficial { get; set; }

        public virtual ICollection<ProjectLineWork> LineWorks { get; set; }
        public virtual ICollection<ProjectLineNote> LineNotes { get; set; }

        public string GetManagerFullName()
        {
            return $"{LineOffcial?.Name} {LineOffcial?.Lastname}";
        }
        public string GetFirmPersonFullName()
        {
            return $"{LineFirmOfficial?.Name} {LineFirmOfficial?.LastName}";
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

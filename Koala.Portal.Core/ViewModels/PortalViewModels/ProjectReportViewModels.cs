using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    /// <summary>
    /// Project completion report showing overall progress
    /// </summary>
    public class ProjectCompletionReportViewModel
    {
        public string ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Firm { get; set; }
        public string ProjectManager { get; set; }
        public ProjectStatusEnum ProjectStatus { get; set; }
        public string StatusDisplay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ServiceHour { get; set; }
        public int? EstimatedHour { get; set; }

        // Project Lines Statistics
        public int TotalLines { get; set; }
        public int CompletedLines { get; set; }
        public int InProgressLines { get; set; }
        public int NotStartedLines { get; set; }
        public decimal CompletionPercentage { get; set; }

        // Work Items Statistics
        public int TotalWorks { get; set; }
        public int CompletedWorks { get; set; }
        public int InProgressWorks { get; set; }
    }

    /// <summary>
    /// Team workload report showing work distribution
    /// </summary>
    public class TeamWorkloadReportViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        // Statistics
        public int AssignedLines { get; set; }
        public int CompletedLines { get; set; }
        public int InProgressLines { get; set; }
        public int OverdueLines { get; set; }

        public int AssignedWorks { get; set; }
        public int CompletedWorks { get; set; }
        public int InProgressWorks { get; set; }

        // Projects
        public List<string> ProjectNames { get; set; } = new();
    }

    /// <summary>
    /// Firm project summary report
    /// </summary>
    public class FirmProjectSummaryViewModel
    {
        public string FirmId { get; set; }
        public string FirmName { get; set; }
        public string FirmCode { get; set; }

        // Project Statistics
        public int TotalProjects { get; set; }
        public int ActiveProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int CanceledProjects { get; set; }

        // Total Hours
        public int TotalServiceHours { get; set; }
        public int TotalEstimatedHours { get; set; }

        // Projects List
        public List<FirmProjectItemViewModel> Projects { get; set; } = new();
    }

    public class FirmProjectItemViewModel
    {
        public string ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ServiceHour { get; set; }
    }

    /// <summary>
    /// Timeline data for Gantt chart
    /// </summary>
    public class TimelineViewModel
    {
        public string ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectDueDate { get; set; }

        public List<TimelineItemViewModel> Tasks { get; set; } = new();
    }

    public class TimelineItemViewModel
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? RowOrder { get; set; }
        public ProjectLineStatusEnum Status { get; set; }
        public string StatusDisplay { get; set; }
        public PriorityEnum Priority { get; set; }
        public string AssignedTo { get; set; }

        // Progress calculation
        public decimal Progress { get; set; }
    }

    /// <summary>
    /// Calendar event for project visualization
    /// </summary>
    public class CalendarEventViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Url { get; set; }
        public string Color { get; set; }
        public string Type { get; set; } // "Project" or "ProjectLine"
        public string Status { get; set; }
    }
}

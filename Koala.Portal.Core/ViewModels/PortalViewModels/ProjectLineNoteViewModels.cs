namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ProjectLineNoteViewModel
    {
        public string Id { get; set; }
        public string ProjectLineId { get; set; }
        public string ProjectLineName { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string? Title { get; set; }
        public string? ReportNote { get; set; }
        public string? Note { get; set; }
        public string? Date { get; set; }

    }
    public class AddProjectLineNoteViewModel
    {
        public string ProjectLineId { get; set; }
        public string UserId { get; set; }
        public string? Title { get; set; }
        public string? ReportNote { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }

    }
    public class UpdateProjectLineNoteViewModel
    {
        public string Id { get; set; }
        public string ProjectLineId { get; set; }
        public string UserId { get; set; }
        public string? Title { get; set; }
        public string? ReportNote { get; set; }
        public string? Note { get; set; }
        public DateTime? Date { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}

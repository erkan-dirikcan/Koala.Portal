using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ProjectLineListViewModel
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? LineOfficial { get; set; }
        public string? LineFirmOfficial { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public ProjectLineStatusEnum StateStatus { get; set; }
        public StatusEnum Status { get; set; }
        public string? CancelDescription { get; set; }
        public int? RowOrder { get; set; }

    }
    public class ProjectLineDetailViewModel
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ServiceTime { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public ProjectLineStatusEnum StateStatus { get; set; }
        public StatusEnum Status { get; set; }
        public string? CancelDescription { get; set; }
        public int? RowOrdwer { get; set; }


        public ProjectListViewModel Project { get; set; }
        public UserListViewModel? LineOffcial { get; set; }
        public CrmFirmContactListViewModel? LineFirmOffcial { get; set; }

        public List<ProjectLineWorkListViewModel> LineWorks { get; set; }
        public List<ProjectLineNoteViewModel> LineNotes { get; set; }
    }
    public class AddProjectLineViewModel
    {
        public string ProjectId { get; set; }
        public string? LineOfficialId { get; set; }//
        public string? LineFirmOfficialId { get; set; }//
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }//
        public PriorityEnum Priority { get; set; }//
        public int? RowOrder { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
    }
    public class UpdateProjectLineViewModel
    {
        public string Id { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public int? RowOrdwer { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    public class ProjectLineChangeStateStatusViewModel
    {
        public string Id { get; set; }
        public ProjectLineStatusEnum Status { get; set; }
        public string? CancelDescription { get; set; }
    }
    public class ProjectLineComplateViewModel
    {
        public string Id { get; set; }
        public string? ReportDescription { get; set; }
    }
}


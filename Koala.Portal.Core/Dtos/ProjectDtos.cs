using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.DTOs
{
    #region Project DTOs
    public class CreateProjectDto
    {
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public string? ProjectManagerId { get; set; }
        public string FirmId { get; set; }
        public string? FirmPersonId { get; set; }
        public int? ServiceHour { get; set; }
        public string? DueDate { get; set; }
    }

    public class UpdateProjectDto
    {
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public string? ProjectManagerId { get; set; }
        public string FirmId { get; set; }
        public string? FirmPersonId { get; set; }
        public int? ServiceHour { get; set; }
        public string? DueDate { get; set; }
    }

    public class ProjectDto
    {
        public string Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public string? ProjectManagerId { get; set; }
        public string? ProjectManagerName { get; set; }
        public string FirmId { get; set; }
        public string FirmName { get; set; }
        public string? FirmPersonId { get; set; }
        public int? ServiceHour { get; set; }
        public int? EstimatedHour { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatusEnum ProjectStatus { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string? CreateUser { get; set; }
    }

    public class ProjectListQueryDto
    {
        public string? StatusFilter { get; set; }
        public string? ManagerFilter { get; set; }
        public string? FirmFilter { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
    #endregion

    #region ProjectLine DTOs
    public class CreateProjectLineDto
    {
        public string ProjectId { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; } = PriorityEnum.Normal;
        public int? RowOrder { get; set; }
    }

    public class UpdateProjectLineDto
    {
        public string? LineOfficialId { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public int? RowOrder { get; set; }
    }

    public class ProjectLineDto
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string? LineOfficialId { get; set; }
        public string? LineOfficialName { get; set; }
        public string? LineFirmOfficialId { get; set; }
        public string? LineFirmOfficialName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ServiceTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public ProjectLineStatusEnum StateStatus { get; set; }
        public StatusEnum Status { get; set; }
        public string? CancelDescription { get; set; }
        public int? RowOrder { get; set; }
        public DateTime CreateTime { get; set; }
        public string? CreateUser { get; set; }

        // Navigation properties as DTOs
        public List<ProjectLineWorkDto> LineWorks { get; set; } = new();
        public List<ProjectLineNoteDto> LineNotes { get; set; } = new();
    }

    public class ChangeProjectLineStatusDto
    {
        public ProjectLineStatusEnum Status { get; set; }
        public string? CancelDescription { get; set; }
    }
    #endregion

    #region ProjectLineWork DTOs
    public class CreateProjectLineWorkDto
    {
        public string ProjectLineId { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; } = PriorityEnum.Normal;
        public int? EstimatedHour { get; set; }
        public string? AssignedUserId { get; set; }
    }

    public class UpdateProjectLineWorkDto
    {
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public int? EstimatedHour { get; set; }
        public string? AssignedUserId { get; set; }
    }

    public class ProjectLineWorkDto
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string ProjectLineId { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum Priority { get; set; }
        public int? EstimatedHour { get; set; }
        public int? SpentHour { get; set; }
        public string? AssignedUserId { get; set; }
        public string? AssignedUserName { get; set; }
        public ProjectLineWorkStatusEnum StateStatus { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string? CreateUserId { get; set; }
    }

    public class ChangeProjectLineWorkStatusDto
    {
        public ProjectLineWorkStatusEnum Status { get; set; }
        public string? Description { get; set; }
    }
    #endregion

    #region ProjectLineNote DTOs
    public class CreateProjectLineNoteDto
    {
        public string ProjectLineId { get; set; }
        public string Content { get; set; }
    }

    public class UpdateProjectLineNoteDto
    {
        public string Content { get; set; }
    }

    public class ProjectLineNoteDto
    {
        public string Id { get; set; }
        public string ProjectLineId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public string? CreateUser { get; set; }
    }
    #endregion

    #region Response DTOs
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
    }

    public class PagedResponse<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
    #endregion
}

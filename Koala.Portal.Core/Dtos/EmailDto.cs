namespace Koala.Portal.Core.Dtos
{
    public class ResetPasswordEmailDto
    {
        public ResetPasswordEmailDto()
        {
            
        }
        public ResetPasswordEmailDto(string? name, string? lastname, string email, string resetLink)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            ResetLink = resetLink;
        }

        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; }
        public string ResetLink { get; set; }
    }
    public class CustomEmailDto
    {
        public CustomEmailDto()
        {
            
        }
        public CustomEmailDto(string? name, string? lastname, string email)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
        }

        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; }
    }
    public class ProjectCustomEmailDto
    {
        public ProjectCustomEmailDto()
        {
            
        }
        public ProjectCustomEmailDto(string? name, string? lastname, string? email, string dueDate, string createUser, string createDate, string projectManagerPhones, string firmProjectManager, string firmName, string projectDescription, string projectName, string projectCode, string? projectManagerEmail, string? projectId)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            DueDate = dueDate;
            CreateUser = createUser;
            CreateDate = createDate;
            ProjectManagerPhones = projectManagerPhones;
            FirmProjectManager = firmProjectManager;
            FirmName = firmName;
            ProjectDescription = projectDescription;
            ProjectName = projectName;
            ProjectCode = projectCode;
            ProjectManagerEmail = projectManagerEmail;
            ProjectId = projectId;
        }

        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? FirmName { get; set; }
        public string? FirmProjectManager { get; set; }
        public string? ProjectManagerPhones { get; set; }
        public string? ProjectManagerEmail{ get; set; }
        public string? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public string? DueDate { get; set; }
    }
    public class EmailDto
    {
        public EmailDto()
        {
           
        }
        public EmailDto(string? email, string content, string title)
        {
            Email = email;
            Content = content;
            Title = title;
        }

        public string? Email { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}

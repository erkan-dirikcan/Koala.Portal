namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ProjectPersonDetailViewModel
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? ProjectId { get; set; }
        public string? ProjectLineId { get; set; }
        public string? ProjectLineWorkId { get; set; }
        public string? User { get; set; }
        public string? Project { get; set; }
        public string? ProjectLine { get; set; }
        public string? ProjectLineWork { get; set; }
    }
    public class ProjectPersonListViewModel
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? User { get; set; }
    }

    public class AddProjectPersonViewModel
    {
        public string? UserId { get; set; }
    }
}

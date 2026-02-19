using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class HelpDeskSolitionInfoViewModels
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string HelpDeskProblemId { get; set; }
        public string HelpDeskProblemName { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public bool CustomerCanSee { get; set; } = false;
        public StatusEnum Status { get; set; } = StatusEnum.Active;

    }
    public class HelpDeskSolitionInfoForProblemViewModels
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public bool CustomerCanSee { get; set; } = false;
        public StatusEnum Status { get; set; }

    }
    public class HelpDeskSolitionCreateViewModel
    {
        public string HelpDeskProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        public bool CustomerCanSee { get; set; } = false;
    }
    public class HelpDeskSolitionUpdateViewModel
    {
        public string Id { get; set; }
        public string HelpDeskProblemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        public bool CustomerCanSee { get; set; } = false;
    }
    public class HelpDeskSolitionChangeLikeCountViewModel
    {
        public int Id { get; set; }
    }
    public class HelpDeskSolitionChangeStatusViewModel
    {
        public string Id { get; set; }
        public StatusEnum Status { get; set; }
    }
}

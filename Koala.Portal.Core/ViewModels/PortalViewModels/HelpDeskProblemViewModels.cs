using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class HelpDeskProblemInfoViewModels
    {
        public string Id { get; set; }
        public string? Content { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public List<HelpDeskSolitionInfoViewModels> HelpDeskSolitions { get; set; }
        public List<HelpDeskCategoryInfoViewModels> Categories { get; set; }
    }
    public class HelpDeskProblemDetailInfoViewModels
    {
        public string Id { get; set; }
        public List<HelpDeskCategoryInfoViewModels> Categories { get; set; }

        public string? Content { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public List<HelpDeskSolitionInfoViewModels> HelpDeskSolitions { get; set; }
    }
    public class HelpDeskProblemCreateViewModel
    {
        
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public string? UpdateUser { get; set; }
        public List<string> Categories { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
    }

    public class HelpDeskProblemUpdateViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        public List<string> CategoryId { get; set; }

    }
    public class HelpDeskProblemViewsCountViewModel
    {
        public int Id { get; set; }
    }
    public class HelpDeskProblemChangeStatusViewModel
    {
        public string Id { get; set; }
        public StatusEnum Status { get; set; }
    }
}

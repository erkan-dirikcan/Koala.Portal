using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class HelpDeskCategoryInfoViewModels
    {
        public string Id { get; set; }
        public string? ParentId { get; set; } = null;
        public string? ParentName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public List<HelpDeskProblemInfoViewModels> Problems { get; set; }

    }

    public class HelpDeskCategoryCreateViewModel
    {
        public string Name { get; set; }
        public string? ParentId { get; set; }= null;
        public string Description { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
    }

    public class HelpDeskCategoryUpdateViewModel
    {
        public string Id { get; set; }
        public string? ParentId { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
    }

    public class HelpDeskCategoryChangeStatusViewModel
    {
        public string Id { get; set; }
        public StatusEnum Status { get; set; }
    }

    public class HelpDeskCategoryListViewMode
    {
        public string Id { get; set; }
        public string? ParentId { get; set; }
        string? ParentName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Active;
    }

}

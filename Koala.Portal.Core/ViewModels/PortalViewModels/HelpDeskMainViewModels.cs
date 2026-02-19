namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class HelpDeskCatogoryUserListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SolitionCount { get; set; }

    }

    public class ProblemUserListViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string CreateDate { get; set; }
        public string LastUpdateDate { get; set; }
        public int ViewCount { get; set; }

        public int Count { get; set; }
        public List<HelpDeskCategoryInfoViewModels> Categories { get; set; }
    }

}

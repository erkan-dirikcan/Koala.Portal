using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class GetModuleListViewModels
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public List<ClaimListViewModels> ModuleClaims { get; set; } = new List<ClaimListViewModels>();
    }
   
    public class GetModuleDetailViewModels
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }

    public class CreateModuleListViewModels
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<GetGeneratedIdsListViewModel> GeneratedIds { get; set; }
        public List<ClaimListViewModels> Claims { get; set; }
    }

    public class UpdateModuleViewModels
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public List<GetGeneratedIdsListViewModel>? GeneratedIds { get; set; }
        public List<UpdateClaimViewModels>? Claims { get; set; }
    }
}

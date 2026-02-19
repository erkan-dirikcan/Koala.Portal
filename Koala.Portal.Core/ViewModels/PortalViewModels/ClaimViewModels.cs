using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ClaimListViewModels
    {
        public string Id { get; set; }
        public string ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ClaimListForRoleViewModels
    {
        public string ModuleId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
    public class ClaimListForUserViewModels
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
    public class ClaimListForModuleViewModels
    {
        public string Id { get; set; }
        public string ModuleId { get; set; }
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }


    public class CreateClaimViewModels
    {
        public string ModuleId { get; set; }
        [Display(Name = "Yetki Adı")]
        public string Name { get; set; }
        [Display(Name = "Yetki Görünen Adı")]
        public string DisplayName { get; set; }
        [Display(Name = "Yetki Açıklaması")]
        public string Description { get; set; }

    }
    public class UpdateClaimViewModels
    {
        public string Id { get; set; }
        public string ModuleId { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }


}

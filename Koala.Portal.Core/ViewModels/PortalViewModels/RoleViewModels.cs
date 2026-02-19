using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Role Adı boş bırakılamaz")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Rol Açıklaması boş bırakılamaz")]
        [Display(Name = "Rol Açıklaması")]
        public string Description { get; set; }
    }
    public class UpdateRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Adı boş bırakılamaz")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Rol Açıklaması boş bırakılamaz")]
        [Display(Name = "Rol Açıklaması")]
        public string Description { get; set; }
    }
    public class RoleListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
        [Display(Name = "Rol Açıklaması")]
        public string Description { get; set; }
    }

    public class AsignRoleToUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
        [Display(Name = "Rol Açıklaması")]
        public string Description { get; set; }
        [Display(Name = "Rol Atanmış mı?")]
        public bool IsExist { get; set; }
    }

    public class ClaimListViewModel
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Issuer { get; set; }
    }

    public class AddClaimToRoleViewModel
    {
        public string RoleId { get; set; }
        public List<string> Claims { get; set; }
        //public string ClaimType { get; set; } = "Permission";
        //public string ClaimValue{ get; set;}
        //public string DisplayName { get; set; }
        //public bool Selected { get; set; }
    }
    public class AddClaimToUserViewModel
    {
        public string UserId { get; set; }
        public List<string> ModuleClaims { get; set; }

    }
}

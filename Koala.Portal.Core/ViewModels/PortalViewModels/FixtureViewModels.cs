using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class FixtureListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Araç mı?")]
        public bool IsVehicle { get; set; } = false;
    }
    public class CreateFixtureViewModel
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Araç mı?")]
        public bool IsVehicle { get; set; } = false;
    }
    public class UpdateFixtureViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklma")]
        public string Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Araç mı?")]
        public bool IsVehicle { get; set; } = false;
    }
    public class DetailFixtureViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Araç mı?")]
        public bool IsVehicle { get; set; } = false;
    }
    public class DeleteFixtureViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; } = true;
    }
}

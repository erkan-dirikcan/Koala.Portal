using Koala.Portal.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class VacationTypesViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "İzin Tipinin Adı Olmak Zorundadır")]
        public string Name { get; set; }
        [Display(Name ="Açıklama")]
        [MinLength(10, ErrorMessage = "Açıklama Alanı En Az 10 Karakter Olmak Zorundadır")]
        [Required(ErrorMessage = "İzin Tipinin Açıklaması Olmak Zorundadır")]
        public string Description { get; set; }
        public StatusEnum Status { get; set; }

    }
    public class VacationTypesCreateViewModel
    {
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="İzin Tipinin Adı Olmak Zorundadır")]
        public string Name { get; set; }
        [Display(Name ="Açıklama")]
        [MinLength(10,ErrorMessage ="Açıklama Alanı En Az 10 Karakter Olmak Zorundadır")]
        [Required(ErrorMessage = "İzin Tipinin Açıklaması Olmak Zorundadır")]
        public string Description { get; set; }
    }
    public class VacationTypesChangeStatusViewModel
    {
        public string LineId { get; set; }
        public StatusEnum Status{ get; set; }
    }
}

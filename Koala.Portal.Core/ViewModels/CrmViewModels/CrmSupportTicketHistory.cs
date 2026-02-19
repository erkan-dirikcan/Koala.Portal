using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.CrmViewModels
{
    public class CreateCrmSupportTicketHistoryViewModel
    {
        public string TicketOid { get; set; }
        public string UserOid { get; set; }
        [MinLength(10,ErrorMessage = "Açıklama en az 10 karakter olmak zorundadır")]
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        public string? Description { get; set; }
        public string UpdateUser { get; set; }
    }
}

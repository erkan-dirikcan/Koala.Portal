using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AddVacationHistoryViewModel
    {
        public string? VacationId { get; set; }
        public string Description { get; set; }
        public bool IsAdded { get; set; }
        public string? ReleatedUserId { get; set; }
        public virtual VacationRequest? Vacation { get; set; }
        public virtual AppUser ReleatedUser { get; set; }
    }
    
}

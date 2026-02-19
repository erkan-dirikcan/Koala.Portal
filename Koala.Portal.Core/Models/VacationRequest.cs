using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Models
{
    public class VacationRequest : CommonProperty
    {
        public VacationRequest()
        {
            VacationHistories = new HashSet<VacationHistory>();
        }
        public string Id { get; set; }
        public string? VacationTypeId { get; set; }
        public string? UserId { get; set; }
        public string? ReqNumber { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationStatus Status { get; set; } = VacationStatus.WaitingForApproval;
        public VacationTypes? VacationType { get; set; }
        public virtual AppUser? User { get; set; }
        public string CancelDescription { get; set; }
        public string RevisionDescription { get; set; }
        public int Version { get; set; } = 1;
        public bool DropFromAnnualVaccation { get; set; } = false;
        public int DropFromAnnualVaccationAmount { get; set; }
        public bool PaidVacation { get; set; }=false;
        public virtual ICollection<VacationHistory>? VacationHistories { get; set; }
    }
}

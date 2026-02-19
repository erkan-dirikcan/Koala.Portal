using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class VacationHistory:CommonProperty
    {
        public string Id { get; set; }=Tools.CreateGuidStr();
        public string? VacationId { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Senelik izin eklendiyse eklendi işaretlenir
        /// </summary>
        public bool IsAdded { get; set; }
        public string? ReleatedUserId { get; set; }
        public virtual VacationRequest? Vacation { get; set; }
        public virtual AppUser ReleatedUser { get; set; }
    }
}

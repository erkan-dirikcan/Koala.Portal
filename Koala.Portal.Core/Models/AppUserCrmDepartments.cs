using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AppUserCrmDepartment
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string DepartmanId { get; set; }
        public string AppUserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual CrmDepartment Department { get; set; }

    }
}

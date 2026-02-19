using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class CrmDepartment
    {
        public CrmDepartment()
        {
            DepartmentUsers = new HashSet<AppUserCrmDepartment>();
        }
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string Oid { get; set; }
        public string CrmName { get; set; }
        public string AppName { get; set; }
        public string AppDescription { get; set; }

        public virtual ICollection<AppUserCrmDepartment> DepartmentUsers { get; set; }

    }
}

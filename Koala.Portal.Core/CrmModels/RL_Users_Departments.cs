namespace Koala.Portal.Core.CrmModels;

public partial class RL_Users_Departments
{
    public Guid? DepartmentOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_User_Departments? DepartmentO { get; set; }

    public virtual ST_User? UserO { get; set; }
}

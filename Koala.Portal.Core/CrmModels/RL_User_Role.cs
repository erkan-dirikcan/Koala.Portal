namespace Koala.Portal.Core.CrmModels;

public partial class RL_User_Role
{
    public Guid? RoleOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_Role? RoleO { get; set; }

    public virtual ST_User? UserO { get; set; }
}

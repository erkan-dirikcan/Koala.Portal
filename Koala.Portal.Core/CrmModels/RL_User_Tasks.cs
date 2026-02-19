namespace Koala.Portal.Core.CrmModels;

public partial class RL_User_Tasks
{
    public Guid? TaskOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Task? TaskO { get; set; }

    public virtual ST_User? UserO { get; set; }
}

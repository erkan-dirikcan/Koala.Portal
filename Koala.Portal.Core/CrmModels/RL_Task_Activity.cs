namespace Koala.Portal.Core.CrmModels;

public partial class RL_Task_Activity
{
    public Guid? EventOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}

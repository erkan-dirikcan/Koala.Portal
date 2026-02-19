namespace Koala.Portal.Core.CrmModels;

public partial class RL_Activity_Task
{
    public Guid? ActivityOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}

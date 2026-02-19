namespace Koala.Portal.Core.CrmModels;

public partial class RL_Event_Activity
{
    public Guid? ActivityOid { get; set; }

    public Guid? EventOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual MT_Event? EventO { get; set; }
}

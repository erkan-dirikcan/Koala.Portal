namespace Koala.Portal.Core.CrmModels;

public partial class RL_Event_Contact
{
    public Guid? ContactOid { get; set; }

    public Guid? EventOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? ContactO { get; set; }

    public virtual MT_Event? EventO { get; set; }
}

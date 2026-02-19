namespace Koala.Portal.Core.CrmModels;

public partial class RL_Event_Firm
{
    public Guid? EventOid { get; set; }

    public Guid? FirmOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual MT_Firm? FirmO { get; set; }
}

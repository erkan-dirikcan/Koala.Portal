namespace Koala.Portal.Core.CrmModels;

public partial class RL_Contact_Activity_Other
{
    public Guid? ActivityOid { get; set; }

    public Guid? ContactOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual MT_Contact? ContactO { get; set; }
}

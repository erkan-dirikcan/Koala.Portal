namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Shares
{
    public Guid? DocumentOid { get; set; }

    public Guid? SharesOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Shares? SharesO { get; set; }
}

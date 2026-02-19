namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Firm
{
    public Guid? DocumentOid { get; set; }

    public Guid? FirmOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Firm? FirmO { get; set; }
}

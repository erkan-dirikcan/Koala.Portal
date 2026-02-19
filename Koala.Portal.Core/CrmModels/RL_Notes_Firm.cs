namespace Koala.Portal.Core.CrmModels;

public partial class RL_Notes_Firm
{
    public Guid? FirmOid { get; set; }

    public Guid? NotesOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Firm? FirmO { get; set; }

    public virtual MT_Notes? NotesO { get; set; }
}

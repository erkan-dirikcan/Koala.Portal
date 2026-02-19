namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Contact
{
    public Guid? ContactOid { get; set; }

    public Guid? DocumentOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? ContactO { get; set; }

    public virtual MT_Document? DocumentO { get; set; }
}

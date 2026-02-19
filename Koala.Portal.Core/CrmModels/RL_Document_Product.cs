namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Product
{
    public Guid? DocumentOid { get; set; }

    public Guid? ProductOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Product? ProductO { get; set; }
}

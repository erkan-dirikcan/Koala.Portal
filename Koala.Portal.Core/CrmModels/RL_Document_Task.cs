namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Task
{
    public Guid? DocumentOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class RL_Proposals_Documents
{
    public Guid? DocumentOid { get; set; }

    public Guid? ProposalOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Proposals? ProposalO { get; set; }
}

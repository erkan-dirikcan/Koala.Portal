namespace Koala.Portal.Core.CrmModels;

public partial class RL_Proposal_Task
{
    public Guid? ProposalOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Proposals? ProposalO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}

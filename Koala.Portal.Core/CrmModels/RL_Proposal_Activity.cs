namespace Koala.Portal.Core.CrmModels;

public partial class RL_Proposal_Activity
{
    public Guid? RelatedActivityOid { get; set; }

    public Guid? RelatedProposalsOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? RelatedActivityO { get; set; }

    public virtual MT_Proposals? RelatedProposalsO { get; set; }
}

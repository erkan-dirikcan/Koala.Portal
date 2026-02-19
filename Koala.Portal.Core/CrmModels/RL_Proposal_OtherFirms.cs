namespace Koala.Portal.Core.CrmModels;

public partial class RL_Proposal_OtherFirms
{
    public Guid? OtherRelatedFirms { get; set; }

    public Guid? OtherRelatedProposals { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Firm? OtherRelatedFirmsNavigation { get; set; }

    public virtual MT_Proposals? OtherRelatedProposalsNavigation { get; set; }
}

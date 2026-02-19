namespace Koala.Portal.Core.CrmModels;

public partial class RL_Event_Proposal
{
    public Guid? RelatedEvents { get; set; }

    public Guid? RelatedProposals { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? RelatedEventsNavigation { get; set; }

    public virtual MT_Proposals? RelatedProposalsNavigation { get; set; }
}

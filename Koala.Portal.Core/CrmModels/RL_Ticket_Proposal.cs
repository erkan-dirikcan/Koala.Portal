namespace Koala.Portal.Core.CrmModels;

public partial class RL_Ticket_Proposal
{
    public Guid? RelatedProposalsOid { get; set; }

    public Guid? RelatedTicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Proposals? RelatedProposalsO { get; set; }

    public virtual MT_Ticket? RelatedTicketO { get; set; }
}

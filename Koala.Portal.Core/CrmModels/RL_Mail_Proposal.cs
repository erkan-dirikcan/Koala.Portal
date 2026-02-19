namespace Koala.Portal.Core.CrmModels;

public partial class RL_Mail_Proposal
{
    public Guid? MailOid { get; set; }

    public Guid? RelatedProposalsOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Mail? MailO { get; set; }

    public virtual MT_Proposals? RelatedProposalsO { get; set; }
}

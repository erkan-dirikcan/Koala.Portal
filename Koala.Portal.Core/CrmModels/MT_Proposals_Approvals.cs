namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_Approvals
{
    public Guid Oid { get; set; }

    public Guid? ProposalOid { get; set; }

    public DateTime? ActionDate { get; set; }

    public int? ApprovalState { get; set; }

    public string? RevisalId { get; set; }

    public Guid? ProposalStage { get; set; }

    public int? ProposalState { get; set; }

    public string? Description { get; set; }

    public Guid? SentBy { get; set; }

    public Guid? WaitingFor { get; set; }

    public Guid? ByRule { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Proposal_Approval_Rules? ByRuleNavigation { get; set; }

    public virtual MT_Proposals? ProposalO { get; set; }

    public virtual CT_Proposal_Stages? ProposalStageNavigation { get; set; }

    public virtual ST_User? SentByNavigation { get; set; }

    public virtual ST_User? WaitingForNavigation { get; set; }
}

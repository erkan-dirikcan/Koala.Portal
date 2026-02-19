namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_History
{
    public Guid Oid { get; set; }

    public Guid? ProposalOid { get; set; }

    public string? RevisalId { get; set; }

    public Guid? ProposalStage { get; set; }

    public int? ProposalState { get; set; }

    public string? Description { get; set; }

    public Guid? OpportunityStage { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Opportunity_Stages? OpportunityStageNavigation { get; set; }

    public virtual MT_Proposals? ProposalO { get; set; }

    public virtual CT_Proposal_Stages? ProposalStageNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

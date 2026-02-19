namespace Koala.Portal.Core.CrmModels;

public partial class CT_Proposal_Approval_Rules
{
    public Guid Oid { get; set; }

    public int? Order_ { get; set; }

    public string? RuleDescription { get; set; }

    public bool? IsActive { get; set; }

    public int? Timing { get; set; }

    public string? UserRuleExpression { get; set; }

    public string? RuleType { get; set; }

    public string? RuleExpression { get; set; }

    public Guid? WillBeApprovedBy { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? WillBeApprovedByAlternatives { get; set; }

    public virtual ICollection<MT_Proposals_Approvals> MT_Proposals_Approvals { get; set; } = new List<MT_Proposals_Approvals>();

    public virtual ST_User? WillBeApprovedByNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

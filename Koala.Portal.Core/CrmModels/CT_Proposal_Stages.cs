namespace Koala.Portal.Core.CrmModels;

public partial class CT_Proposal_Stages
{
    public Guid Oid { get; set; }

    public int? _Order { get; set; }

    public string? StageDescription { get; set; }

    public int? PercentComplete { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemPredefined { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals> MT_Proposals_Approvals { get; set; } = new List<MT_Proposals_Approvals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_History> MT_Proposals_History { get; set; } = new List<MT_Proposals_History>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<RL_Proposal_Stage_Criteria> RL_Proposal_Stage_Criteria { get; set; } = new List<RL_Proposal_Stage_Criteria>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

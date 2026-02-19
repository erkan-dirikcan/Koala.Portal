namespace Koala.Portal.Core.CrmModels;

public partial class CT_Proposal_Groups
{
    public Guid Oid { get; set; }

    public string? ProposalGroupName { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public Guid? _TeklifTuru { get; set; }

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }

    public virtual CT_Proposal_Types? _TeklifTuruNavigation { get; set; }
}

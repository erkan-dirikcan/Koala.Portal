namespace Koala.Portal.Core.CrmModels;

public partial class ST_Proposal_Category
{
    public Guid Oid { get; set; }

    public Guid? Parent { get; set; }

    public string? Name { get; set; }

    public Guid? Proposal { get; set; }

    public bool? SystemAdded { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? CategoryType { get; set; }

    public Guid? RelatedRevisal { get; set; }

    public virtual ICollection<ST_Proposal_Category> InverseParentNavigation { get; set; } = new List<ST_Proposal_Category>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ST_Proposal_Category? ParentNavigation { get; set; }

    public virtual MT_Proposals? ProposalNavigation { get; set; }

    public virtual MT_Proposals_Revisals? RelatedRevisalNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

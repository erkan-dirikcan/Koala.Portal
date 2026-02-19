namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_Prepared_Forms
{
    public Guid Oid { get; set; }

    public Guid? RelatedProposal { get; set; }

    public string? RevisalId { get; set; }

    public int? ApprovalState { get; set; }

    public string? FormName { get; set; }

    public Guid? PreparedForm { get; set; }

    public string? Notes { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public bool? Initiated { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? DocumentType { get; set; }

    public string? ActiveRevisalId { get; set; }

    public string? ProposalReportName { get; set; }

    public virtual PO_Prepared_Form? PreparedFormNavigation { get; set; }

    public virtual MT_Proposals? RelatedProposalNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

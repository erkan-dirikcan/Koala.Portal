namespace Koala.Portal.Core.CrmModels;

public partial class EI_Proposal_Relations
{
    public Guid Oid { get; set; }

    public Guid? SetOid { get; set; }

    public Guid? ProposalOid { get; set; }

    public string? Ref { get; set; }

    public string? Code_ { get; set; }

    public int? Target { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Proposals? ProposalO { get; set; }

    public virtual EI_Integration_Sets? SetO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

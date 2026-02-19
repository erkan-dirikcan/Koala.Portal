namespace Koala.Portal.Core.CrmModels;

public partial class AA_CompetitorManagement_Reason
{
    public Guid Oid { get; set; }

    public string? ReasonCode { get; set; }

    public string? ReasonDescription { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Opportunity> MT_Opportunity { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();
}

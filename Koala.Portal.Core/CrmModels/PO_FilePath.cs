namespace Koala.Portal.Core.CrmModels;

public partial class PO_FilePath
{
    public Guid Oid { get; set; }

    public string? FileName { get; set; }

    public string? FullName { get; set; }

    public int? Size { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();
}

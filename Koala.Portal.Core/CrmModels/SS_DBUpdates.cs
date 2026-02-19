namespace Koala.Portal.Core.CrmModels;

public partial class SS_DBUpdates
{
    public Guid Oid { get; set; }

    public string? UpdateIssue { get; set; }

    public bool? IsExecuted { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

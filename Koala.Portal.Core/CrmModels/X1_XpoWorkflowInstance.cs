namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoWorkflowInstance
{
    public int OID { get; set; }

    public string? Owner { get; set; }

    public Guid? InstanceId { get; set; }

    public int? Status { get; set; }

    public string? Content { get; set; }

    public string? Metadata { get; set; }

    public DateTime? ExpirationDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

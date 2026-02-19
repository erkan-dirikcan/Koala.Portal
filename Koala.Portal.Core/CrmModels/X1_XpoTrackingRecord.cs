namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoTrackingRecord
{
    public int OID { get; set; }

    public Guid? InstanceId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Data { get; set; }

    public string? ActivityId { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

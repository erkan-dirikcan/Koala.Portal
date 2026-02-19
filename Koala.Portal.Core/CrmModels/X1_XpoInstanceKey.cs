namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoInstanceKey
{
    public int OID { get; set; }

    public Guid? KeyId { get; set; }

    public Guid? InstanceId { get; set; }

    public string? Properties { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

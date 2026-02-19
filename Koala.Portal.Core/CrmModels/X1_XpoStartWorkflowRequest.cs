namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoStartWorkflowRequest
{
    public Guid Oid { get; set; }

    public string? TargetWorkflowUniqueId { get; set; }

    public string? TargetObjectKey { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? TargetObjectType { get; set; }
}

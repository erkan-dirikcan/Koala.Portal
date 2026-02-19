namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoWorkflowDefinition
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public string? Xaml { get; set; }

    public string? TargetObjectType { get; set; }

    public string? Criteria { get; set; }

    public bool? IsActive { get; set; }

    public bool? AutoStartWhenObjectIsCreated { get; set; }

    public bool? AutoStartWhenObjectFitsCriteria { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? AllowMultipleRuns { get; set; }
}

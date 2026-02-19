namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoUserActivityVersion
{
    public Guid Oid { get; set; }

    public string? WorkflowUniqueId { get; set; }

    public string? Xaml { get; set; }

    public int? Version { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class X1_Analysis
{
    public Guid Oid { get; set; }

    public string? DimensionPropertiesString { get; set; }

    public string? Name { get; set; }

    public string? Criteria { get; set; }

    public string? ObjectTypeName { get; set; }

    public byte[]? ChartSettingsContent { get; set; }

    public byte[]? PivotGridSettingsContent { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

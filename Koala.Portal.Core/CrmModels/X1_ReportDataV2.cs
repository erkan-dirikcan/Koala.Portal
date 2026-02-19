namespace Koala.Portal.Core.CrmModels;

public partial class X1_ReportDataV2
{
    public Guid Oid { get; set; }

    public string? ObjectTypeName { get; set; }

    public byte[]? Content { get; set; }

    public string? Name { get; set; }

    public string? ParametersObjectTypeName { get; set; }

    public bool? IsInplaceReport { get; set; }

    public string? PredefinedReportType { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual ST_Reports? ST_Reports { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class ST_Reports
{
    public Guid Oid { get; set; }

    public int? ReportType { get; set; }

    public string? ReportDescription { get; set; }

    public bool? IsActive { get; set; }

    public int? ERPReportObject { get; set; }

    public string? UserDisplayName { get; set; }

    public bool? IsUpdatedInDB { get; set; }

    public virtual X1_ReportDataV2 OidNavigation { get; set; } = null!;
}

namespace Koala.Portal.Core.CrmModels;

public partial class SS_SavedView_Columns
{
    public Guid Oid { get; set; }

    public Guid? SavedViewOid { get; set; }

    public string? colFieldName { get; set; }

    public string? colCaption { get; set; }

    public bool? colVisible { get; set; }

    public int? colTotalSummaryType { get; set; }

    public int? colGroupSummaryType { get; set; }

    public string? colTotalSummaryFormat { get; set; }

    public string? colGroupSummaryFormat { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

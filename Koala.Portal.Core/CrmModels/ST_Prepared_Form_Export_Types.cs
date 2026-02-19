namespace Koala.Portal.Core.CrmModels;

public partial class ST_Prepared_Form_Export_Types
{
    public Guid Oid { get; set; }

    public string? ExportType { get; set; }

    public string? Description { get; set; }

    public byte[]? Icon { get; set; }

    public string? Extension { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

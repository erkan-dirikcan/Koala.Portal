namespace Koala.Portal.Core.CrmModels;

public partial class ST_Full_Search
{
    public Guid Oid { get; set; }

    public string? SearchText { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleMaps_MapSettings
{
    public Guid Oid { get; set; }

    public Guid? CurrentUser { get; set; }

    public string? MapTypeId { get; set; }

    public int? ZoomValue { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

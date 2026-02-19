namespace Koala.Portal.Core.CrmModels;

public partial class ZD_Search_Extensions
{
    public Guid Oid { get; set; }

    public string TargetType { get; set; } = null!;

    public string ItemProperty { get; set; } = null!;

    public string ItemSubProperty { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? ItemPropertyIsCollection { get; set; }
}

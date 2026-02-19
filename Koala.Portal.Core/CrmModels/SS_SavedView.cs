namespace Koala.Portal.Core.CrmModels;

public partial class SS_SavedView
{
    public Guid Oid { get; set; }

    public string? ViewName { get; set; }

    public string? OwnerView { get; set; }

    public bool? IsDefaultForView { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedByOID { get; set; }

    public string? XMLData { get; set; }

    public string? OwnerViewCaption { get; set; }

    public bool? ShareWithOthers { get; set; }

    public bool? MakeUserDefault { get; set; }

    public bool? MakeEveryOneDefault { get; set; }

    public bool? IsGroupRowVisible { get; set; }

    public bool? AutoExpandAllGroups { get; set; }

    public int? PagerPosition { get; set; }

    public int? PageSize { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

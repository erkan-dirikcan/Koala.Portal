namespace Koala.Portal.Core.CrmModels;

public partial class SS_ListView_Sizes
{
    public Guid Oid { get; set; }

    public Guid? OwnerUser { get; set; }

    public string? ViewId { get; set; }

    public string? ColumnId { get; set; }

    public int? ColumnWidth { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? OwnerUserNavigation { get; set; }
}

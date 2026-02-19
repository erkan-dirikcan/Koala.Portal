namespace Koala.Portal.Core.CrmModels;

public partial class ST_UserShortcuts
{
    public Guid Oid { get; set; }

    public string? ViewType { get; set; }

    public string? TargetType { get; set; }

    public Guid? UserOid { get; set; }

    public int? VisibleIndex { get; set; }

    public string? HeaderColor { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ViewVariant { get; set; }

    public virtual ST_User? UserO { get; set; }
}

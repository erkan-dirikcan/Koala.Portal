namespace Koala.Portal.Core.CrmModels;

public partial class ST_Shortcuts
{
    public Guid Oid { get; set; }

    public string? ShortcutName { get; set; }

    public int? Index_ { get; set; }

    public bool? IsActive { get; set; }

    public string? TargetType { get; set; }

    public string? TargetView { get; set; }

    public string? ImageName { get; set; }

    public int? BadgeType { get; set; }

    public bool? IsFixed { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? Language { get; set; }
}

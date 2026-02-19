namespace Koala.Portal.Core.CrmModels;

public partial class ST_MySummary_Cache
{
    public Guid Oid { get; set; }

    public Guid? _Summary { get; set; }

    public string? _Ref { get; set; }

    public string? _TargetType { get; set; }

    public string? _TargetView { get; set; }

    public int? _Number { get; set; }

    public string? _Description { get; set; }

    public bool? ClickEnabled { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? _ItemRef { get; set; }

    public virtual ST_MySummary? _SummaryNavigation { get; set; }
}

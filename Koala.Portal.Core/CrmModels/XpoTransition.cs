namespace Koala.Portal.Core.CrmModels;

public partial class XpoTransition
{
    public Guid Oid { get; set; }

    public string? Caption { get; set; }

    public Guid? SourceState { get; set; }

    public Guid? TargetState { get; set; }

    public int? Index { get; set; }

    public bool? SaveAndCloseView { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual XpoState? SourceStateNavigation { get; set; }

    public virtual XpoState? TargetStateNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class XpoStateMachine
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public string? TargetObjectType { get; set; }

    public string? StatePropertyName { get; set; }

    public Guid? StartState { get; set; }

    public bool? ExpandActionsInDetailView { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual XpoState? StartStateNavigation { get; set; }

    public virtual ICollection<XpoState> XpoState { get; set; } = new List<XpoState>();
}

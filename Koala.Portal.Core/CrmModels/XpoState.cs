namespace Koala.Portal.Core.CrmModels;

public partial class XpoState
{
    public Guid Oid { get; set; }

    public string? Caption { get; set; }

    public Guid? StateMachine { get; set; }

    public string? MarkerValue { get; set; }

    public string? TargetObjectCriteria { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual XpoStateMachine? StateMachineNavigation { get; set; }

    public virtual ICollection<XpoStateAppearance> XpoStateAppearance { get; set; } = new List<XpoStateAppearance>();

    public virtual ICollection<XpoStateMachine> XpoStateMachine { get; set; } = new List<XpoStateMachine>();

    public virtual ICollection<XpoTransition> XpoTransitionSourceStateNavigation { get; set; } = new List<XpoTransition>();

    public virtual ICollection<XpoTransition> XpoTransitionTargetStateNavigation { get; set; } = new List<XpoTransition>();
}

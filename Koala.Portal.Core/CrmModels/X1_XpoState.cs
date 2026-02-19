namespace Koala.Portal.Core.CrmModels;

public partial class X1_XpoState
{
    public Guid Oid { get; set; }

    public string? Caption { get; set; }

    public Guid? StateMachine { get; set; }

    public string? MarkerValue { get; set; }

    public string? TargetObjectCriteria { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_XpoStateMachine? StateMachineNavigation { get; set; }

    public virtual ICollection<X1_XpoStateAppearance> X1_XpoStateAppearance { get; set; } = new List<X1_XpoStateAppearance>();

    public virtual ICollection<X1_XpoStateMachine> X1_XpoStateMachine { get; set; } = new List<X1_XpoStateMachine>();

    public virtual ICollection<X1_XpoTransition> X1_XpoTransitionSourceStateNavigation { get; set; } = new List<X1_XpoTransition>();

    public virtual ICollection<X1_XpoTransition> X1_XpoTransitionTargetStateNavigation { get; set; } = new List<X1_XpoTransition>();
}

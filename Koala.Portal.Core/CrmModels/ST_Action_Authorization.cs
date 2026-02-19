namespace Koala.Portal.Core.CrmModels;

public partial class ST_Action_Authorization
{
    public Guid Oid { get; set; }

    public Guid? User { get; set; }

    public string? ObjectType { get; set; }

    public string? ActionId { get; set; }

    public string? ChoiceActionId { get; set; }

    public bool? IsDisabled { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? Users { get; set; }

    public string? TargetDataObjectType { get; set; }

    public string? TargetDataCriterion { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}

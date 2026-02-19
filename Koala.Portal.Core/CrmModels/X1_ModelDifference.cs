namespace Koala.Portal.Core.CrmModels;

public partial class X1_ModelDifference
{
    public Guid Oid { get; set; }

    public string? UserId { get; set; }

    public int? Version { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ContextId { get; set; }

    public int? ObjectType { get; set; }

    public string? HistoryCreateActionExecutor { get; set; }

    public DateTime? HistoryCreateDate { get; set; }

    public string? HistoryModifyActionExecutor { get; set; }

    public DateTime? HistoryModifyDate { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<X1_ModelDifferenceAspect> X1_ModelDifferenceAspect { get; set; } = new List<X1_ModelDifferenceAspect>();
}

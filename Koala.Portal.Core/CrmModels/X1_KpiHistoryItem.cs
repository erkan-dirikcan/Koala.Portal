namespace Koala.Portal.Core.CrmModels;

public partial class X1_KpiHistoryItem
{
    public Guid Oid { get; set; }

    public Guid? KpiInstance { get; set; }

    public DateTime? RangeStart { get; set; }

    public DateTime? RangeEnd { get; set; }

    public double? Value { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual X1_KpiInstance? KpiInstanceNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class KpiScorecard
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<KpiScorecardScorecards_KpiInstanceIndicators> KpiScorecardScorecards_KpiInstanceIndicators { get; set; } = new List<KpiScorecardScorecards_KpiInstanceIndicators>();
}

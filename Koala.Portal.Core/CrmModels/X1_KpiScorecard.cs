namespace Koala.Portal.Core.CrmModels;

public partial class X1_KpiScorecard
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<X1_Kpi_Scorecards_Indicators> X1_Kpi_Scorecards_Indicators { get; set; } = new List<X1_Kpi_Scorecards_Indicators>();
}

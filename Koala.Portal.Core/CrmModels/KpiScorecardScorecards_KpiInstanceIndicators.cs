namespace Koala.Portal.Core.CrmModels;

public partial class KpiScorecardScorecards_KpiInstanceIndicators
{
    public Guid? Indicators { get; set; }

    public Guid? Scorecards { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual KpiInstance? IndicatorsNavigation { get; set; }

    public virtual KpiScorecard? ScorecardsNavigation { get; set; }
}

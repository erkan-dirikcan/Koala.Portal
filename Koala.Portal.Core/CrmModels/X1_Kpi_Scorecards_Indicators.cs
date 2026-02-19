namespace Koala.Portal.Core.CrmModels;

public partial class X1_Kpi_Scorecards_Indicators
{
    public Guid? Indicators { get; set; }

    public Guid? Scorecards { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual X1_KpiInstance? IndicatorsNavigation { get; set; }

    public virtual X1_KpiScorecard? ScorecardsNavigation { get; set; }
}

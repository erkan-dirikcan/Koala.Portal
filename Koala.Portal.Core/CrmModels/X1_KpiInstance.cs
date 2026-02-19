namespace Koala.Portal.Core.CrmModels;

public partial class X1_KpiInstance
{
    public Guid Oid { get; set; }

    public DateTime? ForceMeasurementDateTime { get; set; }

    public Guid? KpiDefinition { get; set; }

    public string? Settings { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_KpiDefinition? KpiDefinitionNavigation { get; set; }

    public virtual ICollection<X1_KpiDefinition> X1_KpiDefinition { get; set; } = new List<X1_KpiDefinition>();

    public virtual ICollection<X1_KpiHistoryItem> X1_KpiHistoryItem { get; set; } = new List<X1_KpiHistoryItem>();

    public virtual ICollection<X1_Kpi_Scorecards_Indicators> X1_Kpi_Scorecards_Indicators { get; set; } = new List<X1_Kpi_Scorecards_Indicators>();
}

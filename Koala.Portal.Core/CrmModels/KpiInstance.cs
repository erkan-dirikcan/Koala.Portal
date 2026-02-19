namespace Koala.Portal.Core.CrmModels;

public partial class KpiInstance
{
    public Guid Oid { get; set; }

    public DateTime? ForceMeasurementDateTime { get; set; }

    public Guid? KpiDefinition { get; set; }

    public string? Settings { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual KpiDefinition? KpiDefinition1 { get; set; }

    public virtual ICollection<KpiDefinition> KpiDefinitionNavigation { get; set; } = new List<KpiDefinition>();

    public virtual ICollection<KpiHistoryItem> KpiHistoryItem { get; set; } = new List<KpiHistoryItem>();

    public virtual ICollection<KpiScorecardScorecards_KpiInstanceIndicators> KpiScorecardScorecards_KpiInstanceIndicators { get; set; } = new List<KpiScorecardScorecards_KpiInstanceIndicators>();
}

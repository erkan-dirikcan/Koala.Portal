namespace Koala.Portal.Core.CrmModels;

public partial class X1_KpiDefinition
{
    public Guid Oid { get; set; }

    public string? TargetObjectType { get; set; }

    public DateTime? Changed { get; set; }

    public Guid? KpiInstance { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public string? Criteria { get; set; }

    public string? Expression { get; set; }

    public double? GreenZone { get; set; }

    public double? RedZone { get; set; }

    public string? Range { get; set; }

    public bool? Compare { get; set; }

    public string? RangeToCompare { get; set; }

    public int? MeasurementFrequency { get; set; }

    public int? MeasurementMode { get; set; }

    public int? Direction { get; set; }

    public DateTime? ChangedOn { get; set; }

    public string? SuppressedSeries { get; set; }

    public bool? EnableCustomizeRepresentation { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_KpiInstance? KpiInstanceNavigation { get; set; }

    public virtual ICollection<X1_KpiInstance> X1_KpiInstance { get; set; } = new List<X1_KpiInstance>();
}

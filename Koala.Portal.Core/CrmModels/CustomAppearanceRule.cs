namespace Koala.Portal.Core.CrmModels;

public partial class CustomAppearanceRule
{
    public int ID { get; set; }

    public string? CriteriaObjectType { get; set; }

    public string? Criteria { get; set; }

    public string? Method { get; set; }

    public int? ItemType { get; set; }

    public int? AppearanceContext { get; set; }

    public string? TargetItems { get; set; }

    public int? FontStyle { get; set; }

    public int? FontColor { get; set; }

    public int? BackColor { get; set; }

    public int? Priority { get; set; }

    public bool? Enabled { get; set; }

    public int? Visibility { get; set; }

    public int? OptimisticLockField { get; set; }
}

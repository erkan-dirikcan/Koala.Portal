namespace Koala.Portal.Core.CrmModels;

public partial class ST_MySummary_Items
{
    public Guid Oid { get; set; }

    public string? ItemName { get; set; }

    public int? Index_ { get; set; }

    public bool? IsActive { get; set; }

    public string? TargetType { get; set; }

    public int? CriteriaOrView { get; set; }

    public string? Criteria { get; set; }

    public string? TargetView { get; set; }

    public string? LocalizationPath { get; set; }

    public string? LocalizationKey { get; set; }

    public string? DirectText { get; set; }

    public bool? ClickEnabled { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<RL_Users_MySummaryItems> RL_Users_MySummaryItems { get; set; } = new List<RL_Users_MySummaryItems>();
}

namespace Koala.Portal.Core.CrmModels;

public partial class ST_Installed_Apps
{
    public Guid Oid { get; set; }

    public string? ModuleName { get; set; }

    public string? AppName { get; set; }

    public int? StoreId { get; set; }

    public string? TargetType { get; set; }

    public string? TargetView { get; set; }

    public string? ImageName { get; set; }

    public bool? IsFixed { get; set; }

    public bool? IsVisible { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<ST_Installed_Apps_Names> ST_Installed_Apps_Names { get; set; } = new List<ST_Installed_Apps_Names>();
}

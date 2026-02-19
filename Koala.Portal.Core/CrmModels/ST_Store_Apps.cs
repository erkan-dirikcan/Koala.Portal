namespace Koala.Portal.Core.CrmModels;

public partial class ST_Store_Apps
{
    public Guid Oid { get; set; }

    public string? UserName { get; set; }

    public string? AppName { get; set; }

    public int? StoreId { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsInstalled { get; set; }

    public bool? IsVisible { get; set; }

    public byte[]? AppDisplayImage { get; set; }

    public byte[]? AppLargeImage { get; set; }

    public string? AppShortDescription { get; set; }

    public DateTime? AddDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string? AppVersion { get; set; }

    public string? AppSize { get; set; }

    public string? Developer { get; set; }

    public string? Category { get; set; }

    public bool? AppIsFree { get; set; }

    public string? AppIsFreeStr { get; set; }

    public string? AppTrialLimits { get; set; }

    public string? Requirements { get; set; }

    public string? RequiredApp { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

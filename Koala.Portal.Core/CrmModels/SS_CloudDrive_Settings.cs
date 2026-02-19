namespace Koala.Portal.Core.CrmModels;

public partial class SS_CloudDrive_Settings
{
    public Guid Oid { get; set; }

    public Guid? AuthUser { get; set; }

    public string? CloudAuthKey { get; set; }

    public string? CloudType { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? AuthUserNavigation { get; set; }
}

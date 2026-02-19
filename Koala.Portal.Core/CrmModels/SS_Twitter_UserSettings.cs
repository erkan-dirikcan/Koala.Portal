namespace Koala.Portal.Core.CrmModels;

public partial class SS_Twitter_UserSettings
{
    public Guid Oid { get; set; }

    public Guid? User { get; set; }

    public string? AuthKey { get; set; }

    public bool? IsAuthorized { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}

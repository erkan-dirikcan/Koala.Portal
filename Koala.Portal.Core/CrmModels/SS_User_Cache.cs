namespace Koala.Portal.Core.CrmModels;

public partial class SS_User_Cache
{
    public Guid Oid { get; set; }

    public Guid? User { get; set; }

    public string? XAFML1 { get; set; }

    public string? XAFML2 { get; set; }

    public string? XAFML3 { get; set; }

    public string? WebConfig { get; set; }

    public bool? ChangeRole { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class ST_UserMessages
{
    public Guid Oid { get; set; }

    public string? MessageText { get; set; }

    public Guid? User { get; set; }

    public bool? IsSeenMessage { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}

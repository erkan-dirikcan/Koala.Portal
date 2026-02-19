namespace Koala.Portal.Core.CrmModels;

public partial class SS_User_Status
{
    public Guid Oid { get; set; }

    public Guid? User { get; set; }

    public int? Status { get; set; }

    public DateTime? LastDate { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}

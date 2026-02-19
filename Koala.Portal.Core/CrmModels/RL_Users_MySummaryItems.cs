namespace Koala.Portal.Core.CrmModels;

public partial class RL_Users_MySummaryItems
{
    public Guid? MySummaryItemsOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual ST_MySummary_Items? MySummaryItemsO { get; set; }

    public virtual ST_User? UserO { get; set; }
}

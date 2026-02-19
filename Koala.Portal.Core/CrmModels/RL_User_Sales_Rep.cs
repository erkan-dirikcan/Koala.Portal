namespace Koala.Portal.Core.CrmModels;

public partial class RL_User_Sales_Rep
{
    public Guid? SalesRepOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_Sales_Rep? SalesRepO { get; set; }

    public virtual ST_User? UserO { get; set; }
}

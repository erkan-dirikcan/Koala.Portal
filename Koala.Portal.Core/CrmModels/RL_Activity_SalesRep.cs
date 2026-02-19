namespace Koala.Portal.Core.CrmModels;

public partial class RL_Activity_SalesRep
{
    public Guid? SalesRepOid { get; set; }

    public Guid? ActivityOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual CT_Sales_Rep? SalesRepO { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class ST_Activity_Planning
{
    public Guid Oid { get; set; }

    public Guid? FirmOid { get; set; }

    public Guid? SalesRepOid { get; set; }

    public DateTime? ActivityDate { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public Guid? ActivityOid { get; set; }

    public Guid? EventOid { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public Guid? ActivityType { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual CT_Activity_Types? ActivityTypeNavigation { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual MT_Firm? FirmO { get; set; }

    public virtual CT_Sales_Rep? SalesRepO { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class RL_Firm_List_Types
{
    public Guid? ListTypes { get; set; }

    public Guid? FirmOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Firm? FirmO { get; set; }

    public virtual CT_List_Types? ListTypesNavigation { get; set; }
}

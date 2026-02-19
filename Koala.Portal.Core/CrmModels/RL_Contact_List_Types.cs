namespace Koala.Portal.Core.CrmModels;

public partial class RL_Contact_List_Types
{
    public Guid? ListTypes { get; set; }

    public Guid? ContactOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? ContactO { get; set; }

    public virtual CT_List_Types? ListTypesNavigation { get; set; }
}

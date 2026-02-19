namespace Koala.Portal.Core.CrmModels;

public partial class RL_Contact_Actions_Lists
{
    public Guid? ContactActionLists { get; set; }

    public Guid? ContactsOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Action_Lists? ContactActionListsNavigation { get; set; }

    public virtual MT_Contact? ContactsO { get; set; }
}

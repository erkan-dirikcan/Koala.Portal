namespace Koala.Portal.Core.CrmModels;

public partial class RL_Firm_Contacts
{
    public Guid? RelatedContacts { get; set; }

    public Guid? RelatedFirms { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? RelatedContactsNavigation { get; set; }

    public virtual MT_Firm? RelatedFirmsNavigation { get; set; }
}

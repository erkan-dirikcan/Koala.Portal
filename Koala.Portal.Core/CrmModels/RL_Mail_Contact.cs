namespace Koala.Portal.Core.CrmModels;

public partial class RL_Mail_Contact
{
    public Guid? ContactOid { get; set; }

    public Guid? MailOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? ContactO { get; set; }

    public virtual MT_Mail? MailO { get; set; }
}

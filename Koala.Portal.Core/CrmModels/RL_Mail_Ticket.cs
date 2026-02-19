namespace Koala.Portal.Core.CrmModels;

public partial class RL_Mail_Ticket
{
    public Guid? MailOid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Mail? MailO { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }
}

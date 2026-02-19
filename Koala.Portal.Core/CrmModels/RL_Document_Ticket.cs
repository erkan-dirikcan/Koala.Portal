namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Ticket
{
    public Guid? DocumentOid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }
}

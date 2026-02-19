namespace Koala.Portal.Core.CrmModels;

public partial class RL_Ticket_Personnel
{
    public Guid? PersonnelOid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_Personnel? PersonnelO { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }
}

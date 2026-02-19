using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.CrmModels;

public partial class EX_Ticket_History
{
    public Guid Oid { get; set; } = Tools.CreateGuid();

    public string? TicketId { get; set; }

    public Guid? UserOid { get; set; }

    public Guid? TicketOid { get; set; }

    public string? Description { get; set; }

    public DateTime? Date_ { get; set; }
}

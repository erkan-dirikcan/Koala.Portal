namespace Koala.Portal.Core.CrmModels;

public partial class PO_Prepared_Form
{
    public Guid Oid { get; set; }

    public int? size { get; set; }

    public string? FileName { get; set; }

    public byte[]? Content { get; set; }

    public string? FullName { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Proposals_Prepared_Forms> MT_Proposals_Prepared_Forms { get; set; } = new List<MT_Proposals_Prepared_Forms>();

    public virtual ICollection<MT_Ticket_Prepared_Forms> MT_Ticket_Prepared_Forms { get; set; } = new List<MT_Ticket_Prepared_Forms>();
}

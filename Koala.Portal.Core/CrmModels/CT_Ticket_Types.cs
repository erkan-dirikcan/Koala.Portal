namespace Koala.Portal.Core.CrmModels;

public partial class CT_Ticket_Types
{
    public Guid Oid { get; set; }

    public string? TicketTypeDescription { get; set; }

    public bool? IsActive { get; set; }

    public Guid? SubCategory { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual CT_Ticket_Sub_Category? SubCategoryNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

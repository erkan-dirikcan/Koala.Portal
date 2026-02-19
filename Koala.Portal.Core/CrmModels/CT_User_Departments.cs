namespace Koala.Portal.Core.CrmModels;

public partial class CT_User_Departments
{
    public Guid Oid { get; set; }

    public string? DepartmentName { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? DepartmentType { get; set; }

    public virtual ICollection<MT_Task> MT_Task { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<RL_Notes_Departments> RL_Notes_Departments { get; set; } = new List<RL_Notes_Departments>();

    public virtual ICollection<RL_Users_Departments> RL_Users_Departments { get; set; } = new List<RL_Users_Departments>();

    public virtual ICollection<ST_Task_Assign> ST_Task_Assign { get; set; } = new List<ST_Task_Assign>();

    public virtual ICollection<ST_Ticket_Assign> ST_Ticket_Assign { get; set; } = new List<ST_Ticket_Assign>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

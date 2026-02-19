namespace Koala.Portal.Core.CrmModels;

public partial class MT_Task
{
    public Guid Oid { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? StartDate { get; set; }

    public int? Status { get; set; }

    public int? PercentCompleted { get; set; }

    public DateTime? DateCompleted { get; set; }

    public Guid? Owner { get; set; }

    public Guid? TaskFirm { get; set; }

    public Guid? TaskContact { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? AssignedTo { get; set; }

    public Guid? AssignedDepartment { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? RelateToEvent { get; set; }

    public bool? IsProje { get; set; }

    public bool? Gorusme { get; set; }

    public virtual CT_User_Departments? AssignedDepartmentNavigation { get; set; }

    public virtual ST_User? AssignedToNavigation { get; set; }

    public virtual ST_User? OwnerNavigation { get; set; }

    public virtual ICollection<RL_Activity_Task> RL_Activity_Task { get; set; } = new List<RL_Activity_Task>();

    public virtual ICollection<RL_Document_Task> RL_Document_Task { get; set; } = new List<RL_Document_Task>();

    public virtual ICollection<RL_Mail_Task> RL_Mail_Task { get; set; } = new List<RL_Mail_Task>();

    public virtual ICollection<RL_Opportunity_Task> RL_Opportunity_Task { get; set; } = new List<RL_Opportunity_Task>();

    public virtual ICollection<RL_Proposal_Task> RL_Proposal_Task { get; set; } = new List<RL_Proposal_Task>();

    public virtual ICollection<RL_Task_Activity> RL_Task_Activity { get; set; } = new List<RL_Task_Activity>();

    public virtual ICollection<RL_Ticket_Task> RL_Ticket_Task { get; set; } = new List<RL_Ticket_Task>();

    public virtual ICollection<RL_User_Tasks> RL_User_Tasks { get; set; } = new List<RL_User_Tasks>();

    public virtual ICollection<ST_Task_Assign> ST_Task_Assign { get; set; } = new List<ST_Task_Assign>();

    public virtual ICollection<ST_Task_State> ST_Task_State { get; set; } = new List<ST_Task_State>();

    public virtual MT_Contact? TaskContactNavigation { get; set; }

    public virtual MT_Firm? TaskFirmNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

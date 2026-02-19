namespace Koala.Portal.Core.CrmModels;

public partial class MT_Event
{
    public Guid Oid { get; set; }

    public string? ResourceIds { get; set; }

    public Guid? RecurrencePattern { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public DateTime? StartOn { get; set; }

    public DateTime? EndOn { get; set; }

    public bool? AllDay { get; set; }

    public string? Location { get; set; }

    public int? Label { get; set; }

    public int? Status { get; set; }

    public int? Type { get; set; }

    public Guid? Campaign { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public string? RecurrenceInfoXml { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public double? RemindIn { get; set; }

    public string? ReminderInfoXml { get; set; }

    public DateTime? AlarmTime { get; set; }

    public bool? IsPostponed { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? OutlookId { get; set; }

    public string? GoogleId { get; set; }

    public string? GoogleCalendarId { get; set; }

    public bool? IsGoogleEvent { get; set; }

    public string? Google_Attendees { get; set; }

    public string? EventResources { get; set; }

    public Guid? RelatedActivity { get; set; }

    public int? RelateToEvent { get; set; }

    public virtual ICollection<AA_GoogleCalendar_Events> AA_GoogleCalendar_Events { get; set; } = new List<AA_GoogleCalendar_Events>();

    public virtual MT_Campaign? CampaignNavigation { get; set; }

    public virtual ICollection<MT_Event> InverseRecurrencePatternNavigation { get; set; } = new List<MT_Event>();

    public virtual ICollection<MT_Activity> MT_ActivityGoogleEventNavigation { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Activity> MT_ActivityGoogle_MT_EventO { get; set; } = new List<MT_Activity>();

    public virtual ICollection<RI_Event_Product> RI_Event_Product { get; set; } = new List<RI_Event_Product>();

    public virtual ICollection<RL_Document_Event> RL_Document_Event { get; set; } = new List<RL_Document_Event>();

    public virtual ICollection<RL_Event_Activity> RL_Event_Activity { get; set; } = new List<RL_Event_Activity>();

    public virtual ICollection<RL_Event_Contact> RL_Event_Contact { get; set; } = new List<RL_Event_Contact>();

    public virtual ICollection<RL_Event_Firm> RL_Event_Firm { get; set; } = new List<RL_Event_Firm>();

    public virtual ICollection<RL_Event_Proposal> RL_Event_Proposal { get; set; } = new List<RL_Event_Proposal>();

    public virtual ICollection<RL_Event_Users> RL_Event_Users { get; set; } = new List<RL_Event_Users>();

    public virtual ICollection<RL_Opportunity_Event> RL_Opportunity_Event { get; set; } = new List<RL_Opportunity_Event>();

    public virtual ICollection<RL_Product_Event> RL_Product_Event { get; set; } = new List<RL_Product_Event>();

    public virtual ICollection<RL_Task_Activity> RL_Task_Activity { get; set; } = new List<RL_Task_Activity>();

    public virtual ICollection<RL_Ticket_Event> RL_Ticket_Event { get; set; } = new List<RL_Ticket_Event>();

    public virtual MT_Event? RecurrencePatternNavigation { get; set; }

    public virtual MT_Activity? RelatedActivityNavigation { get; set; }

    public virtual ICollection<ST_Activity_Planning> ST_Activity_Planning { get; set; } = new List<ST_Activity_Planning>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

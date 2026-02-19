namespace Koala.Portal.Core.CrmModels;

public partial class MT_Activity
{
    public Guid Oid { get; set; }

    public string? Id { get; set; }

    public string? ActivitySubject { get; set; }

    public Guid? ActivityFirm { get; set; }

    public Guid? ActivityContact { get; set; }

    public Guid? SalesRep { get; set; }

    public int? Priority { get; set; }

    public Guid? ActivityState { get; set; }

    public Guid? ActivityType { get; set; }

    public Guid? ActivityCategory { get; set; }

    public DateTime? ActivityDate { get; set; }

    public DateTime? ActivityRepeatDate { get; set; }

    public Guid? Campaign { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public int? RelateToEvent { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public Guid? Google_MT_EventOid { get; set; }

    public string? Google_Attendees { get; set; }

    public Guid? ActivityFirmAddress { get; set; }

    public bool? CheckIn { get; set; }

    public bool? CheckOut { get; set; }

    public DateTime? CheckInDateTime { get; set; }

    public DateTime? CheckOutDateTime { get; set; }

    public double? CheckInLatitude { get; set; }

    public double? CheckInLongtitude { get; set; }

    public double? CheckOutLatitude { get; set; }

    public double? CheckOutLongtitude { get; set; }

    public Guid? GoogleEvent { get; set; }

    public string? GoogleAttendees { get; set; }

    public bool? UpdateRelatedEvent { get; set; }

    public virtual CT_Activity_Category? ActivityCategoryNavigation { get; set; }

    public virtual MT_Contact? ActivityContactNavigation { get; set; }

    public virtual PO_Address? ActivityFirmAddressNavigation { get; set; }

    public virtual MT_Firm? ActivityFirmNavigation { get; set; }

    public virtual CT_Activity_States? ActivityStateNavigation { get; set; }

    public virtual CT_Activity_Types? ActivityTypeNavigation { get; set; }

    public virtual MT_Campaign? CampaignNavigation { get; set; }

    public virtual MT_Event? GoogleEventNavigation { get; set; }

    public virtual MT_Event? Google_MT_EventO { get; set; }

    public virtual ICollection<MT_Event> MT_Event { get; set; } = new List<MT_Event>();

    public virtual ICollection<RI_Activity_Product> RI_Activity_Product { get; set; } = new List<RI_Activity_Product>();

    public virtual ICollection<RL_Activity_SalesRep> RL_Activity_SalesRep { get; set; } = new List<RL_Activity_SalesRep>();

    public virtual ICollection<RL_Activity_Task> RL_Activity_Task { get; set; } = new List<RL_Activity_Task>();

    public virtual ICollection<RL_Contact_Activity_Other> RL_Contact_Activity_Other { get; set; } = new List<RL_Contact_Activity_Other>();

    public virtual ICollection<RL_Document_Activity> RL_Document_Activity { get; set; } = new List<RL_Document_Activity>();

    public virtual ICollection<RL_Event_Activity> RL_Event_Activity { get; set; } = new List<RL_Event_Activity>();

    public virtual ICollection<RL_Mail_Activity> RL_Mail_Activity { get; set; } = new List<RL_Mail_Activity>();

    public virtual ICollection<RL_Opportunity_Activity> RL_Opportunity_Activity { get; set; } = new List<RL_Opportunity_Activity>();

    public virtual ICollection<RL_Product_Activity> RL_Product_Activity { get; set; } = new List<RL_Product_Activity>();

    public virtual ICollection<RL_Proposal_Activity> RL_Proposal_Activity { get; set; } = new List<RL_Proposal_Activity>();

    public virtual ICollection<RL_Ticket_Activity> RL_Ticket_Activity { get; set; } = new List<RL_Ticket_Activity>();

    public virtual ICollection<ST_Activity_Planning> ST_Activity_Planning { get; set; } = new List<ST_Activity_Planning>();

    public virtual CT_Sales_Rep? SalesRepNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class MT_Contact
{
    public Guid Oid { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? FullName { get; set; }

    public bool? InUse { get; set; }

    public Guid? JobTitle { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? EmailAddress3 { get; set; }

    public string? WebAddress1 { get; set; }

    public string? WebAddress2 { get; set; }

    public Guid? Networks_ { get; set; }

    public Guid? RelatedFirm { get; set; }

    public Guid? SalesRep { get; set; }

    public Guid? MainSector { get; set; }

    public Guid? ContactRole { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public double? Latitude { get; set; }

    public double? Longtitude { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public byte[]? ContactPhoto { get; set; }

    public string? CityOfMainAddress { get; set; }

    public string? CountryOfMainAddress { get; set; }

    public string? MainAddress { get; set; }

    public string? Phones { get; set; }

    public string? Addresses { get; set; }

    public string? FirmaYetkilisi { get; set; }

    public bool? _MXN_InUse { get; set; }

    public string? _MXN_Password { get; set; }

    public string? _MXN_UserName { get; set; }

    public virtual ICollection<AA_Email_Report> AA_Email_Report { get; set; } = new List<AA_Email_Report>();

    public virtual ICollection<AA_GoogleMaps_GeoPoint> AA_GoogleMaps_GeoPoint { get; set; } = new List<AA_GoogleMaps_GeoPoint>();

    public virtual ICollection<AA_Sms_Report> AA_Sms_Report { get; set; } = new List<AA_Sms_Report>();

    public virtual CT_Contact_Roles? ContactRoleNavigation { get; set; }

    public virtual ICollection<EI_Contact_Relations> EI_Contact_Relations { get; set; } = new List<EI_Contact_Relations>();

    public virtual ICollection<EX_Firm_Applications> EX_Firm_Applications { get; set; } = new List<EX_Firm_Applications>();

    public virtual CT_Job_Titles? JobTitleNavigation { get; set; }

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Campaign_Lists> MT_Campaign_Lists { get; set; } = new List<MT_Campaign_Lists>();

    public virtual ICollection<MT_Opportunity> MT_Opportunity { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Task> MT_Task { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Ticket> MT_TicketTicketContact2Navigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket> MT_TicketTicketContactNavigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket> MT_TicketYetkili1Navigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket> MT_TicketYetkili2Navigation { get; set; } = new List<MT_Ticket>();

    public virtual CT_Sectors? MainSectorNavigation { get; set; }

    public virtual PO_Social_Media? Networks_Navigation { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_Phone_Number> PO_Phone_Number { get; set; } = new List<PO_Phone_Number>();

    public virtual ICollection<RI_Contact_Product> RI_Contact_Product { get; set; } = new List<RI_Contact_Product>();

    public virtual ICollection<RL_Contact_Actions_Lists> RL_Contact_Actions_Lists { get; set; } = new List<RL_Contact_Actions_Lists>();

    public virtual ICollection<RL_Contact_Activity_Other> RL_Contact_Activity_Other { get; set; } = new List<RL_Contact_Activity_Other>();

    public virtual ICollection<RL_Contact_List_Types> RL_Contact_List_Types { get; set; } = new List<RL_Contact_List_Types>();

    public virtual ICollection<RL_Contact_Opportunity_Other> RL_Contact_Opportunity_Other { get; set; } = new List<RL_Contact_Opportunity_Other>();

    public virtual ICollection<RL_Document_Contact> RL_Document_Contact { get; set; } = new List<RL_Document_Contact>();

    public virtual ICollection<RL_Event_Contact> RL_Event_Contact { get; set; } = new List<RL_Event_Contact>();

    public virtual ICollection<RL_Firm_Contacts> RL_Firm_Contacts { get; set; } = new List<RL_Firm_Contacts>();

    public virtual ICollection<RL_Mail_Contact> RL_Mail_Contact { get; set; } = new List<RL_Mail_Contact>();

    public virtual ICollection<RL_Notes_Contact> RL_Notes_Contact { get; set; } = new List<RL_Notes_Contact>();

    public virtual MT_Firm? RelatedFirmNavigation { get; set; }

    public virtual ICollection<ST_IPS_Logs> ST_IPS_Logs { get; set; } = new List<ST_IPS_Logs>();

    public virtual CT_Sales_Rep? SalesRepNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

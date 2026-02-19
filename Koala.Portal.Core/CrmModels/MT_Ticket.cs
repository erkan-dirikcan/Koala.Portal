using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.CrmModels;

public partial class MT_Ticket
{
    public Guid Oid { get; set; } = Tools.CreateGuid();

    public string? TicketId { get; set; }

    public string? TicketDescription { get; set; }

    public Guid? TicketMainCategory { get; set; }

    public Guid? TicketSubCategory { get; set; }

    public Guid? TicketType { get; set; }

    public Guid? TicketFirm { get; set; }

    public Guid? TicketContact { get; set; }

    public int? Priority { get; set; }

    public DateTime? TicketStartDate { get; set; }

    public DateTime? TicketEstEndDate { get; set; }

    public Guid? AssignedTo { get; set; }

    public Guid? AssignedDepartment { get; set; }

    public Guid? ActiveWorkingUser { get; set; }

    public Guid? TicketState { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }=DateTime.Now;

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public DateTime? TicketCompletedDate { get; set; }

    public string? TicketYapilanIslem { get; set; }

    public string? TicketUcret { get; set; }

    public byte[]? TicketImage { get; set; }

    public DateTime? TicketTamamlanmaTarihi { get; set; }

    public DateTime? TicketAramaTarihi { get; set; }

    public Guid? TicketContact2 { get; set; }

    public Guid? TicketProposal { get; set; }

    public Guid? TicketProposalProduct { get; set; }

    public string? TwitterId { get; set; }

    public bool? IsTwitterTicket { get; set; }

    public Guid? Yetkili1 { get; set; }

    public bool? IsMainCase { get; set; } = true;

    public string? CaseId { get; set; }

    public Guid? Yetkili2 { get; set; }

    public bool? TicketLogoBakimAnlasmasi { get; set; }

    public bool? TicketTeknikBakimAnlasmasi { get; set; }

    public Guid? FirmaUrun { get; set; }

    public bool? TeknikServis { get; set; }

    public string? FirmaUrunSeriNo { get; set; }

    public string? Notlar { get; set; }

    public string? ReleatedJob { get; set; }

    public string? SpeCode { get; set; }

    public bool? DevamEdiyor { get; set; }

    public string? JiraOrSupportCode { get; set; }

    public DateTime? RegisterDate { get; set; }

    public string? Version { get; set; }

    public string? CurrencyType { get; set; }

    public string? ProjectCode { get; set; }

    public string? ProjectLineId { get; set; }

    public string? ProjectLineWorkId { get; set; }

    public virtual CT_User_Departments? AssignedDepartmentNavigation { get; set; }

    public virtual ST_User? AssignedToNavigation { get; set; }

    public virtual RI_Firm_Product? FirmaUrunNavigation { get; set; }

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Ticket_Prepared_Forms> MT_Ticket_Prepared_Forms { get; set; } = new List<MT_Ticket_Prepared_Forms>();

    public virtual ICollection<RI_Ticket_Product> RI_Ticket_Product { get; set; } = new List<RI_Ticket_Product>();

    public virtual ICollection<RL_Document_Ticket> RL_Document_Ticket { get; set; } = new List<RL_Document_Ticket>();

    public virtual ICollection<RL_Mail_Ticket> RL_Mail_Ticket { get; set; } = new List<RL_Mail_Ticket>();

    public virtual ICollection<RL_Product_Ticket> RL_Product_Ticket { get; set; } = new List<RL_Product_Ticket>();

    public virtual ICollection<RL_Ticket_Activity> RL_Ticket_Activity { get; set; } = new List<RL_Ticket_Activity>();

    public virtual ICollection<RL_Ticket_Event> RL_Ticket_Event { get; set; } = new List<RL_Ticket_Event>();

    public virtual ICollection<RL_Ticket_Personnel> RL_Ticket_Personnel { get; set; } = new List<RL_Ticket_Personnel>();

    public virtual ICollection<RL_Ticket_Proposal> RL_Ticket_Proposal { get; set; } = new List<RL_Ticket_Proposal>();

    public virtual ICollection<RL_Ticket_Task> RL_Ticket_Task { get; set; } = new List<RL_Ticket_Task>();

    public virtual ICollection<ST_Ticket_Assign> ST_Ticket_Assign { get; set; } = new List<ST_Ticket_Assign>();

    public virtual ICollection<ST_Ticket_State> ST_Ticket_State { get; set; } = new List<ST_Ticket_State>();

    public virtual MT_Contact? TicketContact2Navigation { get; set; }

    public virtual MT_Contact? TicketContactNavigation { get; set; }

    public virtual MT_Firm? TicketFirmNavigation { get; set; }

    public virtual CT_Ticket_Main_Category? TicketMainCategoryNavigation { get; set; }

    public virtual MT_Proposals? TicketProposalNavigation { get; set; }

    public virtual MT_Proposals_Products? TicketProposalProductNavigation { get; set; }

    public virtual CT_Ticket_States? TicketStateNavigation { get; set; }

    public virtual CT_Ticket_Sub_Category? TicketSubCategoryNavigation { get; set; }

    public virtual CT_Ticket_Types? TicketTypeNavigation { get; set; }

    public virtual MT_Contact? Yetkili1Navigation { get; set; }

    public virtual MT_Contact? Yetkili2Navigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

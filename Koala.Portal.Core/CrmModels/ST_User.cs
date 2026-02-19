namespace Koala.Portal.Core.CrmModels;

public partial class ST_User
{
    public Guid Oid { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }

    public bool? ChangePasswordOnFirstLogon { get; set; }

    public string? StoredPassword { get; set; }

    public int? UserLanguage { get; set; }

    public int? Gender { get; set; }

    public string? AvatarUrl { get; set; }

    public string? EMailAddress { get; set; }

    public string? ERPUserName { get; set; }

    public int? OleColor { get; set; }

    public string? Caption { get; set; }

    public int? ProposalSync { get; set; }

    public Guid? DefaultIntegrationSet { get; set; }

    public string? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public string? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public string? AgentId { get; set; }

    public string? Extension { get; set; }

    public int? CallerIdAction { get; set; }

    public string? DeviceToken { get; set; }

    public string? MailChimpAPIKey { get; set; }

    public bool? LoadDescribe { get; set; }

    public bool? UseMobile { get; set; }

    public string? NetsisDefaultBranchCode { get; set; }

    public int? ERPActionOnSaveFirm { get; set; }

    public int? ERPActionOnSaveProduct { get; set; }

    public string? ERPPassword { get; set; }

    public bool? IsActiveRecord { get; set; }

    public bool? IsSystemAdministrator { get; set; }

    public bool? _MXN_PortalUser { get; set; }

    public string? MySummaryToolbarColor { get; set; }

    public string? MySummaryHeaderFilterButtons { get; set; }

    public virtual ICollection<AA_CompetitorManagement_UserSettings> AA_CompetitorManagement_UserSettings { get; set; } = new List<AA_CompetitorManagement_UserSettings>();

    public virtual ICollection<AA_GoogleCalendar_Events> AA_GoogleCalendar_Events { get; set; } = new List<AA_GoogleCalendar_Events>();

    public virtual ICollection<AA_GoogleCalendar_UserSettings> AA_GoogleCalendar_UserSettings { get; set; } = new List<AA_GoogleCalendar_UserSettings>();

    public virtual ICollection<AA_GoogleMaps_Nearby> AA_GoogleMaps_Nearby { get; set; } = new List<AA_GoogleMaps_Nearby>();

    public virtual ICollection<CT_Activity_Category> CT_Activity_Category_CreatedByNavigation { get; set; } = new List<CT_Activity_Category>();

    public virtual ICollection<CT_Activity_Category> CT_Activity_Category_LastModifiedByNavigation { get; set; } = new List<CT_Activity_Category>();

    public virtual ICollection<CT_Activity_States> CT_Activity_States_CreatedByNavigation { get; set; } = new List<CT_Activity_States>();

    public virtual ICollection<CT_Activity_States> CT_Activity_States_LastModifiedByNavigation { get; set; } = new List<CT_Activity_States>();

    public virtual ICollection<CT_Activity_Types> CT_Activity_Types_CreatedByNavigation { get; set; } = new List<CT_Activity_Types>();

    public virtual ICollection<CT_Activity_Types> CT_Activity_Types_LastModifiedByNavigation { get; set; } = new List<CT_Activity_Types>();

    public virtual ICollection<CT_Campaign_Cost_Types> CT_Campaign_Cost_Types_CreatedByNavigation { get; set; } = new List<CT_Campaign_Cost_Types>();

    public virtual ICollection<CT_Campaign_Cost_Types> CT_Campaign_Cost_Types_LastModifiedByNavigation { get; set; } = new List<CT_Campaign_Cost_Types>();

    public virtual ICollection<CT_Campaign_Types> CT_Campaign_Types_CreatedByNavigation { get; set; } = new List<CT_Campaign_Types>();

    public virtual ICollection<CT_Campaign_Types> CT_Campaign_Types_LastModifiedByNavigation { get; set; } = new List<CT_Campaign_Types>();

    public virtual ICollection<CT_Contact_Roles> CT_Contact_Roles_CreatedByNavigation { get; set; } = new List<CT_Contact_Roles>();

    public virtual ICollection<CT_Contact_Roles> CT_Contact_Roles_LastModifiedByNavigation { get; set; } = new List<CT_Contact_Roles>();

    public virtual ICollection<CT_Contract_States> CT_Contract_States_CreatedByNavigation { get; set; } = new List<CT_Contract_States>();

    public virtual ICollection<CT_Contract_States> CT_Contract_States_LastModifiedByNavigation { get; set; } = new List<CT_Contract_States>();

    public virtual ICollection<CT_Contract_Types> CT_Contract_Types_CreatedByNavigation { get; set; } = new List<CT_Contract_Types>();

    public virtual ICollection<CT_Contract_Types> CT_Contract_Types_LastModifiedByNavigation { get; set; } = new List<CT_Contract_Types>();

    public virtual ICollection<CT_Currency_Types> CT_Currency_Types_CreatedByNavigation { get; set; } = new List<CT_Currency_Types>();

    public virtual ICollection<CT_Currency_Types> CT_Currency_Types_LastModifiedByNavigation { get; set; } = new List<CT_Currency_Types>();

    public virtual ICollection<CT_Firm_Roles> CT_Firm_Roles_CreatedByNavigation { get; set; } = new List<CT_Firm_Roles>();

    public virtual ICollection<CT_Firm_Roles> CT_Firm_Roles_LastModifiedByNavigation { get; set; } = new List<CT_Firm_Roles>();

    public virtual ICollection<CT_Incoterm> CT_Incoterm_CreatedByNavigation { get; set; } = new List<CT_Incoterm>();

    public virtual ICollection<CT_Incoterm> CT_Incoterm_LastModifiedByNavigation { get; set; } = new List<CT_Incoterm>();

    public virtual ICollection<CT_Job_Titles> CT_Job_Titles_CreatedByNavigation { get; set; } = new List<CT_Job_Titles>();

    public virtual ICollection<CT_Job_Titles> CT_Job_Titles_LastModifiedByNavigation { get; set; } = new List<CT_Job_Titles>();

    public virtual ICollection<CT_List_Types> CT_List_Types_CreatedByNavigation { get; set; } = new List<CT_List_Types>();

    public virtual ICollection<CT_List_Types> CT_List_Types_LastModifiedByNavigation { get; set; } = new List<CT_List_Types>();

    public virtual ICollection<CT_Opportunity_Sources> CT_Opportunity_Sources_CreatedByNavigation { get; set; } = new List<CT_Opportunity_Sources>();

    public virtual ICollection<CT_Opportunity_Sources> CT_Opportunity_Sources_LastModifiedByNavigation { get; set; } = new List<CT_Opportunity_Sources>();

    public virtual ICollection<CT_Opportunity_Stages> CT_Opportunity_Stages_CreatedByNavigation { get; set; } = new List<CT_Opportunity_Stages>();

    public virtual ICollection<CT_Opportunity_Stages_Criteria> CT_Opportunity_Stages_Criteria_CreatedByNavigation { get; set; } = new List<CT_Opportunity_Stages_Criteria>();

    public virtual ICollection<CT_Opportunity_Stages_Criteria> CT_Opportunity_Stages_Criteria_LastModifiedByNavigation { get; set; } = new List<CT_Opportunity_Stages_Criteria>();

    public virtual ICollection<CT_Opportunity_Stages> CT_Opportunity_Stages_LastModifiedByNavigation { get; set; } = new List<CT_Opportunity_Stages>();

    public virtual ICollection<CT_Opportunity_Types> CT_Opportunity_Types_CreatedByNavigation { get; set; } = new List<CT_Opportunity_Types>();

    public virtual ICollection<CT_Opportunity_Types> CT_Opportunity_Types_LastModifiedByNavigation { get; set; } = new List<CT_Opportunity_Types>();

    public virtual ICollection<CT_Personnel> CT_Personnel_CreatedByNavigation { get; set; } = new List<CT_Personnel>();

    public virtual ICollection<CT_Personnel> CT_Personnel_LastModifiedByNavigation { get; set; } = new List<CT_Personnel>();

    public virtual ICollection<CT_Price_Types> CT_Price_Types_CreatedByNavigation { get; set; } = new List<CT_Price_Types>();

    public virtual ICollection<CT_Price_Types> CT_Price_Types_LastModifiedByNavigation { get; set; } = new List<CT_Price_Types>();

    public virtual ICollection<CT_Product_Classes> CT_Product_Classes_CreatedByNavigation { get; set; } = new List<CT_Product_Classes>();

    public virtual ICollection<CT_Product_Classes> CT_Product_Classes_LastModifiedByNavigation { get; set; } = new List<CT_Product_Classes>();

    public virtual ICollection<CT_Product_Groups> CT_Product_Groups_CreatedByNavigation { get; set; } = new List<CT_Product_Groups>();

    public virtual ICollection<CT_Product_Groups> CT_Product_Groups_LastModifiedByNavigation { get; set; } = new List<CT_Product_Groups>();

    public virtual ICollection<CT_Proposal_Approval_Rules> CT_Proposal_Approval_RulesWillBeApprovedByNavigation { get; set; } = new List<CT_Proposal_Approval_Rules>();

    public virtual ICollection<CT_Proposal_Approval_Rules> CT_Proposal_Approval_Rules_CreatedByNavigation { get; set; } = new List<CT_Proposal_Approval_Rules>();

    public virtual ICollection<CT_Proposal_Approval_Rules> CT_Proposal_Approval_Rules_LastModifiedByNavigation { get; set; } = new List<CT_Proposal_Approval_Rules>();

    public virtual ICollection<CT_Proposal_Groups> CT_Proposal_Groups_CreatedByNavigation { get; set; } = new List<CT_Proposal_Groups>();

    public virtual ICollection<CT_Proposal_Groups> CT_Proposal_Groups_LastModifiedByNavigation { get; set; } = new List<CT_Proposal_Groups>();

    public virtual ICollection<CT_Proposal_Stages> CT_Proposal_Stages_CreatedByNavigation { get; set; } = new List<CT_Proposal_Stages>();

    public virtual ICollection<CT_Proposal_Stages_Criteria> CT_Proposal_Stages_Criteria_CreatedByNavigation { get; set; } = new List<CT_Proposal_Stages_Criteria>();

    public virtual ICollection<CT_Proposal_Stages_Criteria> CT_Proposal_Stages_Criteria_LastModifiedByNavigation { get; set; } = new List<CT_Proposal_Stages_Criteria>();

    public virtual ICollection<CT_Proposal_Stages> CT_Proposal_Stages_LastModifiedByNavigation { get; set; } = new List<CT_Proposal_Stages>();

    public virtual ICollection<CT_Proposal_Types> CT_Proposal_Types_CreatedByNavigation { get; set; } = new List<CT_Proposal_Types>();

    public virtual ICollection<CT_Proposal_Types> CT_Proposal_Types_LastModifiedByNavigation { get; set; } = new List<CT_Proposal_Types>();

    public virtual ICollection<CT_Reference_Sources> CT_Reference_Sources_CreatedByNavigation { get; set; } = new List<CT_Reference_Sources>();

    public virtual ICollection<CT_Reference_Sources> CT_Reference_Sources_LastModifiedByNavigation { get; set; } = new List<CT_Reference_Sources>();

    public virtual ICollection<CT_Role> CT_Role_CreatedByNavigation { get; set; } = new List<CT_Role>();

    public virtual ICollection<CT_Role> CT_Role_LastModifiedByNavigation { get; set; } = new List<CT_Role>();

    public virtual ICollection<CT_Sales_Area> CT_Sales_Area_CreatedByNavigation { get; set; } = new List<CT_Sales_Area>();

    public virtual ICollection<CT_Sales_Area> CT_Sales_Area_LastModifiedByNavigation { get; set; } = new List<CT_Sales_Area>();

    public virtual ICollection<CT_Sales_Rep> CT_Sales_Rep_CreatedByNavigation { get; set; } = new List<CT_Sales_Rep>();

    public virtual ICollection<CT_Sales_Rep> CT_Sales_Rep_LastModifiedByNavigation { get; set; } = new List<CT_Sales_Rep>();

    public virtual ICollection<CT_Sales_Rep> CT_Sales_Rep_RelatedUserNavigation { get; set; } = new List<CT_Sales_Rep>();

    public virtual ICollection<CT_Sectors> CT_Sectors_CreatedByNavigation { get; set; } = new List<CT_Sectors>();

    public virtual ICollection<CT_Sectors> CT_Sectors_LastModifiedByNavigation { get; set; } = new List<CT_Sectors>();

    public virtual ICollection<CT_Sub_Sectors> CT_Sub_Sectors_CreatedByNavigation { get; set; } = new List<CT_Sub_Sectors>();

    public virtual ICollection<CT_Sub_Sectors> CT_Sub_Sectors_LastModifiedByNavigation { get; set; } = new List<CT_Sub_Sectors>();

    public virtual ICollection<CT_Ticket_Main_Category> CT_Ticket_Main_Category_CreatedByNavigation { get; set; } = new List<CT_Ticket_Main_Category>();

    public virtual ICollection<CT_Ticket_Main_Category> CT_Ticket_Main_Category_LastModifiedByNavigation { get; set; } = new List<CT_Ticket_Main_Category>();

    public virtual ICollection<CT_Ticket_States> CT_Ticket_States_CreatedByNavigation { get; set; } = new List<CT_Ticket_States>();

    public virtual ICollection<CT_Ticket_States> CT_Ticket_States_LastModifiedByNavigation { get; set; } = new List<CT_Ticket_States>();

    public virtual ICollection<CT_Ticket_Sub_Category> CT_Ticket_Sub_Category_CreatedByNavigation { get; set; } = new List<CT_Ticket_Sub_Category>();

    public virtual ICollection<CT_Ticket_Sub_Category> CT_Ticket_Sub_Category_LastModifiedByNavigation { get; set; } = new List<CT_Ticket_Sub_Category>();

    public virtual ICollection<CT_Ticket_Types> CT_Ticket_Types_CreatedByNavigation { get; set; } = new List<CT_Ticket_Types>();

    public virtual ICollection<CT_Ticket_Types> CT_Ticket_Types_LastModifiedByNavigation { get; set; } = new List<CT_Ticket_Types>();

    public virtual ICollection<CT_Units_Collections> CT_Units_Collections_CreatedByNavigation { get; set; } = new List<CT_Units_Collections>();

    public virtual ICollection<CT_Units_Collections> CT_Units_Collections_LastModifiedByNavigation { get; set; } = new List<CT_Units_Collections>();

    public virtual ICollection<CT_Units> CT_Units_CreatedByNavigation { get; set; } = new List<CT_Units>();

    public virtual ICollection<CT_Units> CT_Units_LastModifiedByNavigation { get; set; } = new List<CT_Units>();

    public virtual ICollection<CT_User_Departments> CT_User_Departments_CreatedByNavigation { get; set; } = new List<CT_User_Departments>();

    public virtual ICollection<CT_User_Departments> CT_User_Departments_LastModifiedByNavigation { get; set; } = new List<CT_User_Departments>();

    public virtual EI_Integration_Sets? DefaultIntegrationSetNavigation { get; set; }

    public virtual ICollection<EI_Contact_Relations> EI_Contact_Relations_CreatedByNavigation { get; set; } = new List<EI_Contact_Relations>();

    public virtual ICollection<EI_Contact_Relations> EI_Contact_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Contact_Relations>();

    public virtual ICollection<EI_Firm_Fields> EI_Firm_Fields_CreatedByNavigation { get; set; } = new List<EI_Firm_Fields>();

    public virtual ICollection<EI_Firm_Fields> EI_Firm_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Firm_Fields>();

    public virtual ICollection<EI_Firm_Relations> EI_Firm_Relations_CreatedByNavigation { get; set; } = new List<EI_Firm_Relations>();

    public virtual ICollection<EI_Firm_Relations> EI_Firm_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Firm_Relations>();

    public virtual ICollection<EI_Integration_Sets> EI_Integration_Sets_CreatedByNavigation { get; set; } = new List<EI_Integration_Sets>();

    public virtual ICollection<EI_Integration_Sets> EI_Integration_Sets_LastModifiedByNavigation { get; set; } = new List<EI_Integration_Sets>();

    public virtual ICollection<EI_Product_Fields> EI_Product_Fields_CreatedByNavigation { get; set; } = new List<EI_Product_Fields>();

    public virtual ICollection<EI_Product_Fields> EI_Product_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Product_Fields>();

    public virtual ICollection<EI_Product_Relations> EI_Product_Relations_CreatedByNavigation { get; set; } = new List<EI_Product_Relations>();

    public virtual ICollection<EI_Product_Relations> EI_Product_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Product_Relations>();

    public virtual ICollection<EI_Proposal_Fields> EI_Proposal_Fields_CreatedByNavigation { get; set; } = new List<EI_Proposal_Fields>();

    public virtual ICollection<EI_Proposal_Fields> EI_Proposal_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Proposal_Fields>();

    public virtual ICollection<EI_Proposal_Product_Fields> EI_Proposal_Product_Fields_CreatedByNavigation { get; set; } = new List<EI_Proposal_Product_Fields>();

    public virtual ICollection<EI_Proposal_Product_Fields> EI_Proposal_Product_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Proposal_Product_Fields>();

    public virtual ICollection<EI_Proposal_Relations> EI_Proposal_Relations_CreatedByNavigation { get; set; } = new List<EI_Proposal_Relations>();

    public virtual ICollection<EI_Proposal_Relations> EI_Proposal_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Proposal_Relations>();

    public virtual ICollection<EI_Service_Fields> EI_Service_Fields_CreatedByNavigation { get; set; } = new List<EI_Service_Fields>();

    public virtual ICollection<EI_Service_Fields> EI_Service_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Service_Fields>();

    public virtual ICollection<EI_Shipment_Address_Fields> EI_Shipment_Address_Fields_CreatedByNavigation { get; set; } = new List<EI_Shipment_Address_Fields>();

    public virtual ICollection<EI_Shipment_Address_Fields> EI_Shipment_Address_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Shipment_Address_Fields>();

    public virtual ICollection<EI_Shipment_Address_Relations> EI_Shipment_Address_Relations_CreatedByNavigation { get; set; } = new List<EI_Shipment_Address_Relations>();

    public virtual ICollection<EI_Shipment_Address_Relations> EI_Shipment_Address_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Shipment_Address_Relations>();

    public virtual ICollection<EI_Surcharge_Fields> EI_Surcharge_Fields_CreatedByNavigation { get; set; } = new List<EI_Surcharge_Fields>();

    public virtual ICollection<EI_Surcharge_Fields> EI_Surcharge_Fields_LastModifiedByNavigation { get; set; } = new List<EI_Surcharge_Fields>();

    public virtual ICollection<EI_Unit_Collection_Relations> EI_Unit_Collection_Relations_CreatedByNavigation { get; set; } = new List<EI_Unit_Collection_Relations>();

    public virtual ICollection<EI_Unit_Collection_Relations> EI_Unit_Collection_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Unit_Collection_Relations>();

    public virtual ICollection<EI_Unit_Relations> EI_Unit_Relations_CreatedByNavigation { get; set; } = new List<EI_Unit_Relations>();

    public virtual ICollection<EI_Unit_Relations> EI_Unit_Relations_LastModifiedByNavigation { get; set; } = new List<EI_Unit_Relations>();

    public virtual ICollection<EI_User_ERPBalanceControl_Settings> EI_User_ERPBalanceControl_SettingsUserO { get; set; } = new List<EI_User_ERPBalanceControl_Settings>();

    public virtual ICollection<EI_User_ERPBalanceControl_Settings> EI_User_ERPBalanceControl_Settings_CreatedByNavigation { get; set; } = new List<EI_User_ERPBalanceControl_Settings>();

    public virtual ICollection<EI_User_ERPBalanceControl_Settings> EI_User_ERPBalanceControl_Settings_LastModifiedByNavigation { get; set; } = new List<EI_User_ERPBalanceControl_Settings>();

    public virtual ICollection<GK_Firm_Category01> GK_Firm_Category01_CreatedByNavigation { get; set; } = new List<GK_Firm_Category01>();

    public virtual ICollection<GK_Firm_Category01> GK_Firm_Category01_LastModifiedByNavigation { get; set; } = new List<GK_Firm_Category01>();

    public virtual ICollection<GK_Firm_Category02> GK_Firm_Category02_CreatedByNavigation { get; set; } = new List<GK_Firm_Category02>();

    public virtual ICollection<GK_Firm_Category02> GK_Firm_Category02_LastModifiedByNavigation { get; set; } = new List<GK_Firm_Category02>();

    public virtual ICollection<GK_Firm_Category03> GK_Firm_Category03_CreatedByNavigation { get; set; } = new List<GK_Firm_Category03>();

    public virtual ICollection<GK_Firm_Category03> GK_Firm_Category03_LastModifiedByNavigation { get; set; } = new List<GK_Firm_Category03>();

    public virtual ICollection<GK_Firm_Category04> GK_Firm_Category04_CreatedByNavigation { get; set; } = new List<GK_Firm_Category04>();

    public virtual ICollection<GK_Firm_Category04> GK_Firm_Category04_LastModifiedByNavigation { get; set; } = new List<GK_Firm_Category04>();

    public virtual ICollection<GK_Firm_Category05> GK_Firm_Category05_CreatedByNavigation { get; set; } = new List<GK_Firm_Category05>();

    public virtual ICollection<GK_Firm_Category05> GK_Firm_Category05_LastModifiedByNavigation { get; set; } = new List<GK_Firm_Category05>();

    public virtual ICollection<GK_Product_Category01> GK_Product_Category01_CreatedByNavigation { get; set; } = new List<GK_Product_Category01>();

    public virtual ICollection<GK_Product_Category01> GK_Product_Category01_LastModifiedByNavigation { get; set; } = new List<GK_Product_Category01>();

    public virtual ICollection<GK_Product_Category02> GK_Product_Category02_CreatedByNavigation { get; set; } = new List<GK_Product_Category02>();

    public virtual ICollection<GK_Product_Category02> GK_Product_Category02_LastModifiedByNavigation { get; set; } = new List<GK_Product_Category02>();

    public virtual ICollection<GK_Product_Category03> GK_Product_Category03_CreatedByNavigation { get; set; } = new List<GK_Product_Category03>();

    public virtual ICollection<GK_Product_Category03> GK_Product_Category03_LastModifiedByNavigation { get; set; } = new List<GK_Product_Category03>();

    public virtual ICollection<GK_Product_Category04> GK_Product_Category04_CreatedByNavigation { get; set; } = new List<GK_Product_Category04>();

    public virtual ICollection<GK_Product_Category04> GK_Product_Category04_LastModifiedByNavigation { get; set; } = new List<GK_Product_Category04>();

    public virtual ICollection<GK_Product_Category05> GK_Product_Category05_CreatedByNavigation { get; set; } = new List<GK_Product_Category05>();

    public virtual ICollection<GK_Product_Category05> GK_Product_Category05_LastModifiedByNavigation { get; set; } = new List<GK_Product_Category05>();

    public virtual ICollection<MT_Action_Lists> MT_Action_Lists_CreatedByNavigation { get; set; } = new List<MT_Action_Lists>();

    public virtual ICollection<MT_Action_Lists> MT_Action_Lists_LastModifiedByNavigation { get; set; } = new List<MT_Action_Lists>();

    public virtual ICollection<MT_Activity> MT_Activity_CreatedByNavigation { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Activity> MT_Activity_LastModifiedByNavigation { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Campaign> MT_Campaign_CreatedByNavigation { get; set; } = new List<MT_Campaign>();

    public virtual ICollection<MT_Campaign> MT_Campaign_LastModifiedByNavigation { get; set; } = new List<MT_Campaign>();

    public virtual ICollection<MT_Campaign_Lists> MT_Campaign_Lists_CreatedByNavigation { get; set; } = new List<MT_Campaign_Lists>();

    public virtual ICollection<MT_Campaign_Lists> MT_Campaign_Lists_LastModifiedByNavigation { get; set; } = new List<MT_Campaign_Lists>();

    public virtual ICollection<MT_Contact> MT_Contact_CreatedByNavigation { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Contact> MT_Contact_LastModifiedByNavigation { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Document> MT_Document_CreatedByNavigation { get; set; } = new List<MT_Document>();

    public virtual ICollection<MT_Document_Folder> MT_Document_Folder_CreatedByNavigation { get; set; } = new List<MT_Document_Folder>();

    public virtual ICollection<MT_Document_Folder> MT_Document_Folder_LastModifiedByNavigation { get; set; } = new List<MT_Document_Folder>();

    public virtual ICollection<MT_Document> MT_Document_LastModifiedByNavigation { get; set; } = new List<MT_Document>();

    public virtual ICollection<MT_Event> MT_Event_CreatedByNavigation { get; set; } = new List<MT_Event>();

    public virtual ICollection<MT_Event> MT_Event_LastModifiedByNavigation { get; set; } = new List<MT_Event>();

    public virtual ICollection<MT_Firm> MT_Firm_CreatedByNavigation { get; set; } = new List<MT_Firm>();

    public virtual ICollection<MT_Firm> MT_Firm_LastModifiedByNavigation { get; set; } = new List<MT_Firm>();

    public virtual ICollection<MT_Mail> MT_Mail_CreatedByNavigation { get; set; } = new List<MT_Mail>();

    public virtual ICollection<MT_Mail> MT_Mail_LastModifiedByNavigation { get; set; } = new List<MT_Mail>();

    public virtual ICollection<MT_Mail_Settings> MT_Mail_Settings { get; set; } = new List<MT_Mail_Settings>();

    public virtual ICollection<MT_Notes> MT_Notes_CreatedByNavigation { get; set; } = new List<MT_Notes>();

    public virtual ICollection<MT_Notes> MT_Notes_LastModifiedByNavigation { get; set; } = new List<MT_Notes>();

    public virtual ICollection<MT_Notifications> MT_Notifications_CreatedByNavigation { get; set; } = new List<MT_Notifications>();

    public virtual ICollection<MT_Notifications> MT_Notifications_LastModifiedByNavigation { get; set; } = new List<MT_Notifications>();

    public virtual ICollection<MT_Opportunity> MT_Opportunity_CreatedByNavigation { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Opportunity> MT_Opportunity_LastModifiedByNavigation { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Product> MT_Product_CreatedByNavigation { get; set; } = new List<MT_Product>();

    public virtual ICollection<MT_Product> MT_Product_LastModifiedByNavigation { get; set; } = new List<MT_Product>();

    public virtual ICollection<MT_Product_Prices> MT_Product_Prices_CreatedByNavigation { get; set; } = new List<MT_Product_Prices>();

    public virtual ICollection<MT_Product_Prices> MT_Product_Prices_LastModifiedByNavigation { get; set; } = new List<MT_Product_Prices>();

    public virtual ICollection<MT_Proposals> MT_ProposalsLastApprovalGivenByNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals> MT_ProposalsLastApprovalStateByNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals> MT_ProposalsLastApprovalWaitingOnNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals> MT_Proposals_ApprovalsSentByNavigation { get; set; } = new List<MT_Proposals_Approvals>();

    public virtual ICollection<MT_Proposals_Approvals> MT_Proposals_ApprovalsWaitingForNavigation { get; set; } = new List<MT_Proposals_Approvals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsLastApprovalGivenByNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsLastApprovalStateByNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsLastApprovalWaitingOnNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details_CreatedByNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals> MT_Proposals_CreatedByNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_History> MT_Proposals_History_CreatedByNavigation { get; set; } = new List<MT_Proposals_History>();

    public virtual ICollection<MT_Proposals_History> MT_Proposals_History_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_History>();

    public virtual ICollection<MT_Proposals> MT_Proposals_LastModifiedByNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Prepared_Forms> MT_Proposals_Prepared_Forms_CreatedByNavigation { get; set; } = new List<MT_Proposals_Prepared_Forms>();

    public virtual ICollection<MT_Proposals_Prepared_Forms> MT_Proposals_Prepared_Forms_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_Prepared_Forms>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details_CreatedByNavigation { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products_CreatedByNavigation { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsLastApprovalGivenByNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsLastApprovalStateByNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsLastApprovalWaitingOnNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals_CreatedByNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals_LastModifiedByNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Shares> MT_Shares_CreatedByNavigation { get; set; } = new List<MT_Shares>();

    public virtual ICollection<MT_Shares> MT_Shares_LastModifiedByNavigation { get; set; } = new List<MT_Shares>();

    public virtual ICollection<MT_Task> MT_TaskAssignedToNavigation { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Task> MT_TaskOwnerNavigation { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Task> MT_Task_CreatedByNavigation { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Task> MT_Task_LastModifiedByNavigation { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Ticket> MT_TicketAssignedToNavigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket> MT_Ticket_CreatedByNavigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket> MT_Ticket_LastModifiedByNavigation { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<MT_Ticket_Prepared_Forms> MT_Ticket_Prepared_Forms_CreatedByNavigation { get; set; } = new List<MT_Ticket_Prepared_Forms>();

    public virtual ICollection<MT_Ticket_Prepared_Forms> MT_Ticket_Prepared_Forms_LastModifiedByNavigation { get; set; } = new List<MT_Ticket_Prepared_Forms>();

    public virtual PO_Person OidNavigation { get; set; } = null!;

    public virtual ICollection<PO_Address_Type> PO_Address_Type_CreatedByNavigation { get; set; } = new List<PO_Address_Type>();

    public virtual ICollection<PO_Address_Type> PO_Address_Type_LastModifiedByNavigation { get; set; } = new List<PO_Address_Type>();

    public virtual ICollection<PO_Country> PO_Country_CreatedByNavigation { get; set; } = new List<PO_Country>();

    public virtual ICollection<PO_Country> PO_Country_LastModifiedByNavigation { get; set; } = new List<PO_Country>();

    public virtual ICollection<PO_Phone_Type> PO_Phone_Type_CreatedByNavigation { get; set; } = new List<PO_Phone_Type>();

    public virtual ICollection<PO_Phone_Type> PO_Phone_Type_LastModifiedByNavigation { get; set; } = new List<PO_Phone_Type>();

    public virtual ICollection<RI_Activity_Product> RI_Activity_Product_CreatedByNavigation { get; set; } = new List<RI_Activity_Product>();

    public virtual ICollection<RI_Activity_Product> RI_Activity_Product_LastModifiedByNavigation { get; set; } = new List<RI_Activity_Product>();

    public virtual ICollection<RI_Contact_PhoneNumber> RI_Contact_PhoneNumber_CreatedByNavigation { get; set; } = new List<RI_Contact_PhoneNumber>();

    public virtual ICollection<RI_Contact_PhoneNumber> RI_Contact_PhoneNumber_LastModifiedByNavigation { get; set; } = new List<RI_Contact_PhoneNumber>();

    public virtual ICollection<RI_Contact_Product> RI_Contact_Product_CreatedByNavigation { get; set; } = new List<RI_Contact_Product>();

    public virtual ICollection<RI_Contact_Product> RI_Contact_Product_LastModifiedByNavigation { get; set; } = new List<RI_Contact_Product>();

    public virtual ICollection<RI_Event_Product> RI_Event_Product_CreatedByNavigation { get; set; } = new List<RI_Event_Product>();

    public virtual ICollection<RI_Event_Product> RI_Event_Product_LastModifiedByNavigation { get; set; } = new List<RI_Event_Product>();

    public virtual ICollection<RI_Firm_PhoneNumber> RI_Firm_PhoneNumber_CreatedByNavigation { get; set; } = new List<RI_Firm_PhoneNumber>();

    public virtual ICollection<RI_Firm_PhoneNumber> RI_Firm_PhoneNumber_LastModifiedByNavigation { get; set; } = new List<RI_Firm_PhoneNumber>();

    public virtual ICollection<RI_Firm_Product> RI_Firm_Product_CreatedByNavigation { get; set; } = new List<RI_Firm_Product>();

    public virtual ICollection<RI_Firm_Product> RI_Firm_Product_LastModifiedByNavigation { get; set; } = new List<RI_Firm_Product>();

    public virtual ICollection<RI_Opportunity_Product> RI_Opportunity_Product_CreatedByNavigation { get; set; } = new List<RI_Opportunity_Product>();

    public virtual ICollection<RI_Opportunity_Product> RI_Opportunity_Product_LastModifiedByNavigation { get; set; } = new List<RI_Opportunity_Product>();

    public virtual ICollection<RI_Product_Units_Collections_Properties> RI_Product_Units_Collections_Properties_CreatedByNavigation { get; set; } = new List<RI_Product_Units_Collections_Properties>();

    public virtual ICollection<RI_Product_Units_Collections_Properties> RI_Product_Units_Collections_Properties_LastModifiedByNavigation { get; set; } = new List<RI_Product_Units_Collections_Properties>();

    public virtual ICollection<RI_Ticket_Product> RI_Ticket_Product_CreatedByNavigation { get; set; } = new List<RI_Ticket_Product>();

    public virtual ICollection<RI_Ticket_Product> RI_Ticket_Product_LastModifiedByNavigation { get; set; } = new List<RI_Ticket_Product>();

    public virtual ICollection<RI_Units_Collections_Properties> RI_Units_Collections_Properties_CreatedByNavigation { get; set; } = new List<RI_Units_Collections_Properties>();

    public virtual ICollection<RI_Units_Collections_Properties> RI_Units_Collections_Properties_LastModifiedByNavigation { get; set; } = new List<RI_Units_Collections_Properties>();

    public virtual ICollection<RI_User_ERPWarehouse> RI_User_ERPWarehouseRelatedUserNavigation { get; set; } = new List<RI_User_ERPWarehouse>();

    public virtual ICollection<RI_User_ERPWarehouse> RI_User_ERPWarehouse_CreatedByNavigation { get; set; } = new List<RI_User_ERPWarehouse>();

    public virtual ICollection<RI_User_ERPWarehouse> RI_User_ERPWarehouse_LastModifiedByNavigation { get; set; } = new List<RI_User_ERPWarehouse>();

    public virtual ICollection<RL_Event_Users> RL_Event_Users { get; set; } = new List<RL_Event_Users>();

    public virtual ICollection<RL_Integration_Sets_User> RL_Integration_Sets_User { get; set; } = new List<RL_Integration_Sets_User>();

    public virtual ICollection<RL_Notes_User> RL_Notes_User { get; set; } = new List<RL_Notes_User>();

    public virtual ICollection<RL_Price_Types_Users> RL_Price_Types_UsersUser_Navigation { get; set; } = new List<RL_Price_Types_Users>();

    public virtual ICollection<RL_Price_Types_Users> RL_Price_Types_Users_LastModifiedByNavigation { get; set; } = new List<RL_Price_Types_Users>();

    public virtual ICollection<RL_User_Role> RL_User_Role { get; set; } = new List<RL_User_Role>();

    public virtual ICollection<RL_User_Sales_Rep> RL_User_Sales_Rep { get; set; } = new List<RL_User_Sales_Rep>();

    public virtual ICollection<RL_User_Tasks> RL_User_Tasks { get; set; } = new List<RL_User_Tasks>();

    public virtual ICollection<RL_Users_Departments> RL_Users_Departments { get; set; } = new List<RL_Users_Departments>();

    public virtual ICollection<RL_Users_MySummaryItems> RL_Users_MySummaryItems { get; set; } = new List<RL_Users_MySummaryItems>();

    public virtual ICollection<SS_CloudDrive_Settings> SS_CloudDrive_Settings { get; set; } = new List<SS_CloudDrive_Settings>();

    public virtual ICollection<SS_IPS_Settings> SS_IPS_Settings_CreatedByNavigation { get; set; } = new List<SS_IPS_Settings>();

    public virtual ICollection<SS_IPS_Settings> SS_IPS_Settings_LastModifiedByNavigation { get; set; } = new List<SS_IPS_Settings>();

    public virtual ICollection<SS_ListView_Sizes> SS_ListView_Sizes { get; set; } = new List<SS_ListView_Sizes>();

    public virtual ICollection<SS_Popup_Window_Sizes> SS_Popup_Window_Sizes { get; set; } = new List<SS_Popup_Window_Sizes>();

    public virtual ICollection<SS_Twitter_UserSettings> SS_Twitter_UserSettings { get; set; } = new List<SS_Twitter_UserSettings>();

    public virtual ICollection<SS_User_Cache> SS_User_Cache { get; set; } = new List<SS_User_Cache>();

    public virtual ICollection<SS_User_Preferences_General> SS_User_Preferences_GeneralOwnerUserNavigation { get; set; } = new List<SS_User_Preferences_General>();

    public virtual ICollection<SS_User_Preferences_General> SS_User_Preferences_General_LastModifiedByNavigation { get; set; } = new List<SS_User_Preferences_General>();

    public virtual ICollection<SS_User_Status> SS_User_Status { get; set; } = new List<SS_User_Status>();

    public virtual ICollection<ST_Action_Authorization> ST_Action_Authorization { get; set; } = new List<ST_Action_Authorization>();

    public virtual ICollection<ST_Company_Info> ST_Company_Info_CreatedByNavigation { get; set; } = new List<ST_Company_Info>();

    public virtual ICollection<ST_Company_Info> ST_Company_Info_LastModifiedByNavigation { get; set; } = new List<ST_Company_Info>();

    public virtual ICollection<ST_Exchange_Rates> ST_Exchange_Rates { get; set; } = new List<ST_Exchange_Rates>();

    public virtual ICollection<ST_Full_Search_Objects> ST_Full_Search_Objects_CreatedByNavigation { get; set; } = new List<ST_Full_Search_Objects>();

    public virtual ICollection<ST_Full_Search_Objects> ST_Full_Search_Objects_LastModifiedByNavigation { get; set; } = new List<ST_Full_Search_Objects>();

    public virtual ICollection<ST_IPS_Logs> ST_IPS_LogsAgentUserNavigation { get; set; } = new List<ST_IPS_Logs>();

    public virtual ICollection<ST_IPS_Logs> ST_IPS_LogsLoggedInUserNavigation { get; set; } = new List<ST_IPS_Logs>();

    public virtual ICollection<ST_MySummary> ST_MySummary { get; set; } = new List<ST_MySummary>();

    public virtual ICollection<ST_Proposal_Category> ST_Proposal_Category_CreatedByNavigation { get; set; } = new List<ST_Proposal_Category>();

    public virtual ICollection<ST_Proposal_Category> ST_Proposal_Category_LastModifiedByNavigation { get; set; } = new List<ST_Proposal_Category>();

    public virtual ICollection<ST_Proposals_ReCalculate_Fields> ST_Proposals_ReCalculate_Fields_CreatedByNavigation { get; set; } = new List<ST_Proposals_ReCalculate_Fields>();

    public virtual ICollection<ST_Proposals_ReCalculate_Fields> ST_Proposals_ReCalculate_Fields_LastModifiedByNavigation { get; set; } = new List<ST_Proposals_ReCalculate_Fields>();

    public virtual ICollection<ST_Task_Assign> ST_Task_AssignAssignedToNavigation { get; set; } = new List<ST_Task_Assign>();

    public virtual ICollection<ST_Task_Assign> ST_Task_Assign_CreatedByNavigation { get; set; } = new List<ST_Task_Assign>();

    public virtual ICollection<ST_Task_Assign> ST_Task_Assign_LastModifiedByNavigation { get; set; } = new List<ST_Task_Assign>();

    public virtual ICollection<ST_Task_State> ST_Task_State_CreatedByNavigation { get; set; } = new List<ST_Task_State>();

    public virtual ICollection<ST_Task_State> ST_Task_State_LastModifiedByNavigation { get; set; } = new List<ST_Task_State>();

    public virtual ICollection<ST_Ticket_Assign> ST_Ticket_AssignAssignedToNavigation { get; set; } = new List<ST_Ticket_Assign>();

    public virtual ICollection<ST_Ticket_Assign> ST_Ticket_Assign_CreatedByNavigation { get; set; } = new List<ST_Ticket_Assign>();

    public virtual ICollection<ST_Ticket_Assign> ST_Ticket_Assign_LastModifiedByNavigation { get; set; } = new List<ST_Ticket_Assign>();

    public virtual ICollection<ST_Ticket_State> ST_Ticket_State_CreatedByNavigation { get; set; } = new List<ST_Ticket_State>();

    public virtual ICollection<ST_Ticket_State> ST_Ticket_State_LastModifiedByNavigation { get; set; } = new List<ST_Ticket_State>();

    public virtual ICollection<ST_UserMessages> ST_UserMessages { get; set; } = new List<ST_UserMessages>();

    public virtual ICollection<ST_UserShortcuts> ST_UserShortcuts { get; set; } = new List<ST_UserShortcuts>();

    public virtual ICollection<ST_UserWidgets> ST_UserWidgets { get; set; } = new List<ST_UserWidgets>();

    public virtual ICollection<ST_User_Access_Rights> ST_User_Access_RightsUserO { get; set; } = new List<ST_User_Access_Rights>();

    public virtual ICollection<ST_User_Access_Rights> ST_User_Access_Rights_LastModifiedByNavigation { get; set; } = new List<ST_User_Access_Rights>();

    public virtual ICollection<ST_User_Apps> ST_User_Apps { get; set; } = new List<ST_User_Apps>();

    public virtual ICollection<ZD_Copy_Fields> ZD_Copy_Fields_CreatedByNavigation { get; set; } = new List<ZD_Copy_Fields>();

    public virtual ICollection<ZD_Copy_Fields> ZD_Copy_Fields_LastModifiedByNavigation { get; set; } = new List<ZD_Copy_Fields>();

    public virtual ICollection<ZD_Default_Values> ZD_Default_Values_CreatedByNavigation { get; set; } = new List<ZD_Default_Values>();

    public virtual ICollection<ZD_Default_Values> ZD_Default_Values_LastModifiedByNavigation { get; set; } = new List<ZD_Default_Values>();

    public virtual ICollection<ZD_External_Links> ZD_External_Links_CreatedByNavigation { get; set; } = new List<ZD_External_Links>();

    public virtual ICollection<ZD_External_Links> ZD_External_Links_LastModifiedByNavigation { get; set; } = new List<ZD_External_Links>();

    public virtual ICollection<ZD_Extra_Fields_Columns> ZD_Extra_Fields_Columns_CreatedByNavigation { get; set; } = new List<ZD_Extra_Fields_Columns>();

    public virtual ICollection<ZD_Extra_Fields_Columns> ZD_Extra_Fields_Columns_LastModifiedByNavigation { get; set; } = new List<ZD_Extra_Fields_Columns>();

    public virtual ICollection<ZD_Extra_Fields> ZD_Extra_Fields_CreatedByNavigation { get; set; } = new List<ZD_Extra_Fields>();

    public virtual ICollection<ZD_Extra_Fields> ZD_Extra_Fields_LastModifiedByNavigation { get; set; } = new List<ZD_Extra_Fields>();
}

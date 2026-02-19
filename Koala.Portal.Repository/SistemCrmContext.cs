using Koala.Portal.Core.CrmModels;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository;

public partial class SistemCrmContext : DbContext
{
    public SistemCrmContext()
    {
    }

    public SistemCrmContext(DbContextOptions<SistemCrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AA_CompetitorManagement_Opportunity> AA_CompetitorManagement_Opportunity { get; set; }

    public virtual DbSet<AA_CompetitorManagement_Proposals> AA_CompetitorManagement_Proposals { get; set; }

    public virtual DbSet<AA_CompetitorManagement_Reason> AA_CompetitorManagement_Reason { get; set; }

    public virtual DbSet<AA_CompetitorManagement_UserSettings> AA_CompetitorManagement_UserSettings { get; set; }

    public virtual DbSet<AA_Email_Report> AA_Email_Report { get; set; }

    public virtual DbSet<AA_Email_Report_MT> AA_Email_Report_MT { get; set; }

    public virtual DbSet<AA_Email_Settings> AA_Email_Settings { get; set; }

    public virtual DbSet<AA_GoogleCalendar_Events> AA_GoogleCalendar_Events { get; set; }

    public virtual DbSet<AA_GoogleCalendar_UserCalendar> AA_GoogleCalendar_UserCalendar { get; set; }

    public virtual DbSet<AA_GoogleCalendar_UserSettings> AA_GoogleCalendar_UserSettings { get; set; }

    public virtual DbSet<AA_GoogleMaps_GeoPoint> AA_GoogleMaps_GeoPoint { get; set; }

    public virtual DbSet<AA_GoogleMaps_MapSettings> AA_GoogleMaps_MapSettings { get; set; }

    public virtual DbSet<AA_GoogleMaps_Nearby> AA_GoogleMaps_Nearby { get; set; }

    public virtual DbSet<AA_Sms_Report> AA_Sms_Report { get; set; }

    public virtual DbSet<AA_Sms_Report_MT> AA_Sms_Report_MT { get; set; }

    public virtual DbSet<AA_Sms_Settings> AA_Sms_Settings { get; set; }

    public virtual DbSet<AKTIVITE> AKTIVITE { get; set; }

    public virtual DbSet<Analysis> Analysis { get; set; }

    public virtual DbSet<AuditDataItemPersistent> AuditDataItemPersistent { get; set; }

    public virtual DbSet<AuditedObjectWeakReference> AuditedObjectWeakReference { get; set; }

    public virtual DbSet<BulkEmailHelper> BulkEmailHelper { get; set; }

    public virtual DbSet<CT_Activity_Category> CT_Activity_Category { get; set; }

    public virtual DbSet<CT_Activity_States> CT_Activity_States { get; set; }

    public virtual DbSet<CT_Activity_Types> CT_Activity_Types { get; set; }

    public virtual DbSet<CT_Campaign_Cost_Types> CT_Campaign_Cost_Types { get; set; }

    public virtual DbSet<CT_Campaign_Types> CT_Campaign_Types { get; set; }

    public virtual DbSet<CT_Contact_Roles> CT_Contact_Roles { get; set; }

    public virtual DbSet<CT_Contract_States> CT_Contract_States { get; set; }

    public virtual DbSet<CT_Contract_Types> CT_Contract_Types { get; set; }

    public virtual DbSet<CT_Currency_Types> CT_Currency_Types { get; set; }

    public virtual DbSet<CT_Firm_Roles> CT_Firm_Roles { get; set; }

    public virtual DbSet<CT_Incoterm> CT_Incoterm { get; set; }

    public virtual DbSet<CT_Job_Titles> CT_Job_Titles { get; set; }

    public virtual DbSet<CT_List_Types> CT_List_Types { get; set; }

    public virtual DbSet<CT_Opportunity_Sources> CT_Opportunity_Sources { get; set; }

    public virtual DbSet<CT_Opportunity_Stages> CT_Opportunity_Stages { get; set; }

    public virtual DbSet<CT_Opportunity_Stages_Criteria> CT_Opportunity_Stages_Criteria { get; set; }

    public virtual DbSet<CT_Opportunity_Types> CT_Opportunity_Types { get; set; }

    public virtual DbSet<CT_Personnel> CT_Personnel { get; set; }

    public virtual DbSet<CT_Price_Types> CT_Price_Types { get; set; }

    public virtual DbSet<CT_Product_Classes> CT_Product_Classes { get; set; }

    public virtual DbSet<CT_Product_Groups> CT_Product_Groups { get; set; }

    public virtual DbSet<CT_Proposal_Approval_Rules> CT_Proposal_Approval_Rules { get; set; }

    public virtual DbSet<CT_Proposal_Groups> CT_Proposal_Groups { get; set; }

    public virtual DbSet<CT_Proposal_Stages> CT_Proposal_Stages { get; set; }

    public virtual DbSet<CT_Proposal_Stages_Criteria> CT_Proposal_Stages_Criteria { get; set; }

    public virtual DbSet<CT_Proposal_Types> CT_Proposal_Types { get; set; }

    public virtual DbSet<CT_Reference_Sources> CT_Reference_Sources { get; set; }

    public virtual DbSet<CT_Role> CT_Role { get; set; }

    public virtual DbSet<CT_Sales_Area> CT_Sales_Area { get; set; }

    public virtual DbSet<CT_Sales_Rep> CT_Sales_Rep { get; set; }

    public virtual DbSet<CT_Sectors> CT_Sectors { get; set; }

    public virtual DbSet<CT_Sub_Sectors> CT_Sub_Sectors { get; set; }

    public virtual DbSet<CT_Ticket_Main_Category> CT_Ticket_Main_Category { get; set; }

    public virtual DbSet<CT_Ticket_States> CT_Ticket_States { get; set; }

    public virtual DbSet<CT_Ticket_Sub_Category> CT_Ticket_Sub_Category { get; set; }

    public virtual DbSet<CT_Ticket_Types> CT_Ticket_Types { get; set; }

    public virtual DbSet<CT_Units> CT_Units { get; set; }

    public virtual DbSet<CT_Units_Collections> CT_Units_Collections { get; set; }

    public virtual DbSet<CT_User_Access_Definitions> CT_User_Access_Definitions { get; set; }

    public virtual DbSet<CT_User_Departments> CT_User_Departments { get; set; }

    public virtual DbSet<CustomAppearanceRule> CustomAppearanceRule { get; set; }

    public virtual DbSet<DESTEKKAYDI> DESTEKKAYDI { get; set; }

    public virtual DbSet<DashboardDefinitionDashboardDefinitions> DashboardDefinitionDashboardDefinitions { get; set; }

    public virtual DbSet<EI_Contact_Relations> EI_Contact_Relations { get; set; }

    public virtual DbSet<EI_Firm_Fields> EI_Firm_Fields { get; set; }

    public virtual DbSet<EI_Firm_Relations> EI_Firm_Relations { get; set; }

    public virtual DbSet<EI_Integration_Sets> EI_Integration_Sets { get; set; }

    public virtual DbSet<EI_Product_Fields> EI_Product_Fields { get; set; }

    public virtual DbSet<EI_Product_Relations> EI_Product_Relations { get; set; }

    public virtual DbSet<EI_Proposal_Fields> EI_Proposal_Fields { get; set; }

    public virtual DbSet<EI_Proposal_Product_Fields> EI_Proposal_Product_Fields { get; set; }

    public virtual DbSet<EI_Proposal_Relations> EI_Proposal_Relations { get; set; }

    public virtual DbSet<EI_Service_Fields> EI_Service_Fields { get; set; }

    public virtual DbSet<EI_Shipment_Address_Fields> EI_Shipment_Address_Fields { get; set; }

    public virtual DbSet<EI_Shipment_Address_Relations> EI_Shipment_Address_Relations { get; set; }

    public virtual DbSet<EI_Surcharge_Fields> EI_Surcharge_Fields { get; set; }

    public virtual DbSet<EI_Unit_Collection_Relations> EI_Unit_Collection_Relations { get; set; }

    public virtual DbSet<EI_Unit_Relations> EI_Unit_Relations { get; set; }

    public virtual DbSet<EI_User_ERPBalanceControl_Settings> EI_User_ERPBalanceControl_Settings { get; set; }

    public virtual DbSet<EX_Firm_Applications> EX_Firm_Applications { get; set; }

    public virtual DbSet<EX_Firm_Applications_payment> EX_Firm_Applications_payment { get; set; }

    public virtual DbSet<EX_Firm_SecretKey> EX_Firm_SecretKey { get; set; }

    public virtual DbSet<EX_Ticket_Contact> EX_Ticket_Contact { get; set; }

    public virtual DbSet<EX_Ticket_History> EX_Ticket_History { get; set; }

    public virtual DbSet<GK_Firm_Category01> GK_Firm_Category01 { get; set; }

    public virtual DbSet<GK_Firm_Category02> GK_Firm_Category02 { get; set; }

    public virtual DbSet<GK_Firm_Category03> GK_Firm_Category03 { get; set; }

    public virtual DbSet<GK_Firm_Category04> GK_Firm_Category04 { get; set; }

    public virtual DbSet<GK_Firm_Category05> GK_Firm_Category05 { get; set; }

    public virtual DbSet<GK_Product_Category01> GK_Product_Category01 { get; set; }

    public virtual DbSet<GK_Product_Category02> GK_Product_Category02 { get; set; }

    public virtual DbSet<GK_Product_Category03> GK_Product_Category03 { get; set; }

    public virtual DbSet<GK_Product_Category04> GK_Product_Category04 { get; set; }

    public virtual DbSet<GK_Product_Category05> GK_Product_Category05 { get; set; }

    public virtual DbSet<GOREV> GOREV { get; set; }

    public virtual DbSet<KpiDefinition> KpiDefinition { get; set; }

    public virtual DbSet<KpiHistoryItem> KpiHistoryItem { get; set; }

    public virtual DbSet<KpiInstance> KpiInstance { get; set; }

    public virtual DbSet<KpiScorecard> KpiScorecard { get; set; }

    public virtual DbSet<KpiScorecardScorecards_KpiInstanceIndicators> KpiScorecardScorecards_KpiInstanceIndicators { get; set; }

    public virtual DbSet<MT_Action_Lists> MT_Action_Lists { get; set; }

    public virtual DbSet<MT_Activity> MT_Activity { get; set; }

    public virtual DbSet<MT_Campaign> MT_Campaign { get; set; }

    public virtual DbSet<MT_Campaign_Lists> MT_Campaign_Lists { get; set; }

    public virtual DbSet<MT_Contact> MT_Contact { get; set; }

    public virtual DbSet<MT_Document> MT_Document { get; set; }

    public virtual DbSet<MT_Document_Folder> MT_Document_Folder { get; set; }

    public virtual DbSet<MT_Event> MT_Event { get; set; }

    public virtual DbSet<MT_Firm> MT_Firm { get; set; }

    public virtual DbSet<MT_Mail> MT_Mail { get; set; }

    public virtual DbSet<MT_Mail_Settings> MT_Mail_Settings { get; set; }

    public virtual DbSet<MT_Notes> MT_Notes { get; set; }

    public virtual DbSet<MT_Notifications> MT_Notifications { get; set; }

    public virtual DbSet<MT_Opportunity> MT_Opportunity { get; set; }

    public virtual DbSet<MT_Product> MT_Product { get; set; }

    public virtual DbSet<MT_Product_Prices> MT_Product_Prices { get; set; }

    public virtual DbSet<MT_Proposals> MT_Proposals { get; set; }

    public virtual DbSet<MT_Proposals_Additional_Cost> MT_Proposals_Additional_Cost { get; set; }

    public virtual DbSet<MT_Proposals_Approvals> MT_Proposals_Approvals { get; set; }

    public virtual DbSet<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; }

    public virtual DbSet<MT_Proposals_History> MT_Proposals_History { get; set; }

    public virtual DbSet<MT_Proposals_Prepared_Forms> MT_Proposals_Prepared_Forms { get; set; }

    public virtual DbSet<MT_Proposals_Products> MT_Proposals_Products { get; set; }

    public virtual DbSet<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; }

    public virtual DbSet<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; }

    public virtual DbSet<MT_Proposals_Unit_Conversions> MT_Proposals_Unit_Conversions { get; set; }

    public virtual DbSet<MT_Shares> MT_Shares { get; set; }

    public virtual DbSet<MT_Task> MT_Task { get; set; }

    public virtual DbSet<MT_Ticket> MT_Ticket { get; set; }

    public virtual DbSet<MT_Ticket_Prepared_Forms> MT_Ticket_Prepared_Forms { get; set; }

    public virtual DbSet<MailChimpLists> MailChimpLists { get; set; }

    public virtual DbSet<PO_Address> PO_Address { get; set; }

    public virtual DbSet<PO_Address_Type> PO_Address_Type { get; set; }

    public virtual DbSet<PO_City> PO_City { get; set; }

    public virtual DbSet<PO_Country> PO_Country { get; set; }

    public virtual DbSet<PO_County> PO_County { get; set; }

    public virtual DbSet<PO_District> PO_District { get; set; }

    public virtual DbSet<PO_File> PO_File { get; set; }

    public virtual DbSet<PO_FilePath> PO_FilePath { get; set; }

    public virtual DbSet<PO_Parish> PO_Parish { get; set; }

    public virtual DbSet<PO_Person> PO_Person { get; set; }

    public virtual DbSet<PO_Phone_Number> PO_Phone_Number { get; set; }

    public virtual DbSet<PO_Phone_Type> PO_Phone_Type { get; set; }

    public virtual DbSet<PO_Prepared_Form> PO_Prepared_Form { get; set; }

    public virtual DbSet<PO_Social_Media> PO_Social_Media { get; set; }

    public virtual DbSet<RI_Activity_Product> RI_Activity_Product { get; set; }

    public virtual DbSet<RI_Contact_PhoneNumber> RI_Contact_PhoneNumber { get; set; }

    public virtual DbSet<RI_Contact_Product> RI_Contact_Product { get; set; }

    public virtual DbSet<RI_Event_Product> RI_Event_Product { get; set; }

    public virtual DbSet<RI_Firm_PhoneNumber> RI_Firm_PhoneNumber { get; set; }

    public virtual DbSet<RI_Firm_Product> RI_Firm_Product { get; set; }

    public virtual DbSet<RI_Opportunity_Product> RI_Opportunity_Product { get; set; }

    public virtual DbSet<RI_Product_Units_Collections_Properties> RI_Product_Units_Collections_Properties { get; set; }

    public virtual DbSet<RI_Ticket_Product> RI_Ticket_Product { get; set; }

    public virtual DbSet<RI_Units_Collections_Properties> RI_Units_Collections_Properties { get; set; }

    public virtual DbSet<RI_User_ERPWarehouse> RI_User_ERPWarehouse { get; set; }

    public virtual DbSet<RL_Activity_SalesRep> RL_Activity_SalesRep { get; set; }

    public virtual DbSet<RL_Activity_Task> RL_Activity_Task { get; set; }

    public virtual DbSet<RL_Campaign_Document> RL_Campaign_Document { get; set; }

    public virtual DbSet<RL_Campaign_List_Types> RL_Campaign_List_Types { get; set; }

    public virtual DbSet<RL_Campaign_Product> RL_Campaign_Product { get; set; }

    public virtual DbSet<RL_Contact_Actions_Lists> RL_Contact_Actions_Lists { get; set; }

    public virtual DbSet<RL_Contact_Activity_Other> RL_Contact_Activity_Other { get; set; }

    public virtual DbSet<RL_Contact_List_Types> RL_Contact_List_Types { get; set; }

    public virtual DbSet<RL_Contact_Opportunity_Other> RL_Contact_Opportunity_Other { get; set; }

    public virtual DbSet<RL_Document_Activity> RL_Document_Activity { get; set; }

    public virtual DbSet<RL_Document_Contact> RL_Document_Contact { get; set; }

    public virtual DbSet<RL_Document_Event> RL_Document_Event { get; set; }

    public virtual DbSet<RL_Document_Firm> RL_Document_Firm { get; set; }

    public virtual DbSet<RL_Document_Opportunity> RL_Document_Opportunity { get; set; }

    public virtual DbSet<RL_Document_Product> RL_Document_Product { get; set; }

    public virtual DbSet<RL_Document_Shares> RL_Document_Shares { get; set; }

    public virtual DbSet<RL_Document_Task> RL_Document_Task { get; set; }

    public virtual DbSet<RL_Document_Ticket> RL_Document_Ticket { get; set; }

    public virtual DbSet<RL_Event_Activity> RL_Event_Activity { get; set; }

    public virtual DbSet<RL_Event_Contact> RL_Event_Contact { get; set; }

    public virtual DbSet<RL_Event_Firm> RL_Event_Firm { get; set; }

    public virtual DbSet<RL_Event_Proposal> RL_Event_Proposal { get; set; }

    public virtual DbSet<RL_Event_Users> RL_Event_Users { get; set; }

    public virtual DbSet<RL_Firm_Actions_Lists> RL_Firm_Actions_Lists { get; set; }

    public virtual DbSet<RL_Firm_Contacts> RL_Firm_Contacts { get; set; }

    public virtual DbSet<RL_Firm_List_Types> RL_Firm_List_Types { get; set; }

    public virtual DbSet<RL_Firm_Sectors> RL_Firm_Sectors { get; set; }

    public virtual DbSet<RL_Integration_Sets_User> RL_Integration_Sets_User { get; set; }

    public virtual DbSet<RL_Mail_Activity> RL_Mail_Activity { get; set; }

    public virtual DbSet<RL_Mail_Contact> RL_Mail_Contact { get; set; }

    public virtual DbSet<RL_Mail_Firm> RL_Mail_Firm { get; set; }

    public virtual DbSet<RL_Mail_Opportunity> RL_Mail_Opportunity { get; set; }

    public virtual DbSet<RL_Mail_Proposal> RL_Mail_Proposal { get; set; }

    public virtual DbSet<RL_Mail_Task> RL_Mail_Task { get; set; }

    public virtual DbSet<RL_Mail_Ticket> RL_Mail_Ticket { get; set; }

    public virtual DbSet<RL_Notes_Contact> RL_Notes_Contact { get; set; }

    public virtual DbSet<RL_Notes_Departments> RL_Notes_Departments { get; set; }

    public virtual DbSet<RL_Notes_Firm> RL_Notes_Firm { get; set; }

    public virtual DbSet<RL_Notes_User> RL_Notes_User { get; set; }

    public virtual DbSet<RL_Opportunity_Activity> RL_Opportunity_Activity { get; set; }

    public virtual DbSet<RL_Opportunity_Event> RL_Opportunity_Event { get; set; }

    public virtual DbSet<RL_Opportunity_Stage_Criteria> RL_Opportunity_Stage_Criteria { get; set; }

    public virtual DbSet<RL_Opportunity_Task> RL_Opportunity_Task { get; set; }

    public virtual DbSet<RL_Price_Types_Users> RL_Price_Types_Users { get; set; }

    public virtual DbSet<RL_Product_Activity> RL_Product_Activity { get; set; }

    public virtual DbSet<RL_Product_Event> RL_Product_Event { get; set; }

    public virtual DbSet<RL_Product_Firm> RL_Product_Firm { get; set; }

    public virtual DbSet<RL_Product_Opportunity> RL_Product_Opportunity { get; set; }

    public virtual DbSet<RL_Product_Ticket> RL_Product_Ticket { get; set; }

    public virtual DbSet<RL_Proposal_Activity> RL_Proposal_Activity { get; set; }

    public virtual DbSet<RL_Proposal_OtherFirms> RL_Proposal_OtherFirms { get; set; }

    public virtual DbSet<RL_Proposal_Stage_Criteria> RL_Proposal_Stage_Criteria { get; set; }

    public virtual DbSet<RL_Proposal_Task> RL_Proposal_Task { get; set; }

    public virtual DbSet<RL_Proposals_Documents> RL_Proposals_Documents { get; set; }

    public virtual DbSet<RL_SalesRep_Opportunity> RL_SalesRep_Opportunity { get; set; }

    public virtual DbSet<RL_Task_Activity> RL_Task_Activity { get; set; }

    public virtual DbSet<RL_Ticket_Activity> RL_Ticket_Activity { get; set; }

    public virtual DbSet<RL_Ticket_Event> RL_Ticket_Event { get; set; }

    public virtual DbSet<RL_Ticket_Personnel> RL_Ticket_Personnel { get; set; }

    public virtual DbSet<RL_Ticket_Proposal> RL_Ticket_Proposal { get; set; }

    public virtual DbSet<RL_Ticket_Task> RL_Ticket_Task { get; set; }

    public virtual DbSet<RL_User_Role> RL_User_Role { get; set; }

    public virtual DbSet<RL_User_Sales_Rep> RL_User_Sales_Rep { get; set; }

    public virtual DbSet<RL_User_Tasks> RL_User_Tasks { get; set; }

    public virtual DbSet<RL_Users_Departments> RL_Users_Departments { get; set; }

    public virtual DbSet<RL_Users_MySummaryItems> RL_Users_MySummaryItems { get; set; }

    public virtual DbSet<SS_CloudDrive_Settings> SS_CloudDrive_Settings { get; set; }

    public virtual DbSet<SS_DBUpdates> SS_DBUpdates { get; set; }

    public virtual DbSet<SS_FilePath_Setting> SS_FilePath_Setting { get; set; }

    public virtual DbSet<SS_Generated_Ids> SS_Generated_Ids { get; set; }

    public virtual DbSet<SS_IPS_Settings> SS_IPS_Settings { get; set; }

    public virtual DbSet<SS_ListView_Sizes> SS_ListView_Sizes { get; set; }

    public virtual DbSet<SS_Popup_Window_Sizes> SS_Popup_Window_Sizes { get; set; }

    public virtual DbSet<SS_SavedView> SS_SavedView { get; set; }

    public virtual DbSet<SS_SavedView_Columns> SS_SavedView_Columns { get; set; }

    public virtual DbSet<SS_Twitter_UserSettings> SS_Twitter_UserSettings { get; set; }

    public virtual DbSet<SS_User_Cache> SS_User_Cache { get; set; }

    public virtual DbSet<SS_User_Preferences_General> SS_User_Preferences_General { get; set; }

    public virtual DbSet<SS_User_Reminder> SS_User_Reminder { get; set; }

    public virtual DbSet<SS_User_Status> SS_User_Status { get; set; }

    public virtual DbSet<ST_Action_Authorization> ST_Action_Authorization { get; set; }

    public virtual DbSet<ST_Activity_Planning> ST_Activity_Planning { get; set; }

    public virtual DbSet<ST_Comment> ST_Comment { get; set; }

    public virtual DbSet<ST_Comment_Upvotes> ST_Comment_Upvotes { get; set; }

    public virtual DbSet<ST_Company_Info> ST_Company_Info { get; set; }

    public virtual DbSet<ST_Exchange_Rates> ST_Exchange_Rates { get; set; }

    public virtual DbSet<ST_Full_Search> ST_Full_Search { get; set; }

    public virtual DbSet<ST_Full_Search_Objects> ST_Full_Search_Objects { get; set; }

    public virtual DbSet<ST_IPS_Logs> ST_IPS_Logs { get; set; }

    public virtual DbSet<ST_Id_Starters> ST_Id_Starters { get; set; }

    public virtual DbSet<ST_Installed_Apps> ST_Installed_Apps { get; set; }

    public virtual DbSet<ST_Installed_Apps_Names> ST_Installed_Apps_Names { get; set; }

    public virtual DbSet<ST_MySummary> ST_MySummary { get; set; }

    public virtual DbSet<ST_MySummary_Cache> ST_MySummary_Cache { get; set; }

    public virtual DbSet<ST_MySummary_Items> ST_MySummary_Items { get; set; }

    public virtual DbSet<ST_Prepared_Form_Export_Types> ST_Prepared_Form_Export_Types { get; set; }

    public virtual DbSet<ST_Proposal_Category> ST_Proposal_Category { get; set; }

    public virtual DbSet<ST_Proposals_ReCalculate_Fields> ST_Proposals_ReCalculate_Fields { get; set; }

    public virtual DbSet<ST_Reports> ST_Reports { get; set; }

    public virtual DbSet<ST_Scheduler_User_Settings> ST_Scheduler_User_Settings { get; set; }

    public virtual DbSet<ST_Shortcuts> ST_Shortcuts { get; set; }

    public virtual DbSet<ST_Store_Apps> ST_Store_Apps { get; set; }

    public virtual DbSet<ST_Task_Assign> ST_Task_Assign { get; set; }

    public virtual DbSet<ST_Task_State> ST_Task_State { get; set; }

    public virtual DbSet<ST_Ticket_Assign> ST_Ticket_Assign { get; set; }

    public virtual DbSet<ST_Ticket_State> ST_Ticket_State { get; set; }

    public virtual DbSet<ST_Update_Schema_Logic> ST_Update_Schema_Logic { get; set; }

    public virtual DbSet<ST_User> ST_User { get; set; }

    public virtual DbSet<ST_UserMessages> ST_UserMessages { get; set; }

    public virtual DbSet<ST_UserShortcuts> ST_UserShortcuts { get; set; }

    public virtual DbSet<ST_UserWidgets> ST_UserWidgets { get; set; }

    public virtual DbSet<ST_User_Access_Rights> ST_User_Access_Rights { get; set; }

    public virtual DbSet<ST_User_Apps> ST_User_Apps { get; set; }

    public virtual DbSet<ST_User_Apps_Names> ST_User_Apps_Names { get; set; }

    public virtual DbSet<ST_User_DockPanelLayouts> ST_User_DockPanelLayouts { get; set; }

    public virtual DbSet<ST_User_Logs> ST_User_Logs { get; set; }

    public virtual DbSet<ST_User_Works> ST_User_Works { get; set; }

    public virtual DbSet<SetrowLists> SetrowLists { get; set; }

    public virtual DbSet<TEKLIF> TEKLIF { get; set; }

    public virtual DbSet<TICKET_USERS> TICKET_USERS { get; set; }

    public virtual DbSet<X1_Analysis> X1_Analysis { get; set; }

    public virtual DbSet<X1_AuditDataItemPersistent> X1_AuditDataItemPersistent { get; set; }

    public virtual DbSet<X1_AuditedObjectWeakReference> X1_AuditedObjectWeakReference { get; set; }

    public virtual DbSet<X1_KpiDefinition> X1_KpiDefinition { get; set; }

    public virtual DbSet<X1_KpiHistoryItem> X1_KpiHistoryItem { get; set; }

    public virtual DbSet<X1_KpiInstance> X1_KpiInstance { get; set; }

    public virtual DbSet<X1_KpiScorecard> X1_KpiScorecard { get; set; }

    public virtual DbSet<X1_Kpi_Scorecards_Indicators> X1_Kpi_Scorecards_Indicators { get; set; }

    public virtual DbSet<X1_ModelDifference> X1_ModelDifference { get; set; }

    public virtual DbSet<X1_ModelDifferenceAspect> X1_ModelDifferenceAspect { get; set; }

    public virtual DbSet<X1_ModuleInfo> X1_ModuleInfo { get; set; }

    public virtual DbSet<X1_ReportDataV2> X1_ReportDataV2 { get; set; }

    public virtual DbSet<X1_SecuritySystemMemberPermissionsObject> X1_SecuritySystemMemberPermissionsObject { get; set; }

    public virtual DbSet<X1_SecuritySystemObjectPermissionsObject> X1_SecuritySystemObjectPermissionsObject { get; set; }

    public virtual DbSet<X1_SecuritySystemRole> X1_SecuritySystemRole { get; set; }

    public virtual DbSet<X1_SecuritySystemTypePermissionsObject> X1_SecuritySystemTypePermissionsObject { get; set; }

    public virtual DbSet<X1_SecuritySystemUser> X1_SecuritySystemUser { get; set; }

    public virtual DbSet<X1_SecurityUserBase> X1_SecurityUserBase { get; set; }

    public virtual DbSet<X1_Security_System_Parent_Child_Roles> X1_Security_System_Parent_Child_Roles { get; set; }

    public virtual DbSet<X1_Security_System_User_Roles> X1_Security_System_User_Roles { get; set; }

    public virtual DbSet<X1_XPObjectType> X1_XPObjectType { get; set; }

    public virtual DbSet<X1_XPWeakReference> X1_XPWeakReference { get; set; }

    public virtual DbSet<X1_XpoInstanceKey> X1_XpoInstanceKey { get; set; }

    public virtual DbSet<X1_XpoRunningWorkflowInstanceInfo> X1_XpoRunningWorkflowInstanceInfo { get; set; }

    public virtual DbSet<X1_XpoStartWorkflowRequest> X1_XpoStartWorkflowRequest { get; set; }

    public virtual DbSet<X1_XpoState> X1_XpoState { get; set; }

    public virtual DbSet<X1_XpoStateAppearance> X1_XpoStateAppearance { get; set; }

    public virtual DbSet<X1_XpoStateMachine> X1_XpoStateMachine { get; set; }

    public virtual DbSet<X1_XpoTrackingRecord> X1_XpoTrackingRecord { get; set; }

    public virtual DbSet<X1_XpoTransition> X1_XpoTransition { get; set; }

    public virtual DbSet<X1_XpoUserActivityVersion> X1_XpoUserActivityVersion { get; set; }

    public virtual DbSet<X1_XpoWorkflowDefinition> X1_XpoWorkflowDefinition { get; set; }

    public virtual DbSet<X1_XpoWorkflowInstance> X1_XpoWorkflowInstance { get; set; }

    public virtual DbSet<X1_XpoWorkflowInstanceControlCommandRequest> X1_XpoWorkflowInstanceControlCommandRequest { get; set; }

    public virtual DbSet<XF_CustomAppearanceRule> XF_CustomAppearanceRule { get; set; }

    public virtual DbSet<XF_GuidWeakManyToMany> XF_GuidWeakManyToMany { get; set; }

    public virtual DbSet<XF_XPObjectSet> XF_XPObjectSet { get; set; }

    public virtual DbSet<XF_XPObjectSetItem> XF_XPObjectSetItem { get; set; }

    public virtual DbSet<XF_XPWeakManyToMany> XF_XPWeakManyToMany { get; set; }

    public virtual DbSet<XPWeakReference> XPWeakReference { get; set; }

    public virtual DbSet<XP_AnonymousLoginOperationPermissionData> XP_AnonymousLoginOperationPermissionData { get; set; }

    public virtual DbSet<XP_DashboardDefinition> XP_DashboardDefinition { get; set; }

    public virtual DbSet<XP_Dashboard_Definitions_Roles> XP_Dashboard_Definitions_Roles { get; set; }

    public virtual DbSet<XP_MyDetailsOperationPermissionData> XP_MyDetailsOperationPermissionData { get; set; }

    public virtual DbSet<XP_XpandPermissionData> XP_XpandPermissionData { get; set; }

    public virtual DbSet<XP_XpandUser> XP_XpandUser { get; set; }

    public virtual DbSet<XpoState> XpoState { get; set; }

    public virtual DbSet<XpoStateAppearance> XpoStateAppearance { get; set; }

    public virtual DbSet<XpoStateMachine> XpoStateMachine { get; set; }

    public virtual DbSet<XpoTransition> XpoTransition { get; set; }

    public virtual DbSet<ZD_Copy_Fields> ZD_Copy_Fields { get; set; }

    public virtual DbSet<ZD_Default_Values> ZD_Default_Values { get; set; }

    public virtual DbSet<ZD_External_Link_Object> ZD_External_Link_Object { get; set; }

    public virtual DbSet<ZD_External_Links> ZD_External_Links { get; set; }

    public virtual DbSet<ZD_Extra_Fields> ZD_Extra_Fields { get; set; }

    public virtual DbSet<ZD_Extra_Fields_Columns> ZD_Extra_Fields_Columns { get; set; }

    public virtual DbSet<ZD_Search_Extensions> ZD_Search_Extensions { get; set; }

    public virtual DbSet<foProductSelectionItem> foProductSelectionItem { get; set; }

    public virtual DbSet<foProductSelectionList> foProductSelectionList { get; set; }

    public virtual DbSet<foProductVariant> foProductVariant { get; set; }

    public virtual DbSet<foProductVariantItem> foProductVariantItem { get; set; }

    public virtual DbSet<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions> logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AA_CompetitorManagement_Opportunity>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY");

            entity.HasIndex(e => e.CompetitorOid, "İCOMPETİTOROİD_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedOpportunity, "İRELATEDOPPORTUNİTY_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.CompetitorO).WithMany(p => p.AA_CompetitorManagement_Opportunity)
                .HasForeignKey(d => d.CompetitorOid)
                .HasConstraintName("FK_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY_COMPETİTOROİD");

            entity.HasOne(d => d.RelatedOpportunityNavigation).WithMany(p => p.AA_CompetitorManagement_Opportunity)
                .HasForeignKey(d => d.RelatedOpportunity)
                .HasConstraintName("FK_AA_COMPETİTORMANAGEMENT_OPPORTUNİTY_RELATEDOPPORTUNİTY");
        });

        modelBuilder.Entity<AA_CompetitorManagement_Proposals>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_COMPETİTORMANAGEMENT_PROPOSALS");

            entity.HasIndex(e => e.CompetitorOid, "İCOMPETİTOROİD_AA_COMPETİTORMANAGEMENT_PROPOSALS").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_COMPETİTORMANAGEMENT_PROPOSALS").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposal, "İRELATEDPROPOSAL_AA_COMPETİTORMANAGEMENT_PROPOSALS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.CompetitorO).WithMany(p => p.AA_CompetitorManagement_Proposals)
                .HasForeignKey(d => d.CompetitorOid)
                .HasConstraintName("FK_AA_COMPETİTORMANAGEMENT_PROPOSALS_COMPETİTOROİD");

            entity.HasOne(d => d.RelatedProposalNavigation).WithMany(p => p.AA_CompetitorManagement_Proposals)
                .HasForeignKey(d => d.RelatedProposal)
                .HasConstraintName("FK_AA_COMPETİTORMANAGEMENT_PROPOSALS_RELATEDPROPOSAL");
        });

        modelBuilder.Entity<AA_CompetitorManagement_Reason>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_COMPETİTORMANAGEMENT_REASON");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_COMPETİTORMANAGEMENT_REASON").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ReasonCode).HasMaxLength(100);
            entity.Property(e => e.ReasonDescription).HasMaxLength(100);
        });

        modelBuilder.Entity<AA_CompetitorManagement_UserSettings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_COMPETİTORMANAGEMENT_USERSETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_COMPETİTORMANAGEMENT_USERSETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "İUSEROİD_AA_COMPETİTORMANAGEMENT_USERSETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.UserO).WithMany(p => p.AA_CompetitorManagement_UserSettings)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_AA_COMPETİTORMANAGEMENT_USERSETTİNGS_USEROİD");
        });

        modelBuilder.Entity<AA_Email_Report>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_EMAİL_REPORT");

            entity.HasIndex(e => e.Contact, "İCONTACT_AA_EMAİL_REPORT").HasFillFactor(70);

            entity.HasIndex(e => e.Firm, "İFİRM_AA_EMAİL_REPORT").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_EMAİL_REPORT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AccountName).HasMaxLength(100);
            entity.Property(e => e.ApiKey).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasMaxLength(100);
            entity.Property(e => e.EmailAddress).HasMaxLength(321);
            entity.Property(e => e.EmailMessageId).HasMaxLength(100);
            entity.Property(e => e.ListType).HasMaxLength(100);
            entity.Property(e => e.MainPacketId).HasMaxLength(100);
            entity.Property(e => e.PacketId).HasMaxLength(100);
            entity.Property(e => e.ReceiverEmail).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasMaxLength(100);
            entity.Property(e => e.SessionId).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.StatusDescription).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.ContactNavigation).WithMany(p => p.AA_Email_Report)
                .HasForeignKey(d => d.Contact)
                .HasConstraintName("FK_AA_EMAİL_REPORT_CONTACT");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.AA_Email_Report)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_AA_EMAİL_REPORT_FİRM");
        });

        modelBuilder.Entity<AA_Email_Report_MT>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_EMAİL_REPORT_MT");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_EMAİL_REPORT_MT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ListType).HasMaxLength(100);
            entity.Property(e => e.MainPacketId).HasMaxLength(100);
            entity.Property(e => e.PacketId).HasMaxLength(100);
            entity.Property(e => e.SendCount).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<AA_Email_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_EMAİL_SETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_EMAİL_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ApiKey).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<AA_GoogleCalendar_Events>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_GOOGLECALENDAR_EVENTS");

            entity.HasIndex(e => e.Event, "İEVENT_AA_GOOGLECALENDAR_EVENTS").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_GOOGLECALENDAR_EVENTS").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_AA_GOOGLECALENDAR_EVENTS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.GoogleCalendarId).HasMaxLength(300);
            entity.Property(e => e.GoogleEventId).HasMaxLength(300);

            entity.HasOne(d => d.EventNavigation).WithMany(p => p.AA_GoogleCalendar_Events)
                .HasForeignKey(d => d.Event)
                .HasConstraintName("FK_AA_GOOGLECALENDAR_EVENTS_EVENT");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.AA_GoogleCalendar_Events)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_AA_GOOGLECALENDAR_EVENTS_USER");
        });

        modelBuilder.Entity<AA_GoogleCalendar_UserCalendar>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_GOOGLECALENDAR_USERCALENDAR");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_GOOGLECALENDAR_USERCALENDAR").HasFillFactor(70);

            entity.HasIndex(e => e.UserSettingOid, "İUSERSETTİNGOİD_AA_GOOGLECALENDAR_USERCALENDAR").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LastSyncDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.UserSettingO).WithMany(p => p.AA_GoogleCalendar_UserCalendar)
                .HasForeignKey(d => d.UserSettingOid)
                .HasConstraintName("FK_AA_GOOGLECALENDAR_USERCALENDAR_USERSETTİNGOİD");
        });

        modelBuilder.Entity<AA_GoogleCalendar_UserSettings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_GOOGLECALENDAR_USERSETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_GOOGLECALENDAR_USERSETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_AA_GOOGLECALENDAR_USERSETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.AA_GoogleCalendar_UserSettings)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_AA_GOOGLECALENDAR_USERSETTİNGS_USER");
        });

        modelBuilder.Entity<AA_GoogleMaps_GeoPoint>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Contact, "iContact_AA_GoogleMaps_GeoPoint").HasFillFactor(70);

            entity.HasIndex(e => e.Firm, "iFirm_AA_GoogleMaps_GeoPoint").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_AA_GoogleMaps_GeoPoint").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedAddress, "iRelatedAddress_AA_GoogleMaps_GeoPoint").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Latitude).HasColumnType("money");
            entity.Property(e => e.Longtitude).HasColumnType("money");
            entity.Property(e => e.MapTypeId).HasMaxLength(100);
            entity.Property(e => e.ZoomValue).HasColumnType("money");

            entity.HasOne(d => d.ContactNavigation).WithMany(p => p.AA_GoogleMaps_GeoPoint)
                .HasForeignKey(d => d.Contact)
                .HasConstraintName("FK_AA_GoogleMaps_GeoPoint_Contact");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.AA_GoogleMaps_GeoPoint)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_AA_GoogleMaps_GeoPoint_Firm");

            entity.HasOne(d => d.RelatedAddressNavigation).WithMany(p => p.AA_GoogleMaps_GeoPoint)
                .HasForeignKey(d => d.RelatedAddress)
                .HasConstraintName("FK_AA_GoogleMaps_GeoPoint_RelatedAddress");
        });

        modelBuilder.Entity<AA_GoogleMaps_MapSettings>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_AA_GoogleMaps_MapSettings").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.MapTypeId).HasMaxLength(100);
        });

        modelBuilder.Entity<AA_GoogleMaps_Nearby>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CurrentUser, "iCurrentUser_AA_GoogleMaps_Nearby").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_AA_GoogleMaps_Nearby").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DistanceLimit).HasColumnType("money");

            entity.HasOne(d => d.CurrentUserNavigation).WithMany(p => p.AA_GoogleMaps_Nearby)
                .HasForeignKey(d => d.CurrentUser)
                .HasConstraintName("FK_AA_GoogleMaps_Nearby_CurrentUser");
        });

        modelBuilder.Entity<AA_Sms_Report>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_SMS_REPORT");

            entity.HasIndex(e => e.Contact, "İCONTACT_AA_SMS_REPORT").HasFillFactor(70);

            entity.HasIndex(e => e.Firm, "İFİRM_AA_SMS_REPORT").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_SMS_REPORT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ListType).HasMaxLength(100);
            entity.Property(e => e.MessageContent).HasMaxLength(100);
            entity.Property(e => e.MsgID).HasMaxLength(100);
            entity.Property(e => e.PacketId).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.StatusDescription).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.ContactNavigation).WithMany(p => p.AA_Sms_Report)
                .HasForeignKey(d => d.Contact)
                .HasConstraintName("FK_AA_SMS_REPORT_CONTACT");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.AA_Sms_Report)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_AA_SMS_REPORT_FİRM");
        });

        modelBuilder.Entity<AA_Sms_Report_MT>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_SMS_REPORT_MT");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_SMS_REPORT_MT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ListType).HasMaxLength(100);
            entity.Property(e => e.PacketId).HasMaxLength(100);
            entity.Property(e => e.SendCount).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<AA_Sms_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_AA_SMS_SETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_AA_SMS_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CompanyCode).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<AKTIVITE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AKTIVITE");

            entity.Property(e => e.AKTIVITE_ID)
                .HasMaxLength(42)
                .HasColumnName("AKTIVITE ID");
            entity.Property(e => e.DURUM).HasMaxLength(100);
            entity.Property(e => e.FIRMA_KOD)
                .HasMaxLength(42)
                .HasColumnName("FIRMA KOD");
            entity.Property(e => e.FIRMA_UNVAN)
                .HasMaxLength(200)
                .HasColumnName("FIRMA UNVAN");
            entity.Property(e => e.KATEGORI).HasMaxLength(100);
            entity.Property(e => e.KISI).HasMaxLength(100);
            entity.Property(e => e.SATIS_TEMSILCISI)
                .HasMaxLength(100)
                .HasColumnName("SATIS TEMSILCISI");
            entity.Property(e => e.TARIH).HasColumnType("datetime");
            entity.Property(e => e.TUR).HasMaxLength(100);
        });

        modelBuilder.Entity<Analysis>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_Analysis").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ObjectTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<AuditDataItemPersistent>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AuditedObject, "iAuditedObject_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.ModifiedOn, "iModifiedOn_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.NewObject, "iNewObject_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.OldObject, "iOldObject_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.OperationType, "iOperationType_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.UserName, "iUserName_AuditDataItemPersistent").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(2048);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NewValue).HasMaxLength(1024);
            entity.Property(e => e.OldValue).HasMaxLength(1024);
            entity.Property(e => e.OperationType).HasMaxLength(100);
            entity.Property(e => e.PropertyName).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.AuditedObjectNavigation).WithMany(p => p.AuditDataItemPersistent)
                .HasForeignKey(d => d.AuditedObject)
                .HasConstraintName("FK_AuditDataItemPersistent_AuditedObject");

            entity.HasOne(d => d.NewObjectNavigation).WithMany(p => p.AuditDataItemPersistentNewObjectNavigation)
                .HasForeignKey(d => d.NewObject)
                .HasConstraintName("FK_AuditDataItemPersistent_NewObject");

            entity.HasOne(d => d.OldObjectNavigation).WithMany(p => p.AuditDataItemPersistentOldObjectNavigation)
                .HasForeignKey(d => d.OldObject)
                .HasConstraintName("FK_AuditDataItemPersistent_OldObject");
        });

        modelBuilder.Entity<AuditedObjectWeakReference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(250);

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.AuditedObjectWeakReference)
                .HasForeignKey<AuditedObjectWeakReference>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditedObjectWeakReference_Oid");
        });

        modelBuilder.Entity<BulkEmailHelper>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_BULKEMAİLHELPER");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_BULKEMAİLHELPER").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
        });

        modelBuilder.Entity<CT_Activity_Category>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Activity_Category").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Activity_Category").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Activity_Category").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActivityCategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Activity_Category_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Activity_Category__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Activity_Category_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Activity_Category__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Activity_States>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Activity_States").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Activity_States").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Activity_States").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActivityStateDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Activity_States_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Activity_States__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Activity_States_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Activity_States__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Activity_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Activity_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Activity_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Activity_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActivityTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Activity_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Activity_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Activity_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Activity_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Campaign_Cost_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Campaign_Cost_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Campaign_Cost_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Campaign_Cost_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CampaignCostTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Campaign_Cost_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Campaign_Cost_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Campaign_Cost_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Campaign_Cost_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Campaign_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Campaign_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Campaign_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Campaign_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CampaignTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Campaign_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Campaign_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Campaign_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Campaign_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Contact_Roles>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Contact_Roles").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Contact_Roles").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Contact_Roles").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RoleCode).HasMaxLength(30);
            entity.Property(e => e.RoleName).HasMaxLength(30);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Contact_Roles_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Contact_Roles__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Contact_Roles_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Contact_Roles__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Contract_States>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Contract_States").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Contract_States").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Contract_States").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContractStateDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Contract_States_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Contract_States__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Contract_States_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Contract_States__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Contract_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Contract_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Contract_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Contract_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContractTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Contract_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Contract_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Contract_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Contract_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Currency_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Currency_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Currency_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Currency_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CentsNotation).HasMaxLength(10);
            entity.Property(e => e.CurrencySign).HasMaxLength(5);
            entity.Property(e => e.Description).HasMaxLength(52);
            entity.Property(e => e.ShortNotation).HasMaxLength(10);
            entity.Property(e => e.TCMBNotation).HasMaxLength(10);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Currency_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Currency_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Currency_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Currency_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Firm_Roles>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Firm_Roles").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Firm_Roles").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Firm_Roles").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RoleCode).HasMaxLength(30);
            entity.Property(e => e.RoleName).HasMaxLength(30);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Firm_Roles_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Firm_Roles__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Firm_Roles_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Firm_Roles__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Incoterm>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Incoterm").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Incoterm").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Incoterm").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.IncotermCode).HasMaxLength(100);
            entity.Property(e => e.IncotermDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Incoterm_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Incoterm__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Incoterm_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Incoterm__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Job_Titles>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Job_Titles").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Job_Titles").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Job_Titles").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.JobTitleName).HasMaxLength(30);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Job_Titles_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Job_Titles__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Job_Titles_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Job_Titles__LastModifiedBy");
        });

        modelBuilder.Entity<CT_List_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_List_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_List_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_List_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ListTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_List_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_List_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_List_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_List_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Opportunity_Sources>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Opportunity_Sources").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Opportunity_Sources").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Opportunity_Sources").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.OpportunitySourceDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Opportunity_Sources_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Opportunity_Sources__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Opportunity_Sources_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Opportunity_Sources__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Opportunity_Stages>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Opportunity_Stages").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Opportunity_Stages").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Opportunity_Stages").HasFillFactor(70);

            entity.HasIndex(e => e._Order, "İ_ORDER_CT_OPPORTUNİTY_STAGES").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.StageCode).HasMaxLength(100);
            entity.Property(e => e.StageDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Opportunity_Stages_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Opportunity_Stages__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Opportunity_Stages_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Opportunity_Stages__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Opportunity_Stages_Criteria>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Opportunity_Stages_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Opportunity_Stages_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Opportunity_Stages_Criteria").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ObjectType).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Opportunity_Stages_Criteria_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Opportunity_Stages_Criteria__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Opportunity_Stages_Criteria_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Opportunity_Stages_Criteria__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Opportunity_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Opportunity_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Opportunity_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Opportunity_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.OpportunityTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Opportunity_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Opportunity_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Opportunity_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Opportunity_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Personnel>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_CT_PERSONNEL");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_CT_PERSONNEL").HasFillFactor(70);

            entity.HasIndex(e => e.PersonnelPersonInfo, "İPERSONNELPERSONINFO_CT_PERSONNEL").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_CT_PERSONNEL").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_CT_PERSONNEL").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PersonnelPersonInfoNavigation).WithMany(p => p.CT_Personnel)
                .HasForeignKey(d => d.PersonnelPersonInfo)
                .HasConstraintName("FK_CT_PERSONNEL_PERSONNELPERSONINFO");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Personnel_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_PERSONNEL__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Personnel_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_PERSONNEL__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<CT_Price_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Price_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Price_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Price_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.PriceTypeDescription).HasMaxLength(60);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Price_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Price_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Price_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Price_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Product_Classes>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Product_Classes").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Product_Classes").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Product_Classes").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProductClassCode).HasMaxLength(12);
            entity.Property(e => e.ProductClassDescription).HasMaxLength(70);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Product_Classes_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Product_Classes__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Product_Classes_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Product_Classes__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Product_Groups>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Product_Groups").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Product_Groups").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Product_Groups").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProductGroupCode).HasMaxLength(12);
            entity.Property(e => e.ProductGroupDescription).HasMaxLength(70);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Product_Groups_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Product_Groups__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Product_Groups_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Product_Groups__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Proposal_Approval_Rules>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Proposal_Approval_Rules").HasFillFactor(70);

            entity.HasIndex(e => e.WillBeApprovedBy, "iWillBeApprovedBy_CT_Proposal_Approval_Rules").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Proposal_Approval_Rules").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Proposal_Approval_Rules").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RuleDescription).HasMaxLength(100);
            entity.Property(e => e.RuleType).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.WillBeApprovedByNavigation).WithMany(p => p.CT_Proposal_Approval_RulesWillBeApprovedByNavigation)
                .HasForeignKey(d => d.WillBeApprovedBy)
                .HasConstraintName("FK_CT_Proposal_Approval_Rules_WillBeApprovedBy");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Proposal_Approval_Rules_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Proposal_Approval_Rules__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Proposal_Approval_Rules_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Proposal_Approval_Rules__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Proposal_Groups>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Proposal_Groups").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Proposal_Groups").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Proposal_Groups").HasFillFactor(70);

            entity.HasIndex(e => e._TeklifTuru, "İ_TEKLİFTURU_CT_PROPOSAL_GROUPS");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProposalGroupName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Proposal_Groups_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Proposal_Groups__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Proposal_Groups_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Proposal_Groups__LastModifiedBy");

            entity.HasOne(d => d._TeklifTuruNavigation).WithMany(p => p.CT_Proposal_Groups)
                .HasForeignKey(d => d._TeklifTuru)
                .HasConstraintName("FK_CT_PROPOSAL_GROUPS__TEKLİFTURU");
        });

        modelBuilder.Entity<CT_Proposal_Stages>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Proposal_Stages").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Proposal_Stages").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Proposal_Stages").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.StageDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Proposal_Stages_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Proposal_Stages__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Proposal_Stages_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Proposal_Stages__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Proposal_Stages_Criteria>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Proposal_Stages_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Proposal_Stages_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Proposal_Stages_Criteria").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ObjectType).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Proposal_Stages_Criteria_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Proposal_Stages_Criteria__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Proposal_Stages_Criteria_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Proposal_Stages_Criteria__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Proposal_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Proposal_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Proposal_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Proposal_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProposalTypeName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Proposal_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Proposal_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Proposal_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Proposal_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Reference_Sources>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Reference_Sources").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Reference_Sources").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Reference_Sources").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ReferenceSourceName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Reference_Sources_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Reference_Sources__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Reference_Sources_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Reference_Sources__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Role>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Role").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Role").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.CT_Role)
                .HasForeignKey<CT_Role>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_Role_Oid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Role_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Role__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Role_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Role__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Sales_Area>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Sales_Area").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Sales_Area").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Sales_Area").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AreaName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Sales_Area_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Sales_Area__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Sales_Area_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Sales_Area__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Sales_Rep>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e.SalesArea, "iSalesArea_CT_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRepPersonInfo, "iSalesRepPersonInfo_CT_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e._RelatedUser, "İ_RELATEDUSER_CT_SALES_REP");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ERPSalesman).HasMaxLength(41);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._photoBase64Url).HasMaxLength(100);

            entity.HasOne(d => d.SalesAreaNavigation).WithMany(p => p.CT_Sales_Rep)
                .HasForeignKey(d => d.SalesArea)
                .HasConstraintName("FK_CT_Sales_Rep_SalesArea");

            entity.HasOne(d => d.SalesRepPersonInfoNavigation).WithMany(p => p.CT_Sales_Rep)
                .HasForeignKey(d => d.SalesRepPersonInfo)
                .HasConstraintName("FK_CT_Sales_Rep_SalesRepPersonInfo");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Sales_Rep_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Sales_Rep__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Sales_Rep_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Sales_Rep__LastModifiedBy");

            entity.HasOne(d => d._RelatedUserNavigation).WithMany(p => p.CT_Sales_Rep_RelatedUserNavigation)
                .HasForeignKey(d => d._RelatedUser)
                .HasConstraintName("FK_CT_SALES_REP__RELATEDUSER");
        });

        modelBuilder.Entity<CT_Sectors>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Sectors").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Sectors").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Sectors").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SectorName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Sectors_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Sectors__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Sectors_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Sectors__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Sub_Sectors>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Sub_Sectors").HasFillFactor(70);

            entity.HasIndex(e => e.MainSector, "iMainSector_CT_Sub_Sectors").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Sub_Sectors").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Sub_Sectors").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SubSectorName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MainSectorNavigation).WithMany(p => p.CT_Sub_Sectors)
                .HasForeignKey(d => d.MainSector)
                .HasConstraintName("FK_CT_Sub_Sectors_MainSector");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Sub_Sectors_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Sub_Sectors__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Sub_Sectors_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Sub_Sectors__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Ticket_Main_Category>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Ticket_Main_Category").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Ticket_Main_Category").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Ticket_Main_Category").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TicketMainCategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Ticket_Main_Category_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Ticket_Main_Category__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Ticket_Main_Category_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Ticket_Main_Category__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Ticket_States>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Ticket_States").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Ticket_States").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Ticket_States").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TicketStateDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Ticket_States_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Ticket_States__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Ticket_States_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Ticket_States__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Ticket_Sub_Category>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Ticket_Sub_Category").HasFillFactor(70);

            entity.HasIndex(e => e.MainCategory, "iMainCategory_CT_Ticket_Sub_Category").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Ticket_Sub_Category").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Ticket_Sub_Category").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TicketSubCategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MainCategoryNavigation).WithMany(p => p.CT_Ticket_Sub_Category)
                .HasForeignKey(d => d.MainCategory)
                .HasConstraintName("FK_CT_Ticket_Sub_Category_MainCategory");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Ticket_Sub_Category_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Ticket_Sub_Category__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Ticket_Sub_Category_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Ticket_Sub_Category__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Ticket_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Ticket_Types").HasFillFactor(70);

            entity.HasIndex(e => e.SubCategory, "iSubCategory_CT_Ticket_Types").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Ticket_Types").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Ticket_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TicketTypeDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.SubCategoryNavigation).WithMany(p => p.CT_Ticket_Types)
                .HasForeignKey(d => d.SubCategory)
                .HasConstraintName("FK_CT_Ticket_Types_SubCategory");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Ticket_Types_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Ticket_Types__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Ticket_Types_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Ticket_Types__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Units>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Units").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Units").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Units").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UnitCode).HasMaxLength(21);
            entity.Property(e => e.UnitDescription).HasMaxLength(77);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Units_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Units__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Units_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Units__LastModifiedBy");
        });

        modelBuilder.Entity<CT_Units_Collections>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_Units_Collections").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_Units_Collections").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_Units_Collections").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UnitCollectionCode).HasMaxLength(25);
            entity.Property(e => e.UnitCollectionDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_Units_Collections_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_Units_Collections__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_Units_Collections_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_Units_Collections__LastModifiedBy");
        });

        modelBuilder.Entity<CT_User_Access_Definitions>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_User_Access_Definitions").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AccessDefinition).HasMaxLength(100);
            entity.Property(e => e.LanguageId).HasMaxLength(10);
            entity.Property(e => e.ModuleId).HasMaxLength(30);
        });

        modelBuilder.Entity<CT_User_Departments>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_CT_User_Departments").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_CT_User_Departments").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_CT_User_Departments").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.CT_User_Departments_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_CT_USER_DEPARTMENTS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.CT_User_Departments_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_CT_USER_DEPARTMENTS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<CustomAppearanceRule>(entity =>
        {
            entity.Property(e => e.CriteriaObjectType).HasMaxLength(1000);
            entity.Property(e => e.Method).HasMaxLength(100);
            entity.Property(e => e.TargetItems).HasMaxLength(100);
        });

        modelBuilder.Entity<DESTEKKAYDI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DESTEKKAYDI");

            entity.Property(e => e.ALT_KATEGORI)
                .HasMaxLength(100)
                .HasColumnName("ALT KATEGORI");
            entity.Property(e => e.ANA_KATEGORI)
                .HasMaxLength(100)
                .HasColumnName("ANA KATEGORI");
            entity.Property(e => e.ATANAN).HasMaxLength(100);
            entity.Property(e => e.BAS_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("BAS TARIHI");
            entity.Property(e => e.DEPARTMAN).HasMaxLength(100);
            entity.Property(e => e.DESTEK_ID)
                .HasMaxLength(100)
                .HasColumnName("DESTEK ID");
            entity.Property(e => e.FIRMA_KOD)
                .HasMaxLength(42)
                .HasColumnName("FIRMA KOD");
            entity.Property(e => e.FIRMA_UNVAN)
                .HasMaxLength(200)
                .HasColumnName("FIRMA UNVAN");
            entity.Property(e => e.KISI).HasMaxLength(302);
            entity.Property(e => e.MUSTERI_TALEBI).HasColumnName("MUSTERI TALEBI");
            entity.Property(e => e.TMM_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("TMM TARIHI");
            entity.Property(e => e.TUR).HasMaxLength(100);
            entity.Property(e => e.YAPILAN_ISLEM).HasColumnName("YAPILAN ISLEM");
        });

        modelBuilder.Entity<DashboardDefinitionDashboardDefinitions>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.DashboardDefinitions, "iDashboardDefinitions_DashboardDefinitionDashboardDefinitions");

            entity.HasIndex(e => new { e.Roles, e.DashboardDefinitions }, "iRolesDashboardDefinitions_DashboardDefinitionDashboardDefinitions").IsUnique();

            entity.HasIndex(e => e.Roles, "iRoles_DashboardDefinitionDashboardDefinitions");

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DashboardDefinitionsNavigation).WithMany(p => p.DashboardDefinitionDashboardDefinitions)
                .HasForeignKey(d => d.DashboardDefinitions)
                .HasConstraintName("FK_DashboardDefinitionDashboardDefinitions_DashboardDefinitions");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.DashboardDefinitionDashboardDefinitions)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_DashboardDefinitionDashboardDefinitions_Roles");
        });

        modelBuilder.Entity<EI_Contact_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.ContactOid, "iContactOid_EI_Contact_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Contact_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Contact_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Contact_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Contact_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ContactO).WithMany(p => p.EI_Contact_Relations)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_EI_Contact_Relations_ContactOid");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Contact_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Contact_Relations_SetOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Contact_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Contact_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Contact_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Contact_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Firm_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Firm_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Firm_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Firm_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Firm_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Firm_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Firm_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Firm_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Firm_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_EI_Firm_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Firm_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Firm_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Firm_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Firm_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(200);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.FirmO).WithMany(p => p.EI_Firm_Relations)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_EI_Firm_Relations_FirmOid");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Firm_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Firm_Relations_SetOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Firm_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Firm_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Firm_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Firm_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Integration_Sets>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Integration_Sets").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Integration_Sets").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Integration_Sets").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMDatabaseName).HasMaxLength(100);
            entity.Property(e => e.CRMDatabasePassword).HasMaxLength(100);
            entity.Property(e => e.CRMDatabaseServer).HasMaxLength(100);
            entity.Property(e => e.CRMDatabaseUser).HasMaxLength(100);
            entity.Property(e => e.ERPApplicationPassword).HasMaxLength(100);
            entity.Property(e => e.ERPApplicationUser).HasMaxLength(100);
            entity.Property(e => e.ERPDatabaseName).HasMaxLength(100);
            entity.Property(e => e.ERPDatabasePassword).HasMaxLength(100);
            entity.Property(e => e.ERPDatabaseServer).HasMaxLength(100);
            entity.Property(e => e.ERPDatabaseUser).HasMaxLength(100);
            entity.Property(e => e.ERPMainDatabaseName).HasMaxLength(100);
            entity.Property(e => e.ERPWebServiceLink).HasMaxLength(100);
            entity.Property(e => e.NETSISInvoiceSerialDefaultValue).HasMaxLength(3);
            entity.Property(e => e.NetsisDefaultBranchCode).HasMaxLength(100);
            entity.Property(e => e.ServiceLink).HasMaxLength(100);
            entity.Property(e => e.SetDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Integration_Sets_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Integration_Sets__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Integration_Sets_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Integration_Sets__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Product_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Product_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Product_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Product_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Product_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Product_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Product_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Product_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Product_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Product_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.ProductOid, "iProductOid_EI_Product_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Product_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Product_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Product_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ProductO).WithMany(p => p.EI_Product_Relations)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_EI_Product_Relations_ProductOid");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Product_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Product_Relations_SetOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Product_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Product_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Product_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Product_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Proposal_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Proposal_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Proposal_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Proposal_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMXMLFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Proposal_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Proposal_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Proposal_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Proposal_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Proposal_Product_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Proposal_Product_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Proposal_Product_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Proposal_Product_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMXMLFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Proposal_Product_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Proposal_Product_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Proposal_Product_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Proposal_Product_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Proposal_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Proposal_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "iProposalOid_EI_Proposal_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Proposal_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Proposal_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Proposal_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(200);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.EI_Proposal_Relations)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_EI_Proposal_Relations_ProposalOid");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Proposal_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Proposal_Relations_SetOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Proposal_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Proposal_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Proposal_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Proposal_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Service_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Service_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Service_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Service_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Service_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Service_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Service_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Service_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Shipment_Address_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Shipment_Address_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Shipment_Address_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Shipment_Address_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Shipment_Address_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Shipment_Address_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Shipment_Address_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Shipment_Address_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Shipment_Address_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AddressOid, "iAddressOid_EI_Shipment_Address_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Shipment_Address_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Shipment_Address_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Shipment_Address_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Shipment_Address_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AddressO).WithMany(p => p.EI_Shipment_Address_Relations)
                .HasForeignKey(d => d.AddressOid)
                .HasConstraintName("FK_EI_Shipment_Address_Relations_AddressOid");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Shipment_Address_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Shipment_Address_Relations_SetOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Shipment_Address_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Shipment_Address_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Shipment_Address_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Shipment_Address_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Surcharge_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Surcharge_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Surcharge_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Surcharge_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CRMFieldName).HasMaxLength(100);
            entity.Property(e => e.CRMOriginalFieldName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ERPFieldName).HasMaxLength(100);
            entity.Property(e => e.IntegrationSetOid).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupSQLField).HasMaxLength(100);
            entity.Property(e => e.XMLPath).HasMaxLength(250);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Surcharge_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Surcharge_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Surcharge_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Surcharge_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Unit_Collection_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Unit_Collection_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Unit_Collection_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.UnitCollectionOid, "iUnitCollectionOid_EI_Unit_Collection_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Unit_Collection_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Unit_Collection_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Unit_Collection_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Unit_Collection_Relations_SetOid");

            entity.HasOne(d => d.UnitCollectionO).WithMany(p => p.EI_Unit_Collection_Relations)
                .HasForeignKey(d => d.UnitCollectionOid)
                .HasConstraintName("FK_EI_Unit_Collection_Relations_UnitCollectionOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Unit_Collection_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Unit_Collection_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Unit_Collection_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Unit_Collection_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_Unit_Relations>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_EI_Unit_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "iSetOid_EI_Unit_Relations").HasFillFactor(70);

            entity.HasIndex(e => e.UnitOid, "iUnitOid_EI_Unit_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_EI_Unit_Relations").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_EI_Unit_Relations").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Code_).HasMaxLength(100);
            entity.Property(e => e.Name_).HasMaxLength(100);
            entity.Property(e => e.Ref).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_Unit_Relations)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_Unit_Relations_SetOid");

            entity.HasOne(d => d.UnitO).WithMany(p => p.EI_Unit_Relations)
                .HasForeignKey(d => d.UnitOid)
                .HasConstraintName("FK_EI_Unit_Relations_UnitOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_Unit_Relations_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_Unit_Relations__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_Unit_Relations_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_Unit_Relations__LastModifiedBy");
        });

        modelBuilder.Entity<EI_User_ERPBalanceControl_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_EI_USER_ERPBALANCECONTROL_SETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_EI_USER_ERPBALANCECONTROL_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.SetOid, "İSETOİD_EI_USER_ERPBALANCECONTROL_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "İUSEROİD_EI_USER_ERPBALANCECONTROL_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_EI_USER_ERPBALANCECONTROL_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_EI_USER_ERPBALANCECONTROL_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.SetO).WithMany(p => p.EI_User_ERPBalanceControl_Settings)
                .HasForeignKey(d => d.SetOid)
                .HasConstraintName("FK_EI_USER_ERPBALANCECONTROL_SETTİNGS_SETOİD");

            entity.HasOne(d => d.UserO).WithMany(p => p.EI_User_ERPBalanceControl_SettingsUserO)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_EI_USER_ERPBALANCECONTROL_SETTİNGS_USEROİD");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.EI_User_ERPBalanceControl_Settings_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_EI_USER_ERPBALANCECONTROL_SETTİNGS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.EI_User_ERPBalanceControl_Settings_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_EI_USER_ERPBALANCECONTROL_SETTİNGS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<EX_Firm_Applications>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ApiBaseAddress).IsUnicode(false);
            entity.Property(e => e.ApplicationId)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ClientId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ClientName).HasMaxLength(200);
            entity.Property(e => e.ClientUri).HasMaxLength(2000);
            entity.Property(e => e.CreateUser)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.SettingSKey)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.UpdateUser)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactO).WithMany(p => p.EX_Firm_Applications)
                .HasForeignKey(d => d.ContactOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_Applications_MT_Contact");

            entity.HasOne(d => d.FirmO).WithMany(p => p.EX_Firm_Applications)
                .HasForeignKey(d => d.FirmOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_Applications_MT_Firm");
        });

        modelBuilder.Entity<EX_Firm_Applications_payment>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.ApplicationO).WithMany(p => p.EX_Firm_Applications_payment)
                .HasForeignKey(d => d.ApplicationOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_Applications_payment_EX_Firm_Applications");

            entity.HasOne(d => d.FirmO).WithMany(p => p.EX_Firm_Applications_payment)
                .HasForeignKey(d => d.FirmOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_Applications_payment_MT_Firm");
        });

        modelBuilder.Entity<EX_Firm_SecretKey>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ClientId).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Secret).HasMaxLength(4000);

            entity.HasOne(d => d.ApplicationO).WithMany(p => p.EX_Firm_SecretKey)
                .HasForeignKey(d => d.ApplicationOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_SecretKey_EX_Firm_Applications");

            entity.HasOne(d => d.FirmO).WithMany(p => p.EX_Firm_SecretKey)
                .HasForeignKey(d => d.FirmOid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EX_Firm_SecretKey_MT_Firm");
        });

        modelBuilder.Entity<EX_Ticket_Contact>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<EX_Ticket_History>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Date_).HasColumnType("datetime");
            entity.Property(e => e.Oid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TicketId).HasMaxLength(100);
        });

        modelBuilder.Entity<GK_Firm_Category01>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Firm_Category01").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Firm_Category01").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Firm_Category01").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Firm_Category01_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Firm_Category01__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Firm_Category01_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Firm_Category01__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Firm_Category02>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Firm_Category02").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Firm_Category02").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Firm_Category02").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Firm_Category02_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Firm_Category02__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Firm_Category02_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Firm_Category02__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Firm_Category03>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Firm_Category03").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Firm_Category03").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Firm_Category03").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Firm_Category03_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Firm_Category03__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Firm_Category03_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Firm_Category03__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Firm_Category04>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Firm_Category04").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Firm_Category04").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Firm_Category04").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Firm_Category04_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Firm_Category04__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Firm_Category04_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Firm_Category04__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Firm_Category05>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Firm_Category05").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Firm_Category05").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Firm_Category05").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Firm_Category05_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Firm_Category05__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Firm_Category05_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Firm_Category05__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Product_Category01>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Product_Category01").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Product_Category01").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Product_Category01").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Product_Category01_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Product_Category01__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Product_Category01_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Product_Category01__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Product_Category02>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Product_Category02").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Product_Category02").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Product_Category02").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Product_Category02_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Product_Category02__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Product_Category02_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Product_Category02__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Product_Category03>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Product_Category03").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Product_Category03").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Product_Category03").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Product_Category03_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Product_Category03__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Product_Category03_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Product_Category03__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Product_Category04>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Product_Category04").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Product_Category04").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Product_Category04").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Product_Category04_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Product_Category04__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Product_Category04_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Product_Category04__LastModifiedBy");
        });

        modelBuilder.Entity<GK_Product_Category05>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_GK_Product_Category05").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_GK_Product_Category05").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_GK_Product_Category05").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.GK_Product_Category05_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_GK_Product_Category05__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.GK_Product_Category05_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_GK_Product_Category05__LastModifiedBy");
        });

        modelBuilder.Entity<GOREV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GOREV");

            entity.Property(e => e.ALTKATEGORI).HasMaxLength(100);
            entity.Property(e => e.ANAKATEGORI).HasMaxLength(100);
            entity.Property(e => e.ATANAN).HasMaxLength(100);
            entity.Property(e => e.BASLANGIC_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("BASLANGIC TARIHI");
            entity.Property(e => e.DESTEKID).HasMaxLength(100);
            entity.Property(e => e.DESTEK_BASLANGIC_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("DESTEK BASLANGIC TARIHI");
            entity.Property(e => e.DESTEK_DURUM)
                .HasMaxLength(100)
                .HasColumnName("DESTEK DURUM");
            entity.Property(e => e.DESTEK_TAMAMLANMA_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("DESTEK TAMAMLANMA TARIHI");
            entity.Property(e => e.FIRMA).HasMaxLength(200);
            entity.Property(e => e.GOREV_DURUMU)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GOREV DURUMU");
            entity.Property(e => e.TAMAMLANMA_TARIHI)
                .HasColumnType("datetime")
                .HasColumnName("TAMAMLANMA TARIHI");
            entity.Property(e => e.TAMAMLANMA_YUZDESI).HasColumnName("TAMAMLANMA YUZDESI");
            entity.Property(e => e.TANIM).HasMaxLength(100);
            entity.Property(e => e.TUR).HasMaxLength(100);
            entity.Property(e => e.YAPILAN_ISLEM).HasColumnName("YAPILAN ISLEM");
        });

        modelBuilder.Entity<KpiDefinition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_KpiDefinition").HasFillFactor(70);

            entity.HasIndex(e => e.KpiInstance, "iKpiInstance_KpiDefinition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Changed).HasColumnType("datetime");
            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Range).HasMaxLength(100);
            entity.Property(e => e.RangeToCompare).HasMaxLength(100);
            entity.Property(e => e.SuppressedSeries).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);

            entity.HasOne(d => d.KpiInstanceNavigation).WithMany(p => p.KpiDefinitionNavigation)
                .HasForeignKey(d => d.KpiInstance)
                .HasConstraintName("FK_KpiDefinition_KpiInstance");
        });

        modelBuilder.Entity<KpiHistoryItem>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.KpiInstance, "iKpiInstance_KpiHistoryItem").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RangeEnd).HasColumnType("datetime");
            entity.Property(e => e.RangeStart).HasColumnType("datetime");

            entity.HasOne(d => d.KpiInstanceNavigation).WithMany(p => p.KpiHistoryItem)
                .HasForeignKey(d => d.KpiInstance)
                .HasConstraintName("FK_KpiHistoryItem_KpiInstance");
        });

        modelBuilder.Entity<KpiInstance>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_KpiInstance").HasFillFactor(70);

            entity.HasIndex(e => e.KpiDefinition, "iKpiDefinition_KpiInstance").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ForceMeasurementDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.KpiDefinition1).WithMany(p => p.KpiInstance1)
                .HasForeignKey(d => d.KpiDefinition)
                .HasConstraintName("FK_KpiInstance_KpiDefinition");
        });

        modelBuilder.Entity<KpiScorecard>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_KpiScorecard").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<KpiScorecardScorecards_KpiInstanceIndicators>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.Indicators, e.Scorecards }, "iIndicatorsScorecards_KpiScorecardScorecards_KpiInstanceIndicators")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.Indicators, "iIndicators_KpiScorecardScorecards_KpiInstanceIndicators").HasFillFactor(70);

            entity.HasIndex(e => e.Scorecards, "iScorecards_KpiScorecardScorecards_KpiInstanceIndicators").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.IndicatorsNavigation).WithMany(p => p.KpiScorecardScorecards_KpiInstanceIndicators)
                .HasForeignKey(d => d.Indicators)
                .HasConstraintName("FK_KpiScorecardScorecards_KpiInstanceIndicators_Indicators");

            entity.HasOne(d => d.ScorecardsNavigation).WithMany(p => p.KpiScorecardScorecards_KpiInstanceIndicators)
                .HasForeignKey(d => d.Scorecards)
                .HasConstraintName("FK_KpiScorecardScorecards_KpiInstanceIndicators_Scorecards");
        });

        modelBuilder.Entity<MT_Action_Lists>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Action_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.ListType, "iListType_MT_Action_Lists").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Action_Lists").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Action_Lists").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ListName).HasMaxLength(30);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ListTypeNavigation).WithMany(p => p.MT_Action_Lists)
                .HasForeignKey(d => d.ListType)
                .HasConstraintName("FK_MT_Action_Lists_ListType");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Action_Lists_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Action_Lists__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Action_Lists_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Action_Lists__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Activity>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.ActivityCategory, "iActivityCategory_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityContact, "iActivityContact_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityFirm, "iActivityFirm_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityState, "iActivityState_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityType, "iActivityType_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityFirmAddress, "İACTİVİTYFİRMADDRESS_MT_ACTİVİTY").HasFillFactor(70);

            entity.HasIndex(e => e.GoogleEvent, "İGOOGLEEVENT_MT_ACTİVİTY").HasFillFactor(70);

            entity.HasIndex(e => e.Google_MT_EventOid, "İGOOGLE_MT_EVENTOİD_MT_ACTİVİTY").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActivityDate).HasColumnType("datetime");
            entity.Property(e => e.ActivityRepeatDate).HasColumnType("datetime");
            entity.Property(e => e.CheckInDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckOutDateTime).HasColumnType("datetime");
            entity.Property(e => e.Google_Attendees).HasMaxLength(100);
            entity.Property(e => e.Id).HasMaxLength(42);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ActivityCategoryNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityCategory)
                .HasConstraintName("FK_MT_Activity_ActivityCategory");

            entity.HasOne(d => d.ActivityContactNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityContact)
                .HasConstraintName("FK_MT_Activity_ActivityContact");

            entity.HasOne(d => d.ActivityFirmNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityFirm)
                .HasConstraintName("FK_MT_Activity_ActivityFirm");

            entity.HasOne(d => d.ActivityFirmAddressNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityFirmAddress)
                .HasConstraintName("FK_MT_ACTİVİTY_ACTİVİTYFİRMADDRESS");

            entity.HasOne(d => d.ActivityStateNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityState)
                .HasConstraintName("FK_MT_Activity_ActivityState");

            entity.HasOne(d => d.ActivityTypeNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.ActivityType)
                .HasConstraintName("FK_MT_Activity_ActivityType");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Activity_Campaign");

            entity.HasOne(d => d.GoogleEventNavigation).WithMany(p => p.MT_ActivityGoogleEventNavigation)
                .HasForeignKey(d => d.GoogleEvent)
                .HasConstraintName("FK_MT_ACTİVİTY_GOOGLEEVENT");

            entity.HasOne(d => d.Google_MT_EventO).WithMany(p => p.MT_ActivityGoogle_MT_EventO)
                .HasForeignKey(d => d.Google_MT_EventOid)
                .HasConstraintName("FK_MT_ACTİVİTY_GOOGLE_MT_EVENTOİD");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Activity)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Activity_SalesRep");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Activity_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Activity__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Activity_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Activity__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Campaign>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CampaignType, "iCampaignType_MT_Campaign").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Campaign").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Campaign").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Campaign").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CampaignName).HasMaxLength(120);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CampaignTypeNavigation).WithMany(p => p.MT_Campaign)
                .HasForeignKey(d => d.CampaignType)
                .HasConstraintName("FK_MT_Campaign_CampaignType");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Campaign_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Campaign__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Campaign_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Campaign__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Campaign_Lists>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Campaign_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.Contact, "iContact_MT_Campaign_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.Firm, "iFirm_MT_Campaign_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Campaign_Lists").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Campaign_Lists").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Campaign_Lists").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ObjectDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Campaign_Lists)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Campaign_Lists_Campaign");

            entity.HasOne(d => d.ContactNavigation).WithMany(p => p.MT_Campaign_Lists)
                .HasForeignKey(d => d.Contact)
                .HasConstraintName("FK_MT_Campaign_Lists_Contact");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.MT_Campaign_Lists)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_MT_Campaign_Lists_Firm");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Campaign_Lists_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Campaign_Lists__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Campaign_Lists_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Campaign_Lists__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Contact>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.ContactRole, "iContactRole_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.JobTitle, "iJobTitle_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.MainSector, "iMainSector_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.Networks_, "iNetworks__MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirm, "iRelatedFirm_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Contact").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Contact").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CityOfMainAddress).HasMaxLength(30);
            entity.Property(e => e.CountryOfMainAddress).HasMaxLength(30);
            entity.Property(e => e.EmailAddress1).HasMaxLength(321);
            entity.Property(e => e.EmailAddress2).HasMaxLength(321);
            entity.Property(e => e.EmailAddress3).HasMaxLength(321);
            entity.Property(e => e.FirmaYetkilisi).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(302);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MainAddress).HasMaxLength(300);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phones).HasMaxLength(300);
            entity.Property(e => e.WebAddress1).HasMaxLength(2083);
            entity.Property(e => e.WebAddress2).HasMaxLength(2083);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._MXN_Password).HasMaxLength(120);
            entity.Property(e => e._MXN_UserName).HasMaxLength(120);

            entity.HasOne(d => d.ContactRoleNavigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.ContactRole)
                .HasConstraintName("FK_MT_Contact_ContactRole");

            entity.HasOne(d => d.JobTitleNavigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.JobTitle)
                .HasConstraintName("FK_MT_Contact_JobTitle");

            entity.HasOne(d => d.MainSectorNavigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.MainSector)
                .HasConstraintName("FK_MT_Contact_MainSector");

            entity.HasOne(d => d.Networks_Navigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.Networks_)
                .HasConstraintName("FK_MT_Contact_Networks_");

            entity.HasOne(d => d.RelatedFirmNavigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.RelatedFirm)
                .HasConstraintName("FK_MT_Contact_RelatedFirm");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Contact)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Contact_SalesRep");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Contact_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Contact__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Contact_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Contact__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Document>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.FileFolder, "iFileFolder_MT_Document").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Document").HasFillFactor(70);

            entity.HasIndex(e => e.PhysicalFile, "iPhysicalFile_MT_Document").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Document").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Document").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CloudDriveId).HasMaxLength(100);
            entity.Property(e => e.FilePath).HasMaxLength(260);
            entity.Property(e => e.SharedFilePath).HasMaxLength(260);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.FileFolderNavigation).WithMany(p => p.MT_Document)
                .HasForeignKey(d => d.FileFolder)
                .HasConstraintName("FK_MT_Document_FileFolder");

            entity.HasOne(d => d.PhysicalFileNavigation).WithMany(p => p.MT_Document)
                .HasForeignKey(d => d.PhysicalFile)
                .HasConstraintName("FK_MT_Document_PhysicalFile");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Document_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Document__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Document_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Document__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Document_Folder>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Document_Folder").HasFillFactor(70);

            entity.HasIndex(e => e.Parent, "iParent_MT_Document_Folder").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Document_Folder").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Document_Folder").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DriveFolderId).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OneDriveFolderId).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ParentNavigation).WithMany(p => p.InverseParentNavigation)
                .HasForeignKey(d => d.Parent)
                .HasConstraintName("FK_MT_Document_Folder_Parent");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Document_Folder_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Document_Folder__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Document_Folder_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Document_Folder__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Event>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e.EndOn, "iEndOn_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e.RecurrencePattern, "iRecurrencePattern_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e.StartOn, "iStartOn_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Event").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedActivity, "İRELATEDACTİVİTY_MT_EVENT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AlarmTime).HasColumnType("datetime");
            entity.Property(e => e.EndOn).HasColumnType("datetime");
            entity.Property(e => e.GoogleCalendarId).HasMaxLength(300);
            entity.Property(e => e.GoogleId).HasMaxLength(300);
            entity.Property(e => e.Google_Attendees).HasMaxLength(100);
            entity.Property(e => e.ReminderInfoXml).HasMaxLength(100);
            entity.Property(e => e.StartOn).HasColumnType("datetime");
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Event)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Event_Campaign");

            entity.HasOne(d => d.RecurrencePatternNavigation).WithMany(p => p.InverseRecurrencePatternNavigation)
                .HasForeignKey(d => d.RecurrencePattern)
                .HasConstraintName("FK_MT_Event_RecurrencePattern");

            entity.HasOne(d => d.RelatedActivityNavigation).WithMany(p => p.MT_Event)
                .HasForeignKey(d => d.RelatedActivity)
                .HasConstraintName("FK_MT_EVENT_RELATEDACTİVİTY");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Event_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Event__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Event_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Event__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Firm>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.FirmCategory01, "iFirmCategory01_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmCategory02, "iFirmCategory02_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmCategory03, "iFirmCategory03_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmCategory04, "iFirmCategory04_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmCategory05, "iFirmCategory05_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmRole, "iFirmRole_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.MainSector, "iMainSector_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.Networks_, "iNetworks__MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.ParentFirm, "iParentFirm_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.ReferenceSource, "iReferenceSource_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.SubSector, "iSubSector_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmCode, "İFİRMCODE_MT_FİRM").HasFillFactor(70);

            entity.HasIndex(e => e.FirmTitle, "İFİRMTİTLE_MT_FİRM").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ARPAccountType).HasMaxLength(1);
            entity.Property(e => e.ARPAuthCode).HasMaxLength(41);
            entity.Property(e => e.ARPDeliveryType).HasMaxLength(41);
            entity.Property(e => e.ARPPaymentPlan).HasMaxLength(41);
            entity.Property(e => e.ARPShippingAgent).HasMaxLength(41);
            entity.Property(e => e.ARPTradingGroup).HasMaxLength(41);
            entity.Property(e => e.ARPUsesInExports).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInFinance).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInImports).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInPurchase).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInSales).HasMaxLength(1);
            entity.Property(e => e.ApiSKey)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Auxiliary_Code1).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code2).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code3).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code4).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code5).HasMaxLength(41);
            entity.Property(e => e.CityOfMainAddress).HasMaxLength(30);
            entity.Property(e => e.CountryOfMainAddress).HasMaxLength(30);
            entity.Property(e => e.CountyOfMainAddress).HasMaxLength(100);
            entity.Property(e => e.DistrictOfMainAddress).HasMaxLength(100);
            entity.Property(e => e.EmailAddress1).HasMaxLength(321);
            entity.Property(e => e.EmailAddress2).HasMaxLength(321);
            entity.Property(e => e.EmailAddress3).HasMaxLength(321);
            entity.Property(e => e.FirmCode).HasMaxLength(42);
            entity.Property(e => e.FirmLogoBakimBaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmLogoBakimBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmRiskAcc).HasMaxLength(1);
            entity.Property(e => e.FirmRiskCiroCs).HasMaxLength(1);
            entity.Property(e => e.FirmRiskCustomerCs).HasMaxLength(1);
            entity.Property(e => e.FirmRiskDispatch).HasMaxLength(1);
            entity.Property(e => e.FirmRiskDispatchProp).HasMaxLength(1);
            entity.Property(e => e.FirmRiskMyCs).HasMaxLength(1);
            entity.Property(e => e.FirmRiskOrder).HasMaxLength(1);
            entity.Property(e => e.FirmRiskOrderProp).HasMaxLength(1);
            entity.Property(e => e.FirmTeknikBakimBaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmTeknikBakimBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmTitle).HasMaxLength(200);
            entity.Property(e => e.FirmYeniDonanimBakimBaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmYeniDonanimBakimBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmYeniLogoBakimBaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.FirmYeniLogoBakimBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.MainAddress).HasMaxLength(300);
            entity.Property(e => e.ParishOfMainAddress).HasMaxLength(100);
            entity.Property(e => e.PersonId).HasMaxLength(16);
            entity.Property(e => e.Phones).HasMaxLength(300);
            entity.Property(e => e.TaxNo).HasMaxLength(16);
            entity.Property(e => e.TaxOffice).HasMaxLength(25);
            entity.Property(e => e.WebAddress1).HasMaxLength(2083);
            entity.Property(e => e.WebAddress2).HasMaxLength(2083);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._MusteriTipi).HasMaxLength(100);

            entity.HasOne(d => d.FirmCategory01Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmCategory01)
                .HasConstraintName("FK_MT_Firm_FirmCategory01");

            entity.HasOne(d => d.FirmCategory02Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmCategory02)
                .HasConstraintName("FK_MT_Firm_FirmCategory02");

            entity.HasOne(d => d.FirmCategory03Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmCategory03)
                .HasConstraintName("FK_MT_Firm_FirmCategory03");

            entity.HasOne(d => d.FirmCategory04Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmCategory04)
                .HasConstraintName("FK_MT_Firm_FirmCategory04");

            entity.HasOne(d => d.FirmCategory05Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmCategory05)
                .HasConstraintName("FK_MT_Firm_FirmCategory05");

            entity.HasOne(d => d.FirmRoleNavigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.FirmRole)
                .HasConstraintName("FK_MT_Firm_FirmRole");

            entity.HasOne(d => d.MainSectorNavigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.MainSector)
                .HasConstraintName("FK_MT_Firm_MainSector");

            entity.HasOne(d => d.Networks_Navigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.Networks_)
                .HasConstraintName("FK_MT_Firm_Networks_");

            entity.HasOne(d => d.ParentFirmNavigation).WithMany(p => p.InverseParentFirmNavigation)
                .HasForeignKey(d => d.ParentFirm)
                .HasConstraintName("FK_MT_Firm_ParentFirm");

            entity.HasOne(d => d.ReferenceSourceNavigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.ReferenceSource)
                .HasConstraintName("FK_MT_Firm_ReferenceSource");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Firm_SalesRep");

            entity.HasOne(d => d.SubSectorNavigation).WithMany(p => p.MT_Firm)
                .HasForeignKey(d => d.SubSector)
                .HasConstraintName("FK_MT_Firm_SubSector");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Firm_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Firm__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Firm_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Firm__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Mail>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Mail").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Mail").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Mail").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.EntryId).HasMaxLength(300);
            entity.Property(e => e.FileName).HasMaxLength(260);
            entity.Property(e => e.FromName_).HasMaxLength(254);
            entity.Property(e => e.From_).HasMaxLength(254);
            entity.Property(e => e.MailSubject).HasMaxLength(254);
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Mail_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Mail__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Mail_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Mail__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Mail_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Mail_Settings").HasFillFactor(70);

            entity.HasIndex(e => e.User, "iUser_MT_Mail_Settings").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.Domain).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(321);
            entity.Property(e => e.Host).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.MT_Mail_Settings)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_MT_Mail_Settings_User");
        });

        modelBuilder.Entity<MT_Notes>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Notes").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Notes").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Notes").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.NoteDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Notes_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Notes__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Notes_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Notes__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Notifications>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Notifications").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Notifications").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Notifications").HasFillFactor(70);

            entity.HasIndex(e => e.Firm, "İFİRM_MT_NOTİFİCATİONS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.NotificationDescription).HasMaxLength(200);
            entity.Property(e => e.ObjectClassName).HasMaxLength(100);
            entity.Property(e => e.ObjectDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.MT_Notifications)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_MT_NOTİFİCATİONS_FİRM");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Notifications_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Notifications__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Notifications_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Notifications__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Opportunity>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityContact, "iOpportunityContact_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityFirm, "iOpportunityFirm_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunitySource, "iOpportunitySource_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityStage, "iOpportunityStage_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityType, "iOpportunityType_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.WinLoseReason, "İWİNLOSEREASON_MT_OPPORTUNİTY").HasFillFactor(70);

            entity.HasIndex(e => e.WinningCompetitor, "İWİNNİNGCOMPETİTOR_MT_OPPORTUNİTY").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Id).HasMaxLength(42);
            entity.Property(e => e.OpportunityEstEndDate).HasColumnType("datetime");
            entity.Property(e => e.OpportunityGeneralStatusDate).HasColumnType("datetime");
            entity.Property(e => e.OpportunityStartDate).HasColumnType("datetime");
            entity.Property(e => e.OpportunitySubject).HasMaxLength(120);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Opportunity_Campaign");

            entity.HasOne(d => d.OpportunityContactNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.OpportunityContact)
                .HasConstraintName("FK_MT_Opportunity_OpportunityContact");

            entity.HasOne(d => d.OpportunityFirmNavigation).WithMany(p => p.MT_OpportunityOpportunityFirmNavigation)
                .HasForeignKey(d => d.OpportunityFirm)
                .HasConstraintName("FK_MT_Opportunity_OpportunityFirm");

            entity.HasOne(d => d.OpportunitySourceNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.OpportunitySource)
                .HasConstraintName("FK_MT_Opportunity_OpportunitySource");

            entity.HasOne(d => d.OpportunityStageNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.OpportunityStage)
                .HasConstraintName("FK_MT_Opportunity_OpportunityStage");

            entity.HasOne(d => d.OpportunityTypeNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.OpportunityType)
                .HasConstraintName("FK_MT_Opportunity_OpportunityType");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Opportunity_SalesRep");

            entity.HasOne(d => d.WinLoseReasonNavigation).WithMany(p => p.MT_Opportunity)
                .HasForeignKey(d => d.WinLoseReason)
                .HasConstraintName("FK_MT_OPPORTUNİTY_WİNLOSEREASON");

            entity.HasOne(d => d.WinningCompetitorNavigation).WithMany(p => p.MT_OpportunityWinningCompetitorNavigation)
                .HasForeignKey(d => d.WinningCompetitor)
                .HasConstraintName("FK_MT_OPPORTUNİTY_WİNNİNGCOMPETİTOR");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Opportunity_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Opportunity__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Opportunity_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Opportunity__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Class, "iClass_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.GroupCode, "iGroupCode_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCategory01, "iProductCategory01_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCategory02, "iProductCategory02_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCategory03, "iProductCategory03_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCategory04, "iProductCategory04_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCategory05, "iProductCategory05_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductCode, "iProductCode_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductUnitSet, "iProductUnitSet_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Product").HasFillFactor(70);

            entity.HasIndex(e => e.Description, "İDESCRİPTİON_MT_PRODUCT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ARPUsesInMM).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInPurchase).HasMaxLength(1);
            entity.Property(e => e.ARPUsesInSales).HasMaxLength(1);
            entity.Property(e => e.Auxiliary_Code1).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code2).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code3).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code4).HasMaxLength(41);
            entity.Property(e => e.Auxiliary_Code5).HasMaxLength(41);
            entity.Property(e => e.Barcode).HasMaxLength(65);
            entity.Property(e => e.DescInArabic).HasMaxLength(300);
            entity.Property(e => e.DescInChinese).HasMaxLength(300);
            entity.Property(e => e.DescInEnglish).HasMaxLength(300);
            entity.Property(e => e.DescInFrench).HasMaxLength(300);
            entity.Property(e => e.DescInGerman).HasMaxLength(300);
            entity.Property(e => e.DescInItalian).HasMaxLength(300);
            entity.Property(e => e.DescInJapanese).HasMaxLength(300);
            entity.Property(e => e.DescInRussian).HasMaxLength(300);
            entity.Property(e => e.DescInSpanish).HasMaxLength(300);
            entity.Property(e => e.DescInTurkish).HasMaxLength(300);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ERPAuthCode).HasMaxLength(41);
            entity.Property(e => e.ERPDescription2).HasMaxLength(202);
            entity.Property(e => e.ERPGroupCode).HasMaxLength(41);
            entity.Property(e => e.ERPPaymentPlan).HasMaxLength(41);
            entity.Property(e => e.HasVariants).HasMaxLength(1);
            entity.Property(e => e.ProducerCode).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.WarrantyInterval).HasDefaultValueSql("((1))");
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.Class)
                .HasConstraintName("FK_MT_Product_Class");

            entity.HasOne(d => d.GroupCodeNavigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.GroupCode)
                .HasConstraintName("FK_MT_Product_GroupCode");

            entity.HasOne(d => d.ProductCategory01Navigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductCategory01)
                .HasConstraintName("FK_MT_Product_ProductCategory01");

            entity.HasOne(d => d.ProductCategory02Navigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductCategory02)
                .HasConstraintName("FK_MT_Product_ProductCategory02");

            entity.HasOne(d => d.ProductCategory03Navigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductCategory03)
                .HasConstraintName("FK_MT_Product_ProductCategory03");

            entity.HasOne(d => d.ProductCategory04Navigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductCategory04)
                .HasConstraintName("FK_MT_Product_ProductCategory04");

            entity.HasOne(d => d.ProductCategory05Navigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductCategory05)
                .HasConstraintName("FK_MT_Product_ProductCategory05");

            entity.HasOne(d => d.ProductUnitSetNavigation).WithMany(p => p.MT_Product)
                .HasForeignKey(d => d.ProductUnitSet)
                .HasConstraintName("FK_MT_Product_ProductUnitSet");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Product__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Product__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Product_Prices>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CurrencyType, "iCurrencyType_MT_Product_Prices").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Product_Prices").HasFillFactor(70);

            entity.HasIndex(e => e.PriceType, "iPriceType_MT_Product_Prices").HasFillFactor(70);

            entity.HasIndex(e => e.ProductOid, "iProductOid_MT_Product_Prices").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Product_Prices").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Product_Prices").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ERPCode).HasMaxLength(100);
            entity.Property(e => e.PriceEndDate).HasColumnType("datetime");
            entity.Property(e => e.PriceStartDate).HasColumnType("datetime");
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.MT_Product_Prices)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("FK_MT_Product_Prices_CurrencyType");

            entity.HasOne(d => d.PriceTypeNavigation).WithMany(p => p.MT_Product_Prices)
                .HasForeignKey(d => d.PriceType)
                .HasConstraintName("FK_MT_Product_Prices_PriceType");

            entity.HasOne(d => d.ProductO).WithMany(p => p.MT_Product_Prices)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_MT_Product_Prices_ProductOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Product_Prices_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Product_Prices__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Product_Prices_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Product_Prices__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ContractState, "iContractState_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ContractType, "iContractType_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.Incoterm, "iIncoterm_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.IntegrationSet, "iIntegrationSet_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.InvoiceAddress, "iInvoiceAddress_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalGivenBy, "iLastApprovalGivenBy_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalStateBy, "iLastApprovalStateBy_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalWaitingOn, "iLastApprovalWaitingOn_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalContact, "iProposalContact_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalCurrency, "iProposalCurrency_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalFirm, "iProposalFirm_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalGroup, "iProposalGroup_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalStage, "iProposalStage_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalType, "iProposalType_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedOpportunityOid, "iRelatedOpportunityOid_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.ShipmentAddress, "iShipmentAddress_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Proposals").HasFillFactor(70);

            entity.HasIndex(e => e.AdditionalCost, "İADDİTİONALCOST_MT_PROPOSALS");

            entity.HasIndex(e => e.ERPShipmentAccount, "İERPSHİPMENTACCOUNT_MT_PROPOSALS").HasFillFactor(70);

            entity.HasIndex(e => e.WinLoseReason, "İWİNLOSEREASON_MT_PROPOSALS").HasFillFactor(70);

            entity.HasIndex(e => e.WinningCompetitor, "İWİNNİNGCOMPETİTOR_MT_PROPOSALS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActiveRevisalId).HasMaxLength(100);
            entity.Property(e => e.ContractEndDate).HasColumnType("datetime");
            entity.Property(e => e.ContractSignedDate).HasColumnType("datetime");
            entity.Property(e => e.ContractStartDate).HasColumnType("datetime");
            entity.Property(e => e.ERPAffectsRisk).HasMaxLength(1);
            entity.Property(e => e.ERPAuthCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuthCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPCurrencyType_General).HasMaxLength(1);
            entity.Property(e => e.ERPCurrencyType_Lines).HasMaxLength(1);
            entity.Property(e => e.ERPDeliveryType).HasMaxLength(40);
            entity.Property(e => e.ERPDescriptionLines1).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines2).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines3).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines4).HasMaxLength(50);
            entity.Property(e => e.ERPDispatchConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPDispatchType).HasMaxLength(1);
            entity.Property(e => e.ERPDocumentNumber).HasMaxLength(100);
            entity.Property(e => e.ERPDocumentTrackingNumber).HasMaxLength(100);
            entity.Property(e => e.ERPOrderConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPPaymentPlan).HasMaxLength(41);
            entity.Property(e => e.ERPPrePayment).HasMaxLength(1);
            entity.Property(e => e.ERPPricingCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPPricingExchangeRate_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPProjectCode).HasMaxLength(40);
            entity.Property(e => e.ERPReportingCurrencyDate).HasMaxLength(1);
            entity.Property(e => e.ERPRiskControl).HasMaxLength(1);
            entity.Property(e => e.ERPShippingAgent).HasMaxLength(40);
            entity.Property(e => e.ERPTradingGroup).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPWarehouse).HasMaxLength(10);
            entity.Property(e => e.ERP_Department).HasMaxLength(61);
            entity.Property(e => e.ERP_Division).HasMaxLength(10);
            entity.Property(e => e.ERP_Factory).HasMaxLength(51);
            entity.Property(e => e.LastApprovalStateDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalDescription).HasMaxLength(120);
            entity.Property(e => e.ProposalEstEndDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStartDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStateDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentAddressCode).HasMaxLength(100);
            entity.Property(e => e.Total_LC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.Total_PC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.TypeOf_ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AdditionalCostNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.AdditionalCost)
                .HasConstraintName("FK_MT_PROPOSALS_ADDİTİONALCOST");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Proposals_Campaign");

            entity.HasOne(d => d.ContractStateNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ContractState)
                .HasConstraintName("FK_MT_Proposals_ContractState");

            entity.HasOne(d => d.ContractTypeNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ContractType)
                .HasConstraintName("FK_MT_Proposals_ContractType");

            entity.HasOne(d => d.ERPShipmentAccountNavigation).WithMany(p => p.MT_ProposalsERPShipmentAccountNavigation)
                .HasForeignKey(d => d.ERPShipmentAccount)
                .HasConstraintName("FK_MT_PROPOSALS_ERPSHİPMENTACCOUNT");

            entity.HasOne(d => d.IncotermNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.Incoterm)
                .HasConstraintName("FK_MT_Proposals_Incoterm");

            entity.HasOne(d => d.IntegrationSetNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.IntegrationSet)
                .HasConstraintName("FK_MT_Proposals_IntegrationSet");

            entity.HasOne(d => d.InvoiceAddressNavigation).WithMany(p => p.MT_ProposalsInvoiceAddressNavigation)
                .HasForeignKey(d => d.InvoiceAddress)
                .HasConstraintName("FK_MT_Proposals_InvoiceAddress");

            entity.HasOne(d => d.LastApprovalGivenByNavigation).WithMany(p => p.MT_ProposalsLastApprovalGivenByNavigation)
                .HasForeignKey(d => d.LastApprovalGivenBy)
                .HasConstraintName("FK_MT_Proposals_LastApprovalGivenBy");

            entity.HasOne(d => d.LastApprovalStateByNavigation).WithMany(p => p.MT_ProposalsLastApprovalStateByNavigation)
                .HasForeignKey(d => d.LastApprovalStateBy)
                .HasConstraintName("FK_MT_Proposals_LastApprovalStateBy");

            entity.HasOne(d => d.LastApprovalWaitingOnNavigation).WithMany(p => p.MT_ProposalsLastApprovalWaitingOnNavigation)
                .HasForeignKey(d => d.LastApprovalWaitingOn)
                .HasConstraintName("FK_MT_Proposals_LastApprovalWaitingOn");

            entity.HasOne(d => d.ProposalContactNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ProposalContact)
                .HasConstraintName("FK_MT_Proposals_ProposalContact");

            entity.HasOne(d => d.ProposalCurrencyNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ProposalCurrency)
                .HasConstraintName("FK_MT_Proposals_ProposalCurrency");

            entity.HasOne(d => d.ProposalFirmNavigation).WithMany(p => p.MT_ProposalsProposalFirmNavigation)
                .HasForeignKey(d => d.ProposalFirm)
                .HasConstraintName("FK_MT_Proposals_ProposalFirm");

            entity.HasOne(d => d.ProposalGroupNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ProposalGroup)
                .HasConstraintName("FK_MT_Proposals_ProposalGroup");

            entity.HasOne(d => d.ProposalStageNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ProposalStage)
                .HasConstraintName("FK_MT_Proposals_ProposalStage");

            entity.HasOne(d => d.ProposalTypeNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.ProposalType)
                .HasConstraintName("FK_MT_Proposals_ProposalType");

            entity.HasOne(d => d.RelatedOpportunityO).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.RelatedOpportunityOid)
                .HasConstraintName("FK_MT_Proposals_RelatedOpportunityOid");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Proposals_SalesRep");

            entity.HasOne(d => d.ShipmentAddressNavigation).WithMany(p => p.MT_ProposalsShipmentAddressNavigation)
                .HasForeignKey(d => d.ShipmentAddress)
                .HasConstraintName("FK_MT_Proposals_ShipmentAddress");

            entity.HasOne(d => d.TicketO).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_MT_Proposals_TicketOid");

            entity.HasOne(d => d.WinLoseReasonNavigation).WithMany(p => p.MT_Proposals)
                .HasForeignKey(d => d.WinLoseReason)
                .HasConstraintName("FK_MT_PROPOSALS_WİNLOSEREASON");

            entity.HasOne(d => d.WinningCompetitorNavigation).WithMany(p => p.MT_ProposalsWinningCompetitorNavigation)
                .HasForeignKey(d => d.WinningCompetitor)
                .HasConstraintName("FK_MT_PROPOSALS_WİNNİNGCOMPETİTOR");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Proposals__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Proposals__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals_Additional_Cost>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_MT_PROPOSALS_ADDİTİONAL_COST");

            entity.HasIndex(e => e.CurrencyType, "İCURRENCYTYPE_MT_PROPOSALS_ADDİTİONAL_COST");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_MT_PROPOSALS_ADDİTİONAL_COST");

            entity.HasIndex(e => e.Proposal, "İPROPOSAL_MT_PROPOSALS_ADDİTİONAL_COST");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.MT_Proposals_Additional_Cost)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("FK_MT_PROPOSALS_ADDİTİONAL_COST_CURRENCYTYPE");

            entity.HasOne(d => d.ProposalNavigation).WithMany(p => p.MT_Proposals_Additional_Cost)
                .HasForeignKey(d => d.Proposal)
                .HasConstraintName("FK_MT_PROPOSALS_ADDİTİONAL_COST_PROPOSAL");
        });

        modelBuilder.Entity<MT_Proposals_Approvals>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.ByRule, "iByRule_MT_Proposals_Approvals").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals_Approvals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "iProposalOid_MT_Proposals_Approvals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalStage, "iProposalStage_MT_Proposals_Approvals").HasFillFactor(70);

            entity.HasIndex(e => e.SentBy, "iSentBy_MT_Proposals_Approvals").HasFillFactor(70);

            entity.HasIndex(e => e.WaitingFor, "iWaitingFor_MT_Proposals_Approvals").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.RevisalId).HasMaxLength(100);

            entity.HasOne(d => d.ByRuleNavigation).WithMany(p => p.MT_Proposals_Approvals)
                .HasForeignKey(d => d.ByRule)
                .HasConstraintName("FK_MT_Proposals_Approvals_ByRule");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.MT_Proposals_Approvals)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_MT_Proposals_Approvals_ProposalOid");

            entity.HasOne(d => d.ProposalStageNavigation).WithMany(p => p.MT_Proposals_Approvals)
                .HasForeignKey(d => d.ProposalStage)
                .HasConstraintName("FK_MT_Proposals_Approvals_ProposalStage");

            entity.HasOne(d => d.SentByNavigation).WithMany(p => p.MT_Proposals_ApprovalsSentByNavigation)
                .HasForeignKey(d => d.SentBy)
                .HasConstraintName("FK_MT_Proposals_Approvals_SentBy");

            entity.HasOne(d => d.WaitingForNavigation).WithMany(p => p.MT_Proposals_ApprovalsWaitingForNavigation)
                .HasForeignKey(d => d.WaitingFor)
                .HasConstraintName("FK_MT_Proposals_Approvals_WaitingFor");
        });

        modelBuilder.Entity<MT_Proposals_Approvals_Details>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.AdditionalCost, "İADDİTİONALCOST_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.Campaign, "İCAMPAİGN_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ContractState, "İCONTRACTSTATE_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ContractType, "İCONTRACTTYPE_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ERPShipmentAccount, "İERPSHİPMENTACCOUNT_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.Incoterm, "İINCOTERM_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.IntegrationSet, "İINTEGRATİONSET_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.InvoiceAddress, "İINVOİCEADDRESS_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.LastApprovalGivenBy, "İLASTAPPROVALGİVENBY_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.LastApprovalStateBy, "İLASTAPPROVALSTATEBY_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.LastApprovalWaitingOn, "İLASTAPPROVALWAİTİNGON_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalContact, "İPROPOSALCONTACT_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalCurrency, "İPROPOSALCURRENCY_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalFirm, "İPROPOSALFİRM_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalGroup, "İPROPOSALGROUP_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalOid, "İPROPOSALOİD_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalStage, "İPROPOSALSTAGE_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalType, "İPROPOSALTYPE_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.RelatedOpportunityOid, "İRELATEDOPPORTUNİTYOİD_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.SalesRep, "İSALESREP_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ShipmentAddress, "İSHİPMENTADDRESS_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.TicketOid, "İTİCKETOİD_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.WinLoseReason, "İWİNLOSEREASON_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.WinningCompetitor, "İWİNNİNGCOMPETİTOR_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_MT_PROPOSALS_APPROVALS_DETAİLS");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActiveRevisalId).HasMaxLength(100);
            entity.Property(e => e.ContractEndDate).HasColumnType("datetime");
            entity.Property(e => e.ContractSignedDate).HasColumnType("datetime");
            entity.Property(e => e.ContractStartDate).HasColumnType("datetime");
            entity.Property(e => e.ERPAffectsRisk).HasMaxLength(1);
            entity.Property(e => e.ERPAuthCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuthCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPCurrencyType_General).HasMaxLength(1);
            entity.Property(e => e.ERPCurrencyType_Lines).HasMaxLength(1);
            entity.Property(e => e.ERPDeliveryType).HasMaxLength(40);
            entity.Property(e => e.ERPDescriptionLines1).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines2).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines3).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines4).HasMaxLength(50);
            entity.Property(e => e.ERPDispatchConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPDispatchType).HasMaxLength(1);
            entity.Property(e => e.ERPDocumentNumber).HasMaxLength(100);
            entity.Property(e => e.ERPDocumentTrackingNumber).HasMaxLength(100);
            entity.Property(e => e.ERPOrderConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPPaymentPlan).HasMaxLength(41);
            entity.Property(e => e.ERPPrePayment).HasMaxLength(1);
            entity.Property(e => e.ERPPricingCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPPricingExchangeRate_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPProjectCode).HasMaxLength(40);
            entity.Property(e => e.ERPReportingCurrencyDate).HasMaxLength(1);
            entity.Property(e => e.ERPRiskControl).HasMaxLength(1);
            entity.Property(e => e.ERPShippingAgent).HasMaxLength(40);
            entity.Property(e => e.ERPTradingGroup).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPWarehouse).HasMaxLength(10);
            entity.Property(e => e.ERP_Department).HasMaxLength(61);
            entity.Property(e => e.ERP_Division).HasMaxLength(10);
            entity.Property(e => e.ERP_Factory).HasMaxLength(51);
            entity.Property(e => e.LastApprovalStateDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprovalWaitingOnAlternatives).IsUnicode(false);
            entity.Property(e => e.ProposalDescription).HasMaxLength(120);
            entity.Property(e => e.ProposalEstEndDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStartDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStateDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentAddressCode).HasMaxLength(100);
            entity.Property(e => e.Total_LC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.Total_PC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.TypeOf_ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AdditionalCostNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.AdditionalCost)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_ADDİTİONALCOST");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_CAMPAİGN");

            entity.HasOne(d => d.ContractStateNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ContractState)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_CONTRACTSTATE");

            entity.HasOne(d => d.ContractTypeNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ContractType)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_CONTRACTTYPE");

            entity.HasOne(d => d.ERPShipmentAccountNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsERPShipmentAccountNavigation)
                .HasForeignKey(d => d.ERPShipmentAccount)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_ERPSHİPMENTACCOUNT");

            entity.HasOne(d => d.IncotermNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.Incoterm)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_INCOTERM");

            entity.HasOne(d => d.IntegrationSetNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.IntegrationSet)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_INTEGRATİONSET");

            entity.HasOne(d => d.InvoiceAddressNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsInvoiceAddressNavigation)
                .HasForeignKey(d => d.InvoiceAddress)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_INVOİCEADDRESS");

            entity.HasOne(d => d.LastApprovalGivenByNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsLastApprovalGivenByNavigation)
                .HasForeignKey(d => d.LastApprovalGivenBy)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_LASTAPPROVALGİVENBY");

            entity.HasOne(d => d.LastApprovalStateByNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsLastApprovalStateByNavigation)
                .HasForeignKey(d => d.LastApprovalStateBy)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_LASTAPPROVALSTATEBY");

            entity.HasOne(d => d.LastApprovalWaitingOnNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsLastApprovalWaitingOnNavigation)
                .HasForeignKey(d => d.LastApprovalWaitingOn)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_LASTAPPROVALWAİTİNGON");

            entity.HasOne(d => d.ProposalContactNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalContact)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALCONTACT");

            entity.HasOne(d => d.ProposalCurrencyNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalCurrency)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALCURRENCY");

            entity.HasOne(d => d.ProposalFirmNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsProposalFirmNavigation)
                .HasForeignKey(d => d.ProposalFirm)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALFİRM");

            entity.HasOne(d => d.ProposalGroupNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalGroup)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALGROUP");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALOİD");

            entity.HasOne(d => d.ProposalStageNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalStage)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALSTAGE");

            entity.HasOne(d => d.ProposalTypeNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.ProposalType)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_PROPOSALTYPE");

            entity.HasOne(d => d.RelatedOpportunityO).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.RelatedOpportunityOid)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_RELATEDOPPORTUNİTYOİD");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_SALESREP");

            entity.HasOne(d => d.ShipmentAddressNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsShipmentAddressNavigation)
                .HasForeignKey(d => d.ShipmentAddress)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_SHİPMENTADDRESS");

            entity.HasOne(d => d.TicketO).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_TİCKETOİD");

            entity.HasOne(d => d.WinLoseReasonNavigation).WithMany(p => p.MT_Proposals_Approvals_Details)
                .HasForeignKey(d => d.WinLoseReason)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_WİNLOSEREASON");

            entity.HasOne(d => d.WinningCompetitorNavigation).WithMany(p => p.MT_Proposals_Approvals_DetailsWinningCompetitorNavigation)
                .HasForeignKey(d => d.WinningCompetitor)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS_WİNNİNGCOMPETİTOR");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_Approvals_Details_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_Approvals_Details_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_PROPOSALS_APPROVALS_DETAİLS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<MT_Proposals_History>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals_History").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityStage, "iOpportunityStage_MT_Proposals_History").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "iProposalOid_MT_Proposals_History").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalStage, "iProposalStage_MT_Proposals_History").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Proposals_History").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Proposals_History").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RevisalId).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.OpportunityStageNavigation).WithMany(p => p.MT_Proposals_History)
                .HasForeignKey(d => d.OpportunityStage)
                .HasConstraintName("FK_MT_Proposals_History_OpportunityStage");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.MT_Proposals_History)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_MT_Proposals_History_ProposalOid");

            entity.HasOne(d => d.ProposalStageNavigation).WithMany(p => p.MT_Proposals_History)
                .HasForeignKey(d => d.ProposalStage)
                .HasConstraintName("FK_MT_Proposals_History_ProposalStage");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_History_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Proposals_History__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_History_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Proposals_History__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals_Prepared_Forms>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e.PreparedForm, "iPreparedForm_MT_Proposals_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposal, "iRelatedProposal_MT_Proposals_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Proposals_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Proposals_Prepared_Forms").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActiveRevisalId).HasMaxLength(100);
            entity.Property(e => e.FormName).HasMaxLength(100);
            entity.Property(e => e.ProposalReportName).HasMaxLength(100);
            entity.Property(e => e.RevisalId).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PreparedFormNavigation).WithMany(p => p.MT_Proposals_Prepared_Forms)
                .HasForeignKey(d => d.PreparedForm)
                .HasConstraintName("FK_MT_Proposals_Prepared_Forms_PreparedForm");

            entity.HasOne(d => d.RelatedProposalNavigation).WithMany(p => p.MT_Proposals_Prepared_Forms)
                .HasForeignKey(d => d.RelatedProposal)
                .HasConstraintName("FK_MT_Proposals_Prepared_Forms_RelatedProposal");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_Prepared_Forms_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Proposals_Prepared_Forms__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_Prepared_Forms_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Proposals_Prepared_Forms__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals_Products>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Currency, "iCurrency_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.ProductOid, "iProductOid_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalCurrency, "iProposalCurrency_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposal, "iRelatedProposal_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedRevisal, "iRelatedRevisal_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.Unit, "iUnit_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Proposals_Products").HasFillFactor(70);

            entity.HasIndex(e => e.Category, "İCATEGORY_MT_PROPOSALS_PRODUCTS").HasFillFactor(70);

            entity.HasIndex(e => e.ImagePath, "İIMAGEPATH_MT_PROPOSALS_PRODUCTS").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "İOBJECTTYPE_MT_PROPOSALS_PRODUCTS").HasFillFactor(70);

            entity.HasIndex(e => e.PriceType, "İPRİCETYPE_MT_PROPOSALS_PRODUCTS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ERPAuxCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Dispatch2).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPCAMPDetailLevel).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode1).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode2).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode3).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode4).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode5).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode6).HasMaxLength(100);
            entity.Property(e => e.ERPCampLnNo).HasMaxLength(100);
            entity.Property(e => e.ERPLineDescription).HasMaxLength(500);
            entity.Property(e => e.ERPOrderDueDate).HasColumnType("datetime");
            entity.Property(e => e.ERPPCampCode).HasMaxLength(100);
            entity.Property(e => e.ERPProjectCode).HasMaxLength(40);
            entity.Property(e => e.ERPReserveDate).HasColumnType("datetime");
            entity.Property(e => e.ERPReserved).HasMaxLength(1);
            entity.Property(e => e.ERPSalesman).HasMaxLength(41);
            entity.Property(e => e.ERPWarehouse).HasMaxLength(10);
            entity.Property(e => e.ImageFolderPath).HasMaxLength(100);
            entity.Property(e => e.ImagePathName).HasMaxLength(100);
            entity.Property(e => e.VariantCanConfig).HasMaxLength(100);
            entity.Property(e => e.VariantCode).HasMaxLength(100);
            entity.Property(e => e.VariantDescription).HasMaxLength(100);
            entity.Property(e => e.VariantName).HasMaxLength(100);
            entity.Property(e => e.VariantRef).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._DummyAciklama).HasMaxLength(180);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._OzelBirim).HasMaxLength(150);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_CATEGORY");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.MT_Proposals_ProductsCurrencyNavigation)
                .HasForeignKey(d => d.Currency)
                .HasConstraintName("FK_MT_Proposals_Products_Currency");

            entity.HasOne(d => d.ImagePathNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.ImagePath)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_IMAGEPATH");

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_OBJECTTYPE");

            entity.HasOne(d => d.PriceTypeNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.PriceType)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_PRİCETYPE");

            entity.HasOne(d => d.ProductO).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_MT_Proposals_Products_ProductOid");

            entity.HasOne(d => d.ProposalCurrencyNavigation).WithMany(p => p.MT_Proposals_ProductsProposalCurrencyNavigation)
                .HasForeignKey(d => d.ProposalCurrency)
                .HasConstraintName("FK_MT_Proposals_Products_ProposalCurrency");

            entity.HasOne(d => d.RelatedProposalNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.RelatedProposal)
                .HasConstraintName("FK_MT_Proposals_Products_RelatedProposal");

            entity.HasOne(d => d.RelatedRevisalNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.RelatedRevisal)
                .HasConstraintName("FK_MT_Proposals_Products_RelatedRevisal");

            entity.HasOne(d => d.UnitNavigation).WithMany(p => p.MT_Proposals_Products)
                .HasForeignKey(d => d.Unit)
                .HasConstraintName("FK_MT_Proposals_Products_Unit");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_Products_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Proposals_Products__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_Products_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Proposals_Products__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals_Products_Approvals_Details>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.Category, "İCATEGORY_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.Currency, "İCURRENCY_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ImagePath, "İIMAGEPATH_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProductOid, "İPRODUCTOİD_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalCurrency, "İPROPOSALCURRENCY_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.ProposalProductOid, "İPROPOSALPRODUCTOİD_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.PriceType, "İPRİCETYPE_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.RelatedProposal, "İRELATEDPROPOSAL_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.RelatedRevisal, "İRELATEDREVİSAL_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e.Unit, "İUNİT_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ERPAuxCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Dispatch2).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPCAMPDetailLevel).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode1).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode2).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode3).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode4).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode5).HasMaxLength(100);
            entity.Property(e => e.ERPCampCode6).HasMaxLength(100);
            entity.Property(e => e.ERPCampLnNo).HasMaxLength(100);
            entity.Property(e => e.ERPLineDescription).HasMaxLength(500);
            entity.Property(e => e.ERPOrderDueDate).HasColumnType("datetime");
            entity.Property(e => e.ERPPCampCode).HasMaxLength(100);
            entity.Property(e => e.ERPProjectCode).HasMaxLength(40);
            entity.Property(e => e.ERPReserveDate).HasColumnType("datetime");
            entity.Property(e => e.ERPReserved).HasMaxLength(1);
            entity.Property(e => e.ERPSalesman).HasMaxLength(41);
            entity.Property(e => e.ERPWarehouse).HasMaxLength(10);
            entity.Property(e => e.ImagePathName).HasMaxLength(100);
            entity.Property(e => e.VariantCanConfig).HasMaxLength(100);
            entity.Property(e => e.VariantCode).HasMaxLength(100);
            entity.Property(e => e.VariantDescription).HasMaxLength(100);
            entity.Property(e => e.VariantName).HasMaxLength(100);
            entity.Property(e => e.VariantRef).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._DummyAciklama).HasMaxLength(180);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._OzelBirim).HasMaxLength(150);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_CATEGORY");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_DetailsCurrencyNavigation)
                .HasForeignKey(d => d.Currency)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_CURRENCY");

            entity.HasOne(d => d.ImagePathNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.ImagePath)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_IMAGEPATH");

            entity.HasOne(d => d.PriceTypeNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.PriceType)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_PRİCETYPE");

            entity.HasOne(d => d.ProductO).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_PRODUCTOİD");

            entity.HasOne(d => d.ProposalCurrencyNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_DetailsProposalCurrencyNavigation)
                .HasForeignKey(d => d.ProposalCurrency)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_PROPOSALCURRENCY");

            entity.HasOne(d => d.ProposalProductO).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.ProposalProductOid)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_PROPOSALPRODUCTOİD");

            entity.HasOne(d => d.RelatedProposalNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.RelatedProposal)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_RELATEDPROPOSAL");

            entity.HasOne(d => d.RelatedRevisalNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.RelatedRevisal)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_RELATEDREVİSAL");

            entity.HasOne(d => d.UnitNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details)
                .HasForeignKey(d => d.Unit)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS_UNİT");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_Products_Approvals_Details_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_PROPOSALS_PRODUCTS_APPROVALS_DETAİLS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<MT_Proposals_Revisals>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Campaign, "iCampaign_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ContractState, "iContractState_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ContractType, "iContractType_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.Incoterm, "iIncoterm_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.IntegrationSet, "iIntegrationSet_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.InvoiceAddress, "iInvoiceAddress_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalGivenBy, "iLastApprovalGivenBy_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalStateBy, "iLastApprovalStateBy_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.LastApprovalWaitingOn, "iLastApprovalWaitingOn_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalContact, "iProposalContact_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalCurrency, "iProposalCurrency_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalFirm, "iProposalFirm_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalGroup, "iProposalGroup_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "iProposalOid_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalStage, "iProposalStage_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalType, "iProposalType_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedOpportunityOid, "iRelatedOpportunityOid_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRep, "iSalesRep_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.ShipmentAddress, "iShipmentAddress_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Proposals_Revisals").HasFillFactor(70);

            entity.HasIndex(e => e.AdditionalCost, "İADDİTİONALCOST_MT_PROPOSALS_REVİSALS");

            entity.HasIndex(e => e.ERPShipmentAccount, "İERPSHİPMENTACCOUNT_MT_PROPOSALS_REVİSALS").HasFillFactor(70);

            entity.HasIndex(e => e.WinLoseReason, "İWİNLOSEREASON_MT_PROPOSALS_REVİSALS").HasFillFactor(70);

            entity.HasIndex(e => e.WinningCompetitor, "İWİNNİNGCOMPETİTOR_MT_PROPOSALS_REVİSALS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContractEndDate).HasColumnType("datetime");
            entity.Property(e => e.ContractSignedDate).HasColumnType("datetime");
            entity.Property(e => e.ContractStartDate).HasColumnType("datetime");
            entity.Property(e => e.ERPAffectsRisk).HasMaxLength(1);
            entity.Property(e => e.ERPAuthCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuthCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Dispatch).HasMaxLength(41);
            entity.Property(e => e.ERPAuxCode_Order).HasMaxLength(41);
            entity.Property(e => e.ERPCurrencyType_General).HasMaxLength(1);
            entity.Property(e => e.ERPCurrencyType_Lines).HasMaxLength(1);
            entity.Property(e => e.ERPDeliveryType).HasMaxLength(40);
            entity.Property(e => e.ERPDescriptionLines1).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines2).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines3).HasMaxLength(50);
            entity.Property(e => e.ERPDescriptionLines4).HasMaxLength(50);
            entity.Property(e => e.ERPDispatchConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPDispatchType).HasMaxLength(1);
            entity.Property(e => e.ERPDocumentNumber).HasMaxLength(100);
            entity.Property(e => e.ERPDocumentTrackingNumber).HasMaxLength(100);
            entity.Property(e => e.ERPOrderConfirmationStatus).HasMaxLength(1);
            entity.Property(e => e.ERPPaymentPlan).HasMaxLength(41);
            entity.Property(e => e.ERPPrePayment).HasMaxLength(1);
            entity.Property(e => e.ERPPricingCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPPricingExchangeRate_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPProjectCode).HasMaxLength(40);
            entity.Property(e => e.ERPReportingCurrencyDate).HasMaxLength(1);
            entity.Property(e => e.ERPRiskControl).HasMaxLength(1);
            entity.Property(e => e.ERPShippingAgent).HasMaxLength(40);
            entity.Property(e => e.ERPTradingGroup).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e.ERPTransactionCurrency_Transferred).HasMaxLength(1);
            entity.Property(e => e.ERPWarehouse).HasMaxLength(10);
            entity.Property(e => e.ERP_Department).HasMaxLength(61);
            entity.Property(e => e.ERP_Division).HasMaxLength(10);
            entity.Property(e => e.ERP_Factory).HasMaxLength(51);
            entity.Property(e => e.LastApprovalStateDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalDescription).HasMaxLength(120);
            entity.Property(e => e.ProposalEstEndDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStartDate).HasColumnType("datetime");
            entity.Property(e => e.ProposalStateDate).HasColumnType("datetime");
            entity.Property(e => e.RevisalId).HasMaxLength(100);
            entity.Property(e => e.ShipmentAddressCode).HasMaxLength(100);
            entity.Property(e => e.Total_LC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.Total_PC_GrandTotal_String).HasMaxLength(100);
            entity.Property(e => e.TypeOf_ERPTransactionCurrency_Transfer).HasMaxLength(41);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AdditionalCostNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.AdditionalCost)
                .HasConstraintName("FK_MT_PROPOSALS_REVİSALS_ADDİTİONALCOST");

            entity.HasOne(d => d.CampaignNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.Campaign)
                .HasConstraintName("FK_MT_Proposals_Revisals_Campaign");

            entity.HasOne(d => d.ContractStateNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ContractState)
                .HasConstraintName("FK_MT_Proposals_Revisals_ContractState");

            entity.HasOne(d => d.ContractTypeNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ContractType)
                .HasConstraintName("FK_MT_Proposals_Revisals_ContractType");

            entity.HasOne(d => d.ERPShipmentAccountNavigation).WithMany(p => p.MT_Proposals_RevisalsERPShipmentAccountNavigation)
                .HasForeignKey(d => d.ERPShipmentAccount)
                .HasConstraintName("FK_MT_PROPOSALS_REVİSALS_ERPSHİPMENTACCOUNT");

            entity.HasOne(d => d.IncotermNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.Incoterm)
                .HasConstraintName("FK_MT_Proposals_Revisals_Incoterm");

            entity.HasOne(d => d.IntegrationSetNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.IntegrationSet)
                .HasConstraintName("FK_MT_Proposals_Revisals_IntegrationSet");

            entity.HasOne(d => d.InvoiceAddressNavigation).WithMany(p => p.MT_Proposals_RevisalsInvoiceAddressNavigation)
                .HasForeignKey(d => d.InvoiceAddress)
                .HasConstraintName("FK_MT_Proposals_Revisals_InvoiceAddress");

            entity.HasOne(d => d.LastApprovalGivenByNavigation).WithMany(p => p.MT_Proposals_RevisalsLastApprovalGivenByNavigation)
                .HasForeignKey(d => d.LastApprovalGivenBy)
                .HasConstraintName("FK_MT_Proposals_Revisals_LastApprovalGivenBy");

            entity.HasOne(d => d.LastApprovalStateByNavigation).WithMany(p => p.MT_Proposals_RevisalsLastApprovalStateByNavigation)
                .HasForeignKey(d => d.LastApprovalStateBy)
                .HasConstraintName("FK_MT_Proposals_Revisals_LastApprovalStateBy");

            entity.HasOne(d => d.LastApprovalWaitingOnNavigation).WithMany(p => p.MT_Proposals_RevisalsLastApprovalWaitingOnNavigation)
                .HasForeignKey(d => d.LastApprovalWaitingOn)
                .HasConstraintName("FK_MT_Proposals_Revisals_LastApprovalWaitingOn");

            entity.HasOne(d => d.ProposalContactNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalContact)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalContact");

            entity.HasOne(d => d.ProposalCurrencyNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalCurrency)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalCurrency");

            entity.HasOne(d => d.ProposalFirmNavigation).WithMany(p => p.MT_Proposals_RevisalsProposalFirmNavigation)
                .HasForeignKey(d => d.ProposalFirm)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalFirm");

            entity.HasOne(d => d.ProposalGroupNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalGroup)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalGroup");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalOid");

            entity.HasOne(d => d.ProposalStageNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalStage)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalStage");

            entity.HasOne(d => d.ProposalTypeNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.ProposalType)
                .HasConstraintName("FK_MT_Proposals_Revisals_ProposalType");

            entity.HasOne(d => d.RelatedOpportunityO).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.RelatedOpportunityOid)
                .HasConstraintName("FK_MT_Proposals_Revisals_RelatedOpportunityOid");

            entity.HasOne(d => d.SalesRepNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.SalesRep)
                .HasConstraintName("FK_MT_Proposals_Revisals_SalesRep");

            entity.HasOne(d => d.ShipmentAddressNavigation).WithMany(p => p.MT_Proposals_RevisalsShipmentAddressNavigation)
                .HasForeignKey(d => d.ShipmentAddress)
                .HasConstraintName("FK_MT_Proposals_Revisals_ShipmentAddress");

            entity.HasOne(d => d.TicketO).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_MT_Proposals_Revisals_TicketOid");

            entity.HasOne(d => d.WinLoseReasonNavigation).WithMany(p => p.MT_Proposals_Revisals)
                .HasForeignKey(d => d.WinLoseReason)
                .HasConstraintName("FK_MT_PROPOSALS_REVİSALS_WİNLOSEREASON");

            entity.HasOne(d => d.WinningCompetitorNavigation).WithMany(p => p.MT_Proposals_RevisalsWinningCompetitorNavigation)
                .HasForeignKey(d => d.WinningCompetitor)
                .HasConstraintName("FK_MT_PROPOSALS_REVİSALS_WİNNİNGCOMPETİTOR");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Proposals_Revisals_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Proposals_Revisals__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Proposals_Revisals_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Proposals_Revisals__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Proposals_Unit_Conversions>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_MT_PROPOSALS_UNİT_CONVERSİONS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_MT_PROPOSALS_UNİT_CONVERSİONS").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposalProduct, "İRELATEDPROPOSALPRODUCT_MT_PROPOSALS_UNİT_CONVERSİONS").HasFillFactor(70);

            entity.HasIndex(e => e.Unit, "İUNİT_MT_PROPOSALS_UNİT_CONVERSİONS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedProposalProductNavigation).WithMany(p => p.MT_Proposals_Unit_Conversions)
                .HasForeignKey(d => d.RelatedProposalProduct)
                .HasConstraintName("FK_MT_PROPOSALS_UNİT_CONVERSİONS_RELATEDPROPOSALPRODUCT");

            entity.HasOne(d => d.UnitNavigation).WithMany(p => p.MT_Proposals_Unit_Conversions)
                .HasForeignKey(d => d.Unit)
                .HasConstraintName("FK_MT_PROPOSALS_UNİT_CONVERSİONS_UNİT");
        });

        modelBuilder.Entity<MT_Shares>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Shares").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Shares").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Shares").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.NavigateUrl).HasMaxLength(100);
            entity.Property(e => e.ObjectClassName).HasMaxLength(100);
            entity.Property(e => e.ObjectDescription).HasMaxLength(100);
            entity.Property(e => e.ShareDescription).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Shares_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Shares__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Shares_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Shares__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Task>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AssignedDepartment, "iAssignedDepartment_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e.AssignedTo, "iAssignedTo_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e.Owner, "iOwner_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskContact, "iTaskContact_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskFirm, "iTaskFirm_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Task").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Task").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DateCompleted).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedDepartmentNavigation).WithMany(p => p.MT_Task)
                .HasForeignKey(d => d.AssignedDepartment)
                .HasConstraintName("FK_MT_Task_AssignedDepartment");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.MT_TaskAssignedToNavigation)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK_MT_Task_AssignedTo");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.MT_TaskOwnerNavigation)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_MT_Task_Owner");

            entity.HasOne(d => d.TaskContactNavigation).WithMany(p => p.MT_Task)
                .HasForeignKey(d => d.TaskContact)
                .HasConstraintName("FK_MT_Task_TaskContact");

            entity.HasOne(d => d.TaskFirmNavigation).WithMany(p => p.MT_Task)
                .HasForeignKey(d => d.TaskFirm)
                .HasConstraintName("FK_MT_Task_TaskFirm");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Task_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Task__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Task_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Task__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Ticket>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AssignedDepartment, "iAssignedDepartment_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.AssignedTo, "iAssignedTo_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketContact, "iTicketContact_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketFirm, "iTicketFirm_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketMainCategory, "iTicketMainCategory_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketState, "iTicketState_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketSubCategory, "iTicketSubCategory_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketType, "iTicketType_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.FirmaUrun, "İFİRMAURUN_MT_TİCKET");

            entity.HasIndex(e => e.TicketContact2, "İTİCKETCONTACT2_MT_TİCKET").HasFillFactor(70);

            entity.HasIndex(e => e.TicketProposalProduct, "İTİCKETPROPOSALPRODUCT_MT_TİCKET").HasFillFactor(70);

            entity.HasIndex(e => e.TicketProposal, "İTİCKETPROPOSAL_MT_TİCKET").HasFillFactor(70);

            entity.HasIndex(e => e.Yetkili1, "İYETKİLİ1_MT_TİCKET").HasFillFactor(70);

            entity.HasIndex(e => e.Yetkili2, "İYETKİLİ2_MT_TİCKET");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CaseId).HasMaxLength(100);
            entity.Property(e => e.CurrencyType).HasMaxLength(50);
            entity.Property(e => e.FirmaUrunSeriNo).HasMaxLength(120);
            entity.Property(e => e.JiraOrSupportCode)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.ReleatedJob).HasMaxLength(120);
            entity.Property(e => e.SpeCode)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.TicketAramaTarihi).HasColumnType("datetime");
            entity.Property(e => e.TicketCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.TicketDescription).HasMaxLength(150);
            entity.Property(e => e.TicketEstEndDate).HasColumnType("datetime");
            entity.Property(e => e.TicketId).HasMaxLength(100);
            entity.Property(e => e.TicketStartDate).HasColumnType("datetime");
            entity.Property(e => e.TicketTamamlanmaTarihi).HasColumnType("datetime");
            entity.Property(e => e.TwitterId).HasMaxLength(100);
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedDepartmentNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.AssignedDepartment)
                .HasConstraintName("FK_MT_Ticket_AssignedDepartment");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.MT_TicketAssignedToNavigation)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK_MT_Ticket_AssignedTo");

            entity.HasOne(d => d.FirmaUrunNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.FirmaUrun)
                .HasConstraintName("FK_MT_TİCKET_FİRMAURUN");

            entity.HasOne(d => d.TicketContactNavigation).WithMany(p => p.MT_TicketTicketContactNavigation)
                .HasForeignKey(d => d.TicketContact)
                .HasConstraintName("FK_MT_Ticket_TicketContact");

            entity.HasOne(d => d.TicketContact2Navigation).WithMany(p => p.MT_TicketTicketContact2Navigation)
                .HasForeignKey(d => d.TicketContact2)
                .HasConstraintName("FK_MT_TİCKET_TİCKETCONTACT2");

            entity.HasOne(d => d.TicketFirmNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketFirm)
                .HasConstraintName("FK_MT_Ticket_TicketFirm");

            entity.HasOne(d => d.TicketMainCategoryNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketMainCategory)
                .HasConstraintName("FK_MT_Ticket_TicketMainCategory");

            entity.HasOne(d => d.TicketProposalNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketProposal)
                .HasConstraintName("FK_MT_TİCKET_TİCKETPROPOSAL");

            entity.HasOne(d => d.TicketProposalProductNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketProposalProduct)
                .HasConstraintName("FK_MT_TİCKET_TİCKETPROPOSALPRODUCT");

            entity.HasOne(d => d.TicketStateNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketState)
                .HasConstraintName("FK_MT_Ticket_TicketState");

            entity.HasOne(d => d.TicketSubCategoryNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketSubCategory)
                .HasConstraintName("FK_MT_Ticket_TicketSubCategory");

            entity.HasOne(d => d.TicketTypeNavigation).WithMany(p => p.MT_Ticket)
                .HasForeignKey(d => d.TicketType)
                .HasConstraintName("FK_MT_Ticket_TicketType");

            entity.HasOne(d => d.Yetkili1Navigation).WithMany(p => p.MT_TicketYetkili1Navigation)
                .HasForeignKey(d => d.Yetkili1)
                .HasConstraintName("FK_MT_TİCKET_YETKİLİ1");

            entity.HasOne(d => d.Yetkili2Navigation).WithMany(p => p.MT_TicketYetkili2Navigation)
                .HasForeignKey(d => d.Yetkili2)
                .HasConstraintName("FK_MT_TİCKET_YETKİLİ2");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Ticket_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Ticket__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Ticket_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Ticket__LastModifiedBy");
        });

        modelBuilder.Entity<MT_Ticket_Prepared_Forms>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MT_Ticket_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e.PreparedForm, "iPreparedForm_MT_Ticket_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedTicket, "iRelatedTicket_MT_Ticket_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_MT_Ticket_Prepared_Forms").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_MT_Ticket_Prepared_Forms").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FormName).HasMaxLength(100);
            entity.Property(e => e.TicketReportName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PreparedFormNavigation).WithMany(p => p.MT_Ticket_Prepared_Forms)
                .HasForeignKey(d => d.PreparedForm)
                .HasConstraintName("FK_MT_Ticket_Prepared_Forms_PreparedForm");

            entity.HasOne(d => d.RelatedTicketNavigation).WithMany(p => p.MT_Ticket_Prepared_Forms)
                .HasForeignKey(d => d.RelatedTicket)
                .HasConstraintName("FK_MT_Ticket_Prepared_Forms_RelatedTicket");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.MT_Ticket_Prepared_Forms_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_MT_Ticket_Prepared_Forms__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.MT_Ticket_Prepared_Forms_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_MT_Ticket_Prepared_Forms__LastModifiedBy");
        });

        modelBuilder.Entity<MailChimpLists>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_MAİLCHİMPLİSTS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_MAİLCHİMPLİSTS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
        });

        modelBuilder.Entity<PO_Address>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AddressType, "iAddressType_PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.City_, "iCity__PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.Country, "iCountry_PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.County_, "iCounty__PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.District_, "iDistrict__PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.Parish_, "iParish__PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedContact, "iRelatedContact_PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirm, "iRelatedFirm_PO_Address").HasFillFactor(70);

            entity.HasIndex(e => e.AutoAddedFromFirm, "İAUTOADDEDFROMFİRM_PO_ADDRESS").HasFillFactor(70);

            entity.HasIndex(e => e.StateProvince, "İSTATEPROVİNCE_PO_ADDRESS").HasFillFactor(70);

            entity.HasIndex(e => e.Street2, "İSTREET2_PO_ADDRESS").HasFillFactor(70);

            entity.HasIndex(e => e.Street, "İSTREET_PO_ADDRESS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ShipAdr_AuthCode).HasMaxLength(11);
            entity.Property(e => e.ShipAdr_Auxiliary_Code1).HasMaxLength(11);
            entity.Property(e => e.ShipAdr_InUse).HasMaxLength(1);
            entity.Property(e => e.ShipAdr_TradingGroup).HasMaxLength(17);
            entity.Property(e => e.Shipment_Code).HasMaxLength(25);
            entity.Property(e => e.Shipment_Description).HasMaxLength(51);
            entity.Property(e => e.Shipment_Fax).HasMaxLength(16);
            entity.Property(e => e.Shipment_Phone1).HasMaxLength(16);
            entity.Property(e => e.Shipment_Phone2).HasMaxLength(16);
            entity.Property(e => e.Shipment_RelatedEMail).HasMaxLength(51);
            entity.Property(e => e.Shipment_RelatedPerson).HasMaxLength(21);
            entity.Property(e => e.Shipment_TaxNo).HasMaxLength(16);
            entity.Property(e => e.Shipment_TaxOffice).HasMaxLength(30);
            entity.Property(e => e.Shipment_VatNo).HasMaxLength(20);
            entity.Property(e => e.StateProvince).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(201);
            entity.Property(e => e.Street2).HasMaxLength(201);
            entity.Property(e => e.ZipPostal).HasMaxLength(11);

            entity.HasOne(d => d.AddressTypeNavigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.AddressType)
                .HasConstraintName("FK_PO_Address_AddressType");

            entity.HasOne(d => d.City_Navigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.City_)
                .HasConstraintName("FK_PO_Address_City_");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("FK_PO_Address_Country");

            entity.HasOne(d => d.County_Navigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.County_)
                .HasConstraintName("FK_PO_Address_County_");

            entity.HasOne(d => d.District_Navigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.District_)
                .HasConstraintName("FK_PO_Address_District_");

            entity.HasOne(d => d.Parish_Navigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.Parish_)
                .HasConstraintName("FK_PO_Address_Parish_");

            entity.HasOne(d => d.RelatedContactNavigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.RelatedContact)
                .HasConstraintName("FK_PO_Address_RelatedContact");

            entity.HasOne(d => d.RelatedFirmNavigation).WithMany(p => p.PO_Address)
                .HasForeignKey(d => d.RelatedFirm)
                .HasConstraintName("FK_PO_Address_RelatedFirm");
        });

        modelBuilder.Entity<PO_Address_Type>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Address_Type").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_PO_Address_Type").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_PO_Address_Type").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AddressTypeName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.PO_Address_Type_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_PO_Address_Type__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.PO_Address_Type_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_PO_Address_Type__LastModifiedBy");
        });

        modelBuilder.Entity<PO_City>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CountryOid, "iCountryOid_PO_City").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_City").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AreaCode).HasMaxLength(100);
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.LicensePlateCode).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CountryO).WithMany(p => p.PO_City)
                .HasForeignKey(d => d.CountryOid)
                .HasConstraintName("FK_PO_City_CountryOid");
        });

        modelBuilder.Entity<PO_Country>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Country").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_PO_Country").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_PO_Country").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.BinaryCode).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneCode).HasMaxLength(100);
            entity.Property(e => e.TripleCode).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.PO_Country_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_PO_Country__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.PO_Country_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_PO_Country__LastModifiedBy");
        });

        modelBuilder.Entity<PO_County>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CityOid, "iCityOid_PO_County").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_County").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CountyName).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CityO).WithMany(p => p.PO_County)
                .HasForeignKey(d => d.CityOid)
                .HasConstraintName("FK_PO_County_CityOid");
        });

        modelBuilder.Entity<PO_District>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CountyOid, "iCountyOid_PO_District").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_District").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DistrictName).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CountyO).WithMany(p => p.PO_District)
                .HasForeignKey(d => d.CountyOid)
                .HasConstraintName("FK_PO_District_CountyOid");
        });

        modelBuilder.Entity<PO_File>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_File").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(260);
            entity.Property(e => e.FullName).HasMaxLength(260);
        });

        modelBuilder.Entity<PO_FilePath>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_PO_FİLEPATH");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_PO_FİLEPATH").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(260);
            entity.Property(e => e.FullName).HasMaxLength(260);
        });

        modelBuilder.Entity<PO_Parish>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.DistrictOid, "iDistrictOid_PO_Parish").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Parish").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ParishName).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.DistrictO).WithMany(p => p.PO_Parish)
                .HasForeignKey(d => d.DistrictOid)
                .HasConstraintName("FK_PO_Parish_DistrictOid");
        });

        modelBuilder.Entity<PO_Person>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Person").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_PO_Person").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(321);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.PO_Person)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_PO_Person_ObjectType");
        });

        modelBuilder.Entity<PO_Phone_Number>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CountryCode, "iCountryCode_PO_Phone_Number").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Phone_Number").HasFillFactor(70);

            entity.HasIndex(e => e.PhoneType, "iPhoneType_PO_Phone_Number").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedContact, "iRelatedContact_PO_Phone_Number").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirm, "iRelatedFirm_PO_Phone_Number").HasFillFactor(70);

            entity.HasIndex(e => e.AutoAddedFromFirm, "İAUTOADDEDFROMFİRM_PO_PHONE_NUMBER").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AreaCode).HasMaxLength(100);
            entity.Property(e => e.Extension).HasMaxLength(100);
            entity.Property(e => e.Number).HasMaxLength(100);

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.PO_Phone_Number)
                .HasForeignKey(d => d.CountryCode)
                .HasConstraintName("FK_PO_Phone_Number_CountryCode");

            entity.HasOne(d => d.PhoneTypeNavigation).WithMany(p => p.PO_Phone_Number)
                .HasForeignKey(d => d.PhoneType)
                .HasConstraintName("FK_PO_Phone_Number_PhoneType");

            entity.HasOne(d => d.RelatedContactNavigation).WithMany(p => p.PO_Phone_Number)
                .HasForeignKey(d => d.RelatedContact)
                .HasConstraintName("FK_PO_Phone_Number_RelatedContact");

            entity.HasOne(d => d.RelatedFirmNavigation).WithMany(p => p.PO_Phone_Number)
                .HasForeignKey(d => d.RelatedFirm)
                .HasConstraintName("FK_PO_Phone_Number_RelatedFirm");
        });

        modelBuilder.Entity<PO_Phone_Type>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Phone_Type").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_PO_Phone_Type").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_PO_Phone_Type").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TypeName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.PO_Phone_Type_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_PO_Phone_Type__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.PO_Phone_Type_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_PO_Phone_Type__LastModifiedBy");
        });

        modelBuilder.Entity<PO_Prepared_Form>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Prepared_Form").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FileName).HasMaxLength(260);
            entity.Property(e => e.FullName).HasMaxLength(260);
        });

        modelBuilder.Entity<PO_Social_Media>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PO_Social_Media").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.smFacebook).HasMaxLength(100);
            entity.Property(e => e.smGooglePlus).HasMaxLength(100);
            entity.Property(e => e.smInstagram).HasMaxLength(100);
            entity.Property(e => e.smLinkedIn).HasMaxLength(100);
            entity.Property(e => e.smSkype).HasMaxLength(100);
            entity.Property(e => e.smTwitter).HasMaxLength(100);
            entity.Property(e => e.smYoutube).HasMaxLength(100);
        });

        modelBuilder.Entity<RI_Activity_Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Activity, "iActivity_RI_Activity_Product").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Activity_Product").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "iRelatedProduct_RI_Activity_Product").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Activity_Product").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Activity_Product").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.VariantCanConfig).HasMaxLength(100);
            entity.Property(e => e.VariantCode).HasMaxLength(100);
            entity.Property(e => e.VariantDescription).HasMaxLength(100);
            entity.Property(e => e.VariantName).HasMaxLength(100);
            entity.Property(e => e.VariantRef).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ActivityNavigation).WithMany(p => p.RI_Activity_Product)
                .HasForeignKey(d => d.Activity)
                .HasConstraintName("FK_RI_Activity_Product_Activity");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Activity_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_Activity_Product_RelatedProduct");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Activity_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Activity_Product__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Activity_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Activity_Product__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Contact_PhoneNumber>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Contact_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e.PhoneNumberRef, "iPhoneNumberRef_RI_Contact_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Contact_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Contact_PhoneNumber").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PhoneNumberRefNavigation).WithMany(p => p.RI_Contact_PhoneNumber)
                .HasForeignKey(d => d.PhoneNumberRef)
                .HasConstraintName("FK_RI_Contact_PhoneNumber_PhoneNumberRef");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Contact_PhoneNumber_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Contact_PhoneNumber__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Contact_PhoneNumber_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Contact_PhoneNumber__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Contact_Product>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_RI_CONTACT_PRODUCT");

            entity.HasIndex(e => e.Contact, "İCONTACT_RI_CONTACT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_RI_CONTACT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "İRELATEDPRODUCT_RI_CONTACT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_RI_CONTACT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_RI_CONTACT_PRODUCT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ContactNavigation).WithMany(p => p.RI_Contact_Product)
                .HasForeignKey(d => d.Contact)
                .HasConstraintName("FK_RI_CONTACT_PRODUCT_CONTACT");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Contact_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_CONTACT_PRODUCT_RELATEDPRODUCT");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Contact_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_CONTACT_PRODUCT__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Contact_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_CONTACT_PRODUCT__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<RI_Event_Product>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_RI_EVENT_PRODUCT");

            entity.HasIndex(e => e.Event, "İEVENT_RI_EVENT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_RI_EVENT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "İRELATEDPRODUCT_RI_EVENT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_RI_EVENT_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_RI_EVENT_PRODUCT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.EventNavigation).WithMany(p => p.RI_Event_Product)
                .HasForeignKey(d => d.Event)
                .HasConstraintName("FK_RI_EVENT_PRODUCT_EVENT");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Event_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_EVENT_PRODUCT_RELATEDPRODUCT");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Event_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_EVENT_PRODUCT__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Event_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_EVENT_PRODUCT__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<RI_Firm_PhoneNumber>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Firm_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e.PhoneNumberRef, "iPhoneNumberRef_RI_Firm_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Firm_PhoneNumber").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Firm_PhoneNumber").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PhoneNumberRefNavigation).WithMany(p => p.RI_Firm_PhoneNumber)
                .HasForeignKey(d => d.PhoneNumberRef)
                .HasConstraintName("FK_RI_Firm_PhoneNumber_PhoneNumberRef");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Firm_PhoneNumber_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Firm_PhoneNumber__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Firm_PhoneNumber_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Firm_PhoneNumber__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Firm_Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Firm, "iFirm_RI_Firm_Product").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Firm_Product").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "iRelatedProduct_RI_Firm_Product").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Firm_Product").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Firm_Product").HasFillFactor(70);

            entity.HasIndex(e => e.MarkaModel, "İMARKAMODEL_RI_FİRM_PRODUCT");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CihazKodu).HasMaxLength(120);
            entity.Property(e => e.GarantiBitisTarih).HasColumnType("datetime");
            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
            entity.Property(e => e.Key).HasMaxLength(120);
            entity.Property(e => e.Office).HasMaxLength(120);
            entity.Property(e => e.OfficeKey).HasMaxLength(120);
            entity.Property(e => e.SatisTarihi).HasColumnType("datetime");
            entity.Property(e => e.SeriNo).HasMaxLength(120);
            entity.Property(e => e.UrunTuru).HasMaxLength(120);
            entity.Property(e => e.Windows).HasMaxLength(120);
            entity.Property(e => e.WindowsKey).HasMaxLength(120);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e._Versiyon).HasMaxLength(10);

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.RI_Firm_Product)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK_RI_Firm_Product_Firm");

            entity.HasOne(d => d.MarkaModelNavigation).WithMany(p => p.RI_Firm_Product)
                .HasForeignKey(d => d.MarkaModel)
                .HasConstraintName("FK_RI_FİRM_PRODUCT_MARKAMODEL");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Firm_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_Firm_Product_RelatedProduct");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Firm_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Firm_Product__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Firm_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Firm_Product__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Opportunity_Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Opportunity_Product").HasFillFactor(70);

            entity.HasIndex(e => e.Opportunity, "iOpportunity_RI_Opportunity_Product").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "iRelatedProduct_RI_Opportunity_Product").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Opportunity_Product").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Opportunity_Product").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.OpportunityNavigation).WithMany(p => p.RI_Opportunity_Product)
                .HasForeignKey(d => d.Opportunity)
                .HasConstraintName("FK_RI_Opportunity_Product_Opportunity");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Opportunity_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_Opportunity_Product_RelatedProduct");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Opportunity_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Opportunity_Product__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Opportunity_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Opportunity_Product__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Product_Units_Collections_Properties>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Product_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e.ProductOid, "iProductOid_RI_Product_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedUnit, "iRelatedUnit_RI_Product_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Product_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Product_Units_Collections_Properties").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ProductO).WithMany(p => p.RI_Product_Units_Collections_Properties)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_RI_Product_Units_Collections_Properties_ProductOid");

            entity.HasOne(d => d.RelatedUnitNavigation).WithMany(p => p.RI_Product_Units_Collections_Properties)
                .HasForeignKey(d => d.RelatedUnit)
                .HasConstraintName("FK_RI_Product_Units_Collections_Properties_RelatedUnit");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Product_Units_Collections_Properties_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Product_Units_Collections_Properties__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Product_Units_Collections_Properties_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Product_Units_Collections_Properties__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Ticket_Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Ticket_Product").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProduct, "iRelatedProduct_RI_Ticket_Product").HasFillFactor(70);

            entity.HasIndex(e => e.Ticket, "iTicket_RI_Ticket_Product").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Ticket_Product").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Ticket_Product").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SerialNumber).HasMaxLength(100);
            entity.Property(e => e.VariantCanConfig).HasMaxLength(100);
            entity.Property(e => e.VariantCode).HasMaxLength(100);
            entity.Property(e => e.VariantDescription).HasMaxLength(100);
            entity.Property(e => e.VariantName).HasMaxLength(100);
            entity.Property(e => e.VariantRef).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.RelatedProductNavigation).WithMany(p => p.RI_Ticket_Product)
                .HasForeignKey(d => d.RelatedProduct)
                .HasConstraintName("FK_RI_Ticket_Product_RelatedProduct");

            entity.HasOne(d => d.TicketNavigation).WithMany(p => p.RI_Ticket_Product)
                .HasForeignKey(d => d.Ticket)
                .HasConstraintName("FK_RI_Ticket_Product_Ticket");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Ticket_Product_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Ticket_Product__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Ticket_Product_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Ticket_Product__LastModifiedBy");
        });

        modelBuilder.Entity<RI_Units_Collections_Properties>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RI_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedUnit, "iRelatedUnit_RI_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e.UnitCollectionsOid, "iUnitCollectionsOid_RI_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_RI_Units_Collections_Properties").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RI_Units_Collections_Properties").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.RelatedUnitNavigation).WithMany(p => p.RI_Units_Collections_Properties)
                .HasForeignKey(d => d.RelatedUnit)
                .HasConstraintName("FK_RI_Units_Collections_Properties_RelatedUnit");

            entity.HasOne(d => d.UnitCollectionsO).WithMany(p => p.RI_Units_Collections_Properties)
                .HasForeignKey(d => d.UnitCollectionsOid)
                .HasConstraintName("FK_RI_Units_Collections_Properties_UnitCollectionsOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_Units_Collections_Properties_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_Units_Collections_Properties__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_Units_Collections_Properties_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_Units_Collections_Properties__LastModifiedBy");
        });

        modelBuilder.Entity<RI_User_ERPWarehouse>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_RI_USER_ERPWAREHOUSE");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_RI_USER_ERPWAREHOUSE").HasFillFactor(70);

            entity.HasIndex(e => e.IntegrationSet, "İINTEGRATİONSET_RI_USER_ERPWAREHOUSE").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedUser, "İRELATEDUSER_RI_USER_ERPWAREHOUSE").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_RI_USER_ERPWAREHOUSE").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_RI_USER_ERPWAREHOUSE").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.WarehouseNumber).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.IntegrationSetNavigation).WithMany(p => p.RI_User_ERPWarehouse)
                .HasForeignKey(d => d.IntegrationSet)
                .HasConstraintName("FK_RI_USER_ERPWAREHOUSE_INTEGRATİONSET");

            entity.HasOne(d => d.RelatedUserNavigation).WithMany(p => p.RI_User_ERPWarehouseRelatedUserNavigation)
                .HasForeignKey(d => d.RelatedUser)
                .HasConstraintName("FK_RI_USER_ERPWAREHOUSE_RELATEDUSER");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.RI_User_ERPWarehouse_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_RI_USER_ERPWAREHOUSE__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RI_User_ERPWarehouse_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RI_USER_ERPWAREHOUSE__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<RL_Activity_SalesRep>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Activity_SalesRep").HasFillFactor(70);

            entity.HasIndex(e => new { e.SalesRepOid, e.ActivityOid }, "iSalesRepOidActivityOid_RL_Activity_SalesRep")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.SalesRepOid, "iSalesRepOid_RL_Activity_SalesRep").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Activity_SalesRep)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Activity_SalesRep_ActivityOid");

            entity.HasOne(d => d.SalesRepO).WithMany(p => p.RL_Activity_SalesRep)
                .HasForeignKey(d => d.SalesRepOid)
                .HasConstraintName("FK_RL_Activity_SalesRep_SalesRepOid");
        });

        modelBuilder.Entity<RL_Activity_Task>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ActivityOid, e.TaskOid }, "iActivityOidTaskOid_RL_Activity_Task")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Activity_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_Activity_Task").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Activity_Task)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Activity_Task_ActivityOid");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Activity_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_Activity_Task_TaskOid");
        });

        modelBuilder.Entity<RL_Campaign_Document>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_CAMPAİGN_DOCUMENT");

            entity.HasIndex(e => new { e.CampaignOid, e.RelatedDocuments }, "İCAMPAİGNOİDRELATEDDOCUMENTS_RL_CAMPAİGN_DOCUMENT")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.CampaignOid, "İCAMPAİGNOİD_RL_CAMPAİGN_DOCUMENT").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedDocuments, "İRELATEDDOCUMENTS_RL_CAMPAİGN_DOCUMENT").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.CampaignO).WithMany(p => p.RL_Campaign_Document)
                .HasForeignKey(d => d.CampaignOid)
                .HasConstraintName("FK_RL_CAMPAİGN_DOCUMENT_CAMPAİGNOİD");

            entity.HasOne(d => d.RelatedDocumentsNavigation).WithMany(p => p.RL_Campaign_Document)
                .HasForeignKey(d => d.RelatedDocuments)
                .HasConstraintName("FK_RL_CAMPAİGN_DOCUMENT_RELATEDDOCUMENTS");
        });

        modelBuilder.Entity<RL_Campaign_List_Types>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.CampaignOid, "iCampaignOid_RL_Campaign_List_Types").HasFillFactor(70);

            entity.HasIndex(e => new { e.ListTypes, e.CampaignOid }, "iListTypesCampaignOid_RL_Campaign_List_Types")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ListTypes, "iListTypes_RL_Campaign_List_Types").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.CampaignO).WithMany(p => p.RL_Campaign_List_Types)
                .HasForeignKey(d => d.CampaignOid)
                .HasConstraintName("FK_RL_Campaign_List_Types_CampaignOid");

            entity.HasOne(d => d.ListTypesNavigation).WithMany(p => p.RL_Campaign_List_Types)
                .HasForeignKey(d => d.ListTypes)
                .HasConstraintName("FK_RL_Campaign_List_Types_ListTypes");
        });

        modelBuilder.Entity<RL_Campaign_Product>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_CAMPAİGN_PRODUCT");

            entity.HasIndex(e => new { e.RelatedCampaigns, e.RelatedProducts }, "İRELATEDCAMPAİGNSRELATEDPRODUCTS_RL_CAMPAİGN_PRODUCT")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedCampaigns, "İRELATEDCAMPAİGNS_RL_CAMPAİGN_PRODUCT").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProducts, "İRELATEDPRODUCTS_RL_CAMPAİGN_PRODUCT").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedCampaignsNavigation).WithMany(p => p.RL_Campaign_Product)
                .HasForeignKey(d => d.RelatedCampaigns)
                .HasConstraintName("FK_RL_CAMPAİGN_PRODUCT_RELATEDCAMPAİGNS");

            entity.HasOne(d => d.RelatedProductsNavigation).WithMany(p => p.RL_Campaign_Product)
                .HasForeignKey(d => d.RelatedProducts)
                .HasConstraintName("FK_RL_CAMPAİGN_PRODUCT_RELATEDPRODUCTS");
        });

        modelBuilder.Entity<RL_Contact_Actions_Lists>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ContactActionLists, e.ContactsOid }, "iContactActionListsContactsOid_RL_Contact_Actions_Lists")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactActionLists, "iContactActionLists_RL_Contact_Actions_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.ContactsOid, "iContactsOid_RL_Contact_Actions_Lists").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactActionListsNavigation).WithMany(p => p.RL_Contact_Actions_Lists)
                .HasForeignKey(d => d.ContactActionLists)
                .HasConstraintName("FK_RL_Contact_Actions_Lists_ContactActionLists");

            entity.HasOne(d => d.ContactsO).WithMany(p => p.RL_Contact_Actions_Lists)
                .HasForeignKey(d => d.ContactsOid)
                .HasConstraintName("FK_RL_Contact_Actions_Lists_ContactsOid");
        });

        modelBuilder.Entity<RL_Contact_Activity_Other>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_CONTACT_ACTİVİTY_OTHER");

            entity.HasIndex(e => new { e.ActivityOid, e.ContactOid }, "İACTİVİTYOİDCONTACTOİD_RL_CONTACT_ACTİVİTY_OTHER")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "İACTİVİTYOİD_RL_CONTACT_ACTİVİTY_OTHER").HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "İCONTACTOİD_RL_CONTACT_ACTİVİTY_OTHER").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Contact_Activity_Other)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_CONTACT_ACTİVİTY_OTHER_ACTİVİTYOİD");

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Contact_Activity_Other)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_CONTACT_ACTİVİTY_OTHER_CONTACTOİD");
        });

        modelBuilder.Entity<RL_Contact_List_Types>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.ContactOid, "iContactOid_RL_Contact_List_Types").HasFillFactor(70);

            entity.HasIndex(e => new { e.ListTypes, e.ContactOid }, "iListTypesContactOid_RL_Contact_List_Types")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ListTypes, "iListTypes_RL_Contact_List_Types").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Contact_List_Types)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_Contact_List_Types_ContactOid");

            entity.HasOne(d => d.ListTypesNavigation).WithMany(p => p.RL_Contact_List_Types)
                .HasForeignKey(d => d.ListTypes)
                .HasConstraintName("FK_RL_Contact_List_Types_ListTypes");
        });

        modelBuilder.Entity<RL_Contact_Opportunity_Other>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_CONTACT_OPPORTUNİTY_OTHER");

            entity.HasIndex(e => new { e.ContactOid, e.OpportunityOid }, "İCONTACTOİDOPPORTUNİTYOİD_RL_CONTACT_OPPORTUNİTY_OTHER")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "İCONTACTOİD_RL_CONTACT_OPPORTUNİTY_OTHER").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "İOPPORTUNİTYOİD_RL_CONTACT_OPPORTUNİTY_OTHER").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Contact_Opportunity_Other)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_CONTACT_OPPORTUNİTY_OTHER_CONTACTOİD");

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Contact_Opportunity_Other)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_CONTACT_OPPORTUNİTY_OTHER_OPPORTUNİTYOİD");
        });

        modelBuilder.Entity<RL_Document_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ActivityOid, e.DocumentOid }, "iActivityOidDocumentOid_RL_Document_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Document_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Document_Activity)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Document_Activity_ActivityOid");

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Activity)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Activity_DocumentOid");
        });

        modelBuilder.Entity<RL_Document_Contact>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ContactOid, e.DocumentOid }, "iContactOidDocumentOid_RL_Document_Contact")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "iContactOid_RL_Document_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Contact").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Document_Contact)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_Document_Contact_ContactOid");

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Contact)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Contact_DocumentOid");
        });

        modelBuilder.Entity<RL_Document_Event>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.EventOid }, "iDocumentOidEventOid_RL_Document_Event")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Event").HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Document_Event").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Event)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Event_DocumentOid");

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Document_Event)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Document_Event_EventOid");
        });

        modelBuilder.Entity<RL_Document_Firm>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.FirmOid }, "iDocumentOidFirmOid_RL_Document_Firm")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Document_Firm").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Firm)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Firm_DocumentOid");

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Document_Firm)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Document_Firm_FirmOid");
        });

        modelBuilder.Entity<RL_Document_Opportunity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.OpportunityOid }, "iDocumentOidOpportunityOid_RL_Document_Opportunity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "iOpportunityOid_RL_Document_Opportunity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Opportunity)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Opportunity_DocumentOid");

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Document_Opportunity)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_Document_Opportunity_OpportunityOid");
        });

        modelBuilder.Entity<RL_Document_Product>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.ProductOid }, "iDocumentOidProductOid_RL_Document_Product")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Product").HasFillFactor(70);

            entity.HasIndex(e => e.ProductOid, "iProductOid_RL_Document_Product").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Product)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Product_DocumentOid");

            entity.HasOne(d => d.ProductO).WithMany(p => p.RL_Document_Product)
                .HasForeignKey(d => d.ProductOid)
                .HasConstraintName("FK_RL_Document_Product_ProductOid");
        });

        modelBuilder.Entity<RL_Document_Shares>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_DOCUMENT_SHARES");

            entity.HasIndex(e => new { e.DocumentOid, e.SharesOid }, "İDOCUMENTOİDSHARESOİD_RL_DOCUMENT_SHARES")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "İDOCUMENTOİD_RL_DOCUMENT_SHARES").HasFillFactor(70);

            entity.HasIndex(e => e.SharesOid, "İSHARESOİD_RL_DOCUMENT_SHARES").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Shares)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_DOCUMENT_SHARES_DOCUMENTOİD");

            entity.HasOne(d => d.SharesO).WithMany(p => p.RL_Document_Shares)
                .HasForeignKey(d => d.SharesOid)
                .HasConstraintName("FK_RL_DOCUMENT_SHARES_SHARESOİD");
        });

        modelBuilder.Entity<RL_Document_Task>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.TaskOid }, "iDocumentOidTaskOid_RL_Document_Task")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_Document_Task").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Task)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Task_DocumentOid");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Document_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_Document_Task_TaskOid");
        });

        modelBuilder.Entity<RL_Document_Ticket>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.TicketOid }, "iDocumentOidTicketOid_RL_Document_Ticket")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Document_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_RL_Document_Ticket").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Document_Ticket)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Document_Ticket_DocumentOid");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Document_Ticket)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_Document_Ticket_TicketOid");
        });

        modelBuilder.Entity<RL_Event_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ActivityOid, e.EventOid }, "iActivityOidEventOid_RL_Event_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Event_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Event_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Event_Activity)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Event_Activity_ActivityOid");

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Event_Activity)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Event_Activity_EventOid");
        });

        modelBuilder.Entity<RL_Event_Contact>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ContactOid, e.EventOid }, "iContactOidEventOid_RL_Event_Contact")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "iContactOid_RL_Event_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Event_Contact").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Event_Contact)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_Event_Contact_ContactOid");

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Event_Contact)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Event_Contact_EventOid");
        });

        modelBuilder.Entity<RL_Event_Firm>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.EventOid, e.FirmOid }, "iEventOidFirmOid_RL_Event_Firm")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Event_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Event_Firm").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Event_Firm)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Event_Firm_EventOid");

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Event_Firm)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Event_Firm_FirmOid");
        });

        modelBuilder.Entity<RL_Event_Proposal>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_EVENT_PROPOSAL");

            entity.HasIndex(e => new { e.RelatedEvents, e.RelatedProposals }, "İRELATEDEVENTSRELATEDPROPOSALS_RL_EVENT_PROPOSAL")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedEvents, "İRELATEDEVENTS_RL_EVENT_PROPOSAL").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposals, "İRELATEDPROPOSALS_RL_EVENT_PROPOSAL").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedEventsNavigation).WithMany(p => p.RL_Event_Proposal)
                .HasForeignKey(d => d.RelatedEvents)
                .HasConstraintName("FK_RL_EVENT_PROPOSAL_RELATEDEVENTS");

            entity.HasOne(d => d.RelatedProposalsNavigation).WithMany(p => p.RL_Event_Proposal)
                .HasForeignKey(d => d.RelatedProposals)
                .HasConstraintName("FK_RL_EVENT_PROPOSAL_RELATEDPROPOSALS");
        });

        modelBuilder.Entity<RL_Event_Users>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.EventOid, e.Resources }, "iEventOidResources_RL_Event_Users")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Event_Users").HasFillFactor(70);

            entity.HasIndex(e => e.Resources, "iResources_RL_Event_Users").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Event_Users)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Event_Users_EventOid");

            entity.HasOne(d => d.ResourcesNavigation).WithMany(p => p.RL_Event_Users)
                .HasForeignKey(d => d.Resources)
                .HasConstraintName("FK_RL_Event_Users_Resources");
        });

        modelBuilder.Entity<RL_Firm_Actions_Lists>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.FirmActionLists, e.FirmOid }, "iFirmActionListsFirmOid_RL_Firm_Actions_Lists")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.FirmActionLists, "iFirmActionLists_RL_Firm_Actions_Lists").HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Firm_Actions_Lists").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.FirmActionListsNavigation).WithMany(p => p.RL_Firm_Actions_Lists)
                .HasForeignKey(d => d.FirmActionLists)
                .HasConstraintName("FK_RL_Firm_Actions_Lists_FirmActionLists");

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Firm_Actions_Lists)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Firm_Actions_Lists_FirmOid");
        });

        modelBuilder.Entity<RL_Firm_Contacts>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_FİRM_CONTACTS");

            entity.HasIndex(e => new { e.RelatedContacts, e.RelatedFirms }, "İRELATEDCONTACTSRELATEDFİRMS_RL_FİRM_CONTACTS")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedContacts, "İRELATEDCONTACTS_RL_FİRM_CONTACTS").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirms, "İRELATEDFİRMS_RL_FİRM_CONTACTS").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedContactsNavigation).WithMany(p => p.RL_Firm_Contacts)
                .HasForeignKey(d => d.RelatedContacts)
                .HasConstraintName("FK_RL_FİRM_CONTACTS_RELATEDCONTACTS");

            entity.HasOne(d => d.RelatedFirmsNavigation).WithMany(p => p.RL_Firm_Contacts)
                .HasForeignKey(d => d.RelatedFirms)
                .HasConstraintName("FK_RL_FİRM_CONTACTS_RELATEDFİRMS");
        });

        modelBuilder.Entity<RL_Firm_List_Types>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Firm_List_Types").HasFillFactor(70);

            entity.HasIndex(e => new { e.ListTypes, e.FirmOid }, "iListTypesFirmOid_RL_Firm_List_Types")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ListTypes, "iListTypes_RL_Firm_List_Types").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Firm_List_Types)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Firm_List_Types_FirmOid");

            entity.HasOne(d => d.ListTypesNavigation).WithMany(p => p.RL_Firm_List_Types)
                .HasForeignKey(d => d.ListTypes)
                .HasConstraintName("FK_RL_Firm_List_Types_ListTypes");
        });

        modelBuilder.Entity<RL_Firm_Sectors>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Firm_Sectors").HasFillFactor(70);

            entity.HasIndex(e => new { e.SectorOid, e.FirmOid }, "iSectorOidFirmOid_RL_Firm_Sectors")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.SectorOid, "iSectorOid_RL_Firm_Sectors").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Firm_Sectors)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Firm_Sectors_FirmOid");

            entity.HasOne(d => d.SectorO).WithMany(p => p.RL_Firm_Sectors)
                .HasForeignKey(d => d.SectorOid)
                .HasConstraintName("FK_RL_Firm_Sectors_SectorOid");
        });

        modelBuilder.Entity<RL_Integration_Sets_User>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.IntegrationSetOid, e.UserOid }, "iIntegrationSetOidUserOid_RL_Integration_Sets_User")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.IntegrationSetOid, "iIntegrationSetOid_RL_Integration_Sets_User").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_Integration_Sets_User").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.IntegrationSetO).WithMany(p => p.RL_Integration_Sets_User)
                .HasForeignKey(d => d.IntegrationSetOid)
                .HasConstraintName("FK_RL_Integration_Sets_User_IntegrationSetOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_Integration_Sets_User)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_Integration_Sets_User_UserOid");
        });

        modelBuilder.Entity<RL_Mail_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ActivityOid, e.MailOid }, "iActivityOidMailOid_RL_Mail_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Mail_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Mail_Activity)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Mail_Activity_ActivityOid");

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Activity)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Activity_MailOid");
        });

        modelBuilder.Entity<RL_Mail_Contact>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ContactOid, e.MailOid }, "iContactOidMailOid_RL_Mail_Contact")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "iContactOid_RL_Mail_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Contact").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Mail_Contact)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_Mail_Contact_ContactOid");

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Contact)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Contact_MailOid");
        });

        modelBuilder.Entity<RL_Mail_Firm>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.FirmOid, e.MailOid }, "iFirmOidMailOid_RL_Mail_Firm")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Mail_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Firm").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Mail_Firm)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Mail_Firm_FirmOid");

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Firm)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Firm_MailOid");
        });

        modelBuilder.Entity<RL_Mail_Opportunity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.MailOid, e.OpportunityOid }, "iMailOidOpportunityOid_RL_Mail_Opportunity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "iOpportunityOid_RL_Mail_Opportunity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Opportunity)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Opportunity_MailOid");

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Mail_Opportunity)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_Mail_Opportunity_OpportunityOid");
        });

        modelBuilder.Entity<RL_Mail_Proposal>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.MailOid, e.RelatedProposalsOid }, "iMailOidRelatedProposalsOid_RL_Mail_Proposal")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Proposal").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposalsOid, "iRelatedProposalsOid_RL_Mail_Proposal").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Proposal)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Proposal_MailOid");

            entity.HasOne(d => d.RelatedProposalsO).WithMany(p => p.RL_Mail_Proposal)
                .HasForeignKey(d => d.RelatedProposalsOid)
                .HasConstraintName("FK_RL_Mail_Proposal_RelatedProposalsOid");
        });

        modelBuilder.Entity<RL_Mail_Task>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.MailOid, e.TaskOid }, "iMailOidTaskOid_RL_Mail_Task")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_Mail_Task").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Task)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Task_MailOid");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Mail_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_Mail_Task_TaskOid");
        });

        modelBuilder.Entity<RL_Mail_Ticket>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.MailOid, e.TicketOid }, "iMailOidTicketOid_RL_Mail_Ticket")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.MailOid, "iMailOid_RL_Mail_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_RL_Mail_Ticket").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.MailO).WithMany(p => p.RL_Mail_Ticket)
                .HasForeignKey(d => d.MailOid)
                .HasConstraintName("FK_RL_Mail_Ticket_MailOid");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Mail_Ticket)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_Mail_Ticket_TicketOid");
        });

        modelBuilder.Entity<RL_Notes_Contact>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ContactOid, e.NotesOid }, "iContactOidNotesOid_RL_Notes_Contact")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ContactOid, "iContactOid_RL_Notes_Contact").HasFillFactor(70);

            entity.HasIndex(e => e.NotesOid, "iNotesOid_RL_Notes_Contact").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ContactO).WithMany(p => p.RL_Notes_Contact)
                .HasForeignKey(d => d.ContactOid)
                .HasConstraintName("FK_RL_Notes_Contact_ContactOid");

            entity.HasOne(d => d.NotesO).WithMany(p => p.RL_Notes_Contact)
                .HasForeignKey(d => d.NotesOid)
                .HasConstraintName("FK_RL_Notes_Contact_NotesOid");
        });

        modelBuilder.Entity<RL_Notes_Departments>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DepartmentOid, e.NotesOid }, "iDepartmentOidNotesOid_RL_Notes_Departments")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DepartmentOid, "iDepartmentOid_RL_Notes_Departments").HasFillFactor(70);

            entity.HasIndex(e => e.NotesOid, "iNotesOid_RL_Notes_Departments").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DepartmentO).WithMany(p => p.RL_Notes_Departments)
                .HasForeignKey(d => d.DepartmentOid)
                .HasConstraintName("FK_RL_Notes_Departments_DepartmentOid");

            entity.HasOne(d => d.NotesO).WithMany(p => p.RL_Notes_Departments)
                .HasForeignKey(d => d.NotesOid)
                .HasConstraintName("FK_RL_Notes_Departments_NotesOid");
        });

        modelBuilder.Entity<RL_Notes_Firm>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.FirmOid, e.NotesOid }, "iFirmOidNotesOid_RL_Notes_Firm")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "iFirmOid_RL_Notes_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.NotesOid, "iNotesOid_RL_Notes_Firm").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.FirmO).WithMany(p => p.RL_Notes_Firm)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_RL_Notes_Firm_FirmOid");

            entity.HasOne(d => d.NotesO).WithMany(p => p.RL_Notes_Firm)
                .HasForeignKey(d => d.NotesOid)
                .HasConstraintName("FK_RL_Notes_Firm_NotesOid");
        });

        modelBuilder.Entity<RL_Notes_User>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.NotesOid, e.UserOid }, "iNotesOidUserOid_RL_Notes_User")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.NotesOid, "iNotesOid_RL_Notes_User").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_Notes_User").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.NotesO).WithMany(p => p.RL_Notes_User)
                .HasForeignKey(d => d.NotesOid)
                .HasConstraintName("FK_RL_Notes_User_NotesOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_Notes_User)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_Notes_User_UserOid");
        });

        modelBuilder.Entity<RL_Opportunity_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ActivityOid, e.OpportunityOid }, "iActivityOidOpportunityOid_RL_Opportunity_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "iActivityOid_RL_Opportunity_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "iOpportunityOid_RL_Opportunity_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Opportunity_Activity)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_Opportunity_Activity_ActivityOid");

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Opportunity_Activity)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_Opportunity_Activity_OpportunityOid");
        });

        modelBuilder.Entity<RL_Opportunity_Event>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.EventOid, e.OpportunityOid }, "iEventOidOpportunityOid_RL_Opportunity_Event")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Opportunity_Event").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "iOpportunityOid_RL_Opportunity_Event").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Opportunity_Event)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Opportunity_Event_EventOid");

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Opportunity_Event)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_Opportunity_Event_OpportunityOid");
        });

        modelBuilder.Entity<RL_Opportunity_Stage_Criteria>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.CriterionOid, e.OpportunityStageOid }, "iCriterionOidOpportunityStageOid_RL_Opportunity_Stage_Criteria")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.CriterionOid, "iCriterionOid_RL_Opportunity_Stage_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityStageOid, "iOpportunityStageOid_RL_Opportunity_Stage_Criteria").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.CriterionO).WithMany(p => p.RL_Opportunity_Stage_Criteria)
                .HasForeignKey(d => d.CriterionOid)
                .HasConstraintName("FK_RL_Opportunity_Stage_Criteria_CriterionOid");

            entity.HasOne(d => d.OpportunityStageO).WithMany(p => p.RL_Opportunity_Stage_Criteria)
                .HasForeignKey(d => d.OpportunityStageOid)
                .HasConstraintName("FK_RL_Opportunity_Stage_Criteria_OpportunityStageOid");
        });

        modelBuilder.Entity<RL_Opportunity_Task>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.OpportunityOid, e.TaskOid }, "iOpportunityOidTaskOid_RL_Opportunity_Task")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.OpportunityOid, "iOpportunityOid_RL_Opportunity_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_Opportunity_Task").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_Opportunity_Task)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_Opportunity_Task_OpportunityOid");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Opportunity_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_Opportunity_Task_TaskOid");
        });

        modelBuilder.Entity<RL_Price_Types_Users>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RL_Price_Types_Users").HasFillFactor(70);

            entity.HasIndex(e => e.PriceType_, "iPriceType__RL_Price_Types_Users").HasFillFactor(70);

            entity.HasIndex(e => e.User_, "iUser__RL_Price_Types_Users").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_RL_Price_Types_Users").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.PriceType_Navigation).WithMany(p => p.RL_Price_Types_Users)
                .HasForeignKey(d => d.PriceType_)
                .HasConstraintName("FK_RL_Price_Types_Users_PriceType_");

            entity.HasOne(d => d.User_Navigation).WithMany(p => p.RL_Price_Types_UsersUser_Navigation)
                .HasForeignKey(d => d.User_)
                .HasConstraintName("FK_RL_Price_Types_Users_User_");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.RL_Price_Types_Users_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_RL_Price_Types_Users__LastModifiedBy");
        });

        modelBuilder.Entity<RL_Product_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RelatedActivityOid, e.RelatedProductsOid }, "iRelatedActivityOidRelatedProductsOid_RL_Product_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedActivityOid, "iRelatedActivityOid_RL_Product_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProductsOid, "iRelatedProductsOid_RL_Product_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedActivityO).WithMany(p => p.RL_Product_Activity)
                .HasForeignKey(d => d.RelatedActivityOid)
                .HasConstraintName("FK_RL_Product_Activity_RelatedActivityOid");

            entity.HasOne(d => d.RelatedProductsO).WithMany(p => p.RL_Product_Activity)
                .HasForeignKey(d => d.RelatedProductsOid)
                .HasConstraintName("FK_RL_Product_Activity_RelatedProductsOid");
        });

        modelBuilder.Entity<RL_Product_Event>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_PRODUCT_EVENT");

            entity.HasIndex(e => new { e.RelatedEventsOid, e.RelatedProductsOid }, "İRELATEDEVENTSOİDRELATEDPRODUCTSOİD_RL_PRODUCT_EVENT")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedEventsOid, "İRELATEDEVENTSOİD_RL_PRODUCT_EVENT").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProductsOid, "İRELATEDPRODUCTSOİD_RL_PRODUCT_EVENT").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedEventsO).WithMany(p => p.RL_Product_Event)
                .HasForeignKey(d => d.RelatedEventsOid)
                .HasConstraintName("FK_RL_PRODUCT_EVENT_RELATEDEVENTSOİD");

            entity.HasOne(d => d.RelatedProductsO).WithMany(p => p.RL_Product_Event)
                .HasForeignKey(d => d.RelatedProductsOid)
                .HasConstraintName("FK_RL_PRODUCT_EVENT_RELATEDPRODUCTSOİD");
        });

        modelBuilder.Entity<RL_Product_Firm>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RelatedFirmsOid, e.RelatedProductsOid }, "iRelatedFirmsOidRelatedProductsOid_RL_Product_Firm")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirmsOid, "iRelatedFirmsOid_RL_Product_Firm").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProductsOid, "iRelatedProductsOid_RL_Product_Firm").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedFirmsO).WithMany(p => p.RL_Product_Firm)
                .HasForeignKey(d => d.RelatedFirmsOid)
                .HasConstraintName("FK_RL_Product_Firm_RelatedFirmsOid");

            entity.HasOne(d => d.RelatedProductsO).WithMany(p => p.RL_Product_Firm)
                .HasForeignKey(d => d.RelatedProductsOid)
                .HasConstraintName("FK_RL_Product_Firm_RelatedProductsOid");
        });

        modelBuilder.Entity<RL_Product_Opportunity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RelatedOpportunityOid, e.RelatedProductsOid }, "iRelatedOpportunityOidRelatedProductsOid_RL_Product_Opportunity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedOpportunityOid, "iRelatedOpportunityOid_RL_Product_Opportunity").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProductsOid, "iRelatedProductsOid_RL_Product_Opportunity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedOpportunityO).WithMany(p => p.RL_Product_Opportunity)
                .HasForeignKey(d => d.RelatedOpportunityOid)
                .HasConstraintName("FK_RL_Product_Opportunity_RelatedOpportunityOid");

            entity.HasOne(d => d.RelatedProductsO).WithMany(p => p.RL_Product_Opportunity)
                .HasForeignKey(d => d.RelatedProductsOid)
                .HasConstraintName("FK_RL_Product_Opportunity_RelatedProductsOid");
        });

        modelBuilder.Entity<RL_Product_Ticket>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RelatedProductsOid, e.RelatedTicketOid }, "iRelatedProductsOidRelatedTicketOid_RL_Product_Ticket")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProductsOid, "iRelatedProductsOid_RL_Product_Ticket").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedTicketOid, "iRelatedTicketOid_RL_Product_Ticket").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedProductsO).WithMany(p => p.RL_Product_Ticket)
                .HasForeignKey(d => d.RelatedProductsOid)
                .HasConstraintName("FK_RL_Product_Ticket_RelatedProductsOid");

            entity.HasOne(d => d.RelatedTicketO).WithMany(p => p.RL_Product_Ticket)
                .HasForeignKey(d => d.RelatedTicketOid)
                .HasConstraintName("FK_RL_Product_Ticket_RelatedTicketOid");
        });

        modelBuilder.Entity<RL_Proposal_Activity>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RelatedActivityOid, e.RelatedProposalsOid }, "iRelatedActivityOidRelatedProposalsOid_RL_Proposal_Activity")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedActivityOid, "iRelatedActivityOid_RL_Proposal_Activity").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposalsOid, "iRelatedProposalsOid_RL_Proposal_Activity").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedActivityO).WithMany(p => p.RL_Proposal_Activity)
                .HasForeignKey(d => d.RelatedActivityOid)
                .HasConstraintName("FK_RL_Proposal_Activity_RelatedActivityOid");

            entity.HasOne(d => d.RelatedProposalsO).WithMany(p => p.RL_Proposal_Activity)
                .HasForeignKey(d => d.RelatedProposalsOid)
                .HasConstraintName("FK_RL_Proposal_Activity_RelatedProposalsOid");
        });

        modelBuilder.Entity<RL_Proposal_OtherFirms>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_PROPOSAL_OTHERFİRMS");

            entity.HasIndex(e => new { e.OtherRelatedFirms, e.OtherRelatedProposals }, "İOTHERRELATEDFİRMSOTHERRELATEDPROPOSALS_RL_PROPOSAL_OTHERFİRMS")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.OtherRelatedFirms, "İOTHERRELATEDFİRMS_RL_PROPOSAL_OTHERFİRMS").HasFillFactor(70);

            entity.HasIndex(e => e.OtherRelatedProposals, "İOTHERRELATEDPROPOSALS_RL_PROPOSAL_OTHERFİRMS").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.OtherRelatedFirmsNavigation).WithMany(p => p.RL_Proposal_OtherFirms)
                .HasForeignKey(d => d.OtherRelatedFirms)
                .HasConstraintName("FK_RL_PROPOSAL_OTHERFİRMS_OTHERRELATEDFİRMS");

            entity.HasOne(d => d.OtherRelatedProposalsNavigation).WithMany(p => p.RL_Proposal_OtherFirms)
                .HasForeignKey(d => d.OtherRelatedProposals)
                .HasConstraintName("FK_RL_PROPOSAL_OTHERFİRMS_OTHERRELATEDPROPOSALS");
        });

        modelBuilder.Entity<RL_Proposal_Stage_Criteria>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.CriterionOid, e.ProposalStageOid }, "iCriterionOidProposalStageOid_RL_Proposal_Stage_Criteria")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.CriterionOid, "iCriterionOid_RL_Proposal_Stage_Criteria").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalStageOid, "iProposalStageOid_RL_Proposal_Stage_Criteria").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.CriterionO).WithMany(p => p.RL_Proposal_Stage_Criteria)
                .HasForeignKey(d => d.CriterionOid)
                .HasConstraintName("FK_RL_Proposal_Stage_Criteria_CriterionOid");

            entity.HasOne(d => d.ProposalStageO).WithMany(p => p.RL_Proposal_Stage_Criteria)
                .HasForeignKey(d => d.ProposalStageOid)
                .HasConstraintName("FK_RL_Proposal_Stage_Criteria_ProposalStageOid");
        });

        modelBuilder.Entity<RL_Proposal_Task>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_PROPOSAL_TASK");

            entity.HasIndex(e => new { e.ProposalOid, e.TaskOid }, "İPROPOSALOİDTASKOİD_RL_PROPOSAL_TASK")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "İPROPOSALOİD_RL_PROPOSAL_TASK").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "İTASKOİD_RL_PROPOSAL_TASK").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ProposalO).WithMany(p => p.RL_Proposal_Task)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_RL_PROPOSAL_TASK_PROPOSALOİD");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Proposal_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_PROPOSAL_TASK_TASKOİD");
        });

        modelBuilder.Entity<RL_Proposals_Documents>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DocumentOid, e.ProposalOid }, "iDocumentOidProposalOid_RL_Proposals_Documents")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DocumentOid, "iDocumentOid_RL_Proposals_Documents").HasFillFactor(70);

            entity.HasIndex(e => e.ProposalOid, "iProposalOid_RL_Proposals_Documents").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DocumentO).WithMany(p => p.RL_Proposals_Documents)
                .HasForeignKey(d => d.DocumentOid)
                .HasConstraintName("FK_RL_Proposals_Documents_DocumentOid");

            entity.HasOne(d => d.ProposalO).WithMany(p => p.RL_Proposals_Documents)
                .HasForeignKey(d => d.ProposalOid)
                .HasConstraintName("FK_RL_Proposals_Documents_ProposalOid");
        });

        modelBuilder.Entity<RL_SalesRep_Opportunity>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_SALESREP_OPPORTUNİTY");

            entity.HasIndex(e => e.OpportunityOid, "İOPPORTUNİTYOİD_RL_SALESREP_OPPORTUNİTY").HasFillFactor(70);

            entity.HasIndex(e => new { e.RelatedSalesRep, e.OpportunityOid }, "İRELATEDSALESREPOPPORTUNİTYOİD_RL_SALESREP_OPPORTUNİTY")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedSalesRep, "İRELATEDSALESREP_RL_SALESREP_OPPORTUNİTY").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.OpportunityO).WithMany(p => p.RL_SalesRep_Opportunity)
                .HasForeignKey(d => d.OpportunityOid)
                .HasConstraintName("FK_RL_SALESREP_OPPORTUNİTY_OPPORTUNİTYOİD");

            entity.HasOne(d => d.RelatedSalesRepNavigation).WithMany(p => p.RL_SalesRep_Opportunity)
                .HasForeignKey(d => d.RelatedSalesRep)
                .HasConstraintName("FK_RL_SALESREP_OPPORTUNİTY_RELATEDSALESREP");
        });

        modelBuilder.Entity<RL_Task_Activity>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_TASK_ACTİVİTY");

            entity.HasIndex(e => new { e.EventOid, e.TaskOid }, "İEVENTOİDTASKOİD_RL_TASK_ACTİVİTY")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "İEVENTOİD_RL_TASK_ACTİVİTY").HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "İTASKOİD_RL_TASK_ACTİVİTY").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Task_Activity)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_TASK_ACTİVİTY_EVENTOİD");

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Task_Activity)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_TASK_ACTİVİTY_TASKOİD");
        });

        modelBuilder.Entity<RL_Ticket_Activity>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_TİCKET_ACTİVİTY");

            entity.HasIndex(e => new { e.ActivityOid, e.TicketOid }, "İACTİVİTYOİDTİCKETOİD_RL_TİCKET_ACTİVİTY")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ActivityOid, "İACTİVİTYOİD_RL_TİCKET_ACTİVİTY").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "İTİCKETOİD_RL_TİCKET_ACTİVİTY").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ActivityO).WithMany(p => p.RL_Ticket_Activity)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_RL_TİCKET_ACTİVİTY_ACTİVİTYOİD");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Ticket_Activity)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_TİCKET_ACTİVİTY_TİCKETOİD");
        });

        modelBuilder.Entity<RL_Ticket_Event>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.EventOid, e.TicketOid }, "iEventOidTicketOid_RL_Ticket_Event")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "iEventOid_RL_Ticket_Event").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_RL_Ticket_Event").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.EventO).WithMany(p => p.RL_Ticket_Event)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_RL_Ticket_Event_EventOid");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Ticket_Event)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_Ticket_Event_TicketOid");
        });

        modelBuilder.Entity<RL_Ticket_Personnel>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_TİCKET_PERSONNEL");

            entity.HasIndex(e => new { e.PersonnelOid, e.TicketOid }, "İPERSONNELOİDTİCKETOİD_RL_TİCKET_PERSONNEL")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.PersonnelOid, "İPERSONNELOİD_RL_TİCKET_PERSONNEL").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "İTİCKETOİD_RL_TİCKET_PERSONNEL").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.PersonnelO).WithMany(p => p.RL_Ticket_Personnel)
                .HasForeignKey(d => d.PersonnelOid)
                .HasConstraintName("FK_RL_TİCKET_PERSONNEL_PERSONNELOİD");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Ticket_Personnel)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_TİCKET_PERSONNEL_TİCKETOİD");
        });

        modelBuilder.Entity<RL_Ticket_Proposal>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_RL_TİCKET_PROPOSAL");

            entity.HasIndex(e => new { e.RelatedProposalsOid, e.RelatedTicketOid }, "İRELATEDPROPOSALSOİDRELATEDTİCKETOİD_RL_TİCKET_PROPOSAL")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RelatedProposalsOid, "İRELATEDPROPOSALSOİD_RL_TİCKET_PROPOSAL").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedTicketOid, "İRELATEDTİCKETOİD_RL_TİCKET_PROPOSAL").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RelatedProposalsO).WithMany(p => p.RL_Ticket_Proposal)
                .HasForeignKey(d => d.RelatedProposalsOid)
                .HasConstraintName("FK_RL_TİCKET_PROPOSAL_RELATEDPROPOSALSOİD");

            entity.HasOne(d => d.RelatedTicketO).WithMany(p => p.RL_Ticket_Proposal)
                .HasForeignKey(d => d.RelatedTicketOid)
                .HasConstraintName("FK_RL_TİCKET_PROPOSAL_RELATEDTİCKETOİD");
        });

        modelBuilder.Entity<RL_Ticket_Task>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.TaskOid, e.TicketOid }, "iTaskOidTicketOid_RL_Ticket_Task")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_Ticket_Task").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_RL_Ticket_Task").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_Ticket_Task)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_Ticket_Task_TaskOid");

            entity.HasOne(d => d.TicketO).WithMany(p => p.RL_Ticket_Task)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_RL_Ticket_Task_TicketOid");
        });

        modelBuilder.Entity<RL_User_Role>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.RoleOid, e.UserOid }, "iRoleOidUserOid_RL_User_Role")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.RoleOid, "iRoleOid_RL_User_Role").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_User_Role").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RoleO).WithMany(p => p.RL_User_Role)
                .HasForeignKey(d => d.RoleOid)
                .HasConstraintName("FK_RL_User_Role_RoleOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_User_Role)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_User_Role_UserOid");
        });

        modelBuilder.Entity<RL_User_Sales_Rep>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.SalesRepOid, e.UserOid }, "iSalesRepOidUserOid_RL_User_Sales_Rep")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.SalesRepOid, "iSalesRepOid_RL_User_Sales_Rep").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_User_Sales_Rep").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.SalesRepO).WithMany(p => p.RL_User_Sales_Rep)
                .HasForeignKey(d => d.SalesRepOid)
                .HasConstraintName("FK_RL_User_Sales_Rep_SalesRepOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_User_Sales_Rep)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_User_Sales_Rep_UserOid");
        });

        modelBuilder.Entity<RL_User_Tasks>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.TaskOid, e.UserOid }, "iTaskOidUserOid_RL_User_Tasks")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.TaskOid, "iTaskOid_RL_User_Tasks").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_User_Tasks").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.TaskO).WithMany(p => p.RL_User_Tasks)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_RL_User_Tasks_TaskOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_User_Tasks)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_User_Tasks_UserOid");
        });

        modelBuilder.Entity<RL_Users_Departments>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.DepartmentOid, e.UserOid }, "iDepartmentOidUserOid_RL_Users_Departments")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.DepartmentOid, "iDepartmentOid_RL_Users_Departments").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_Users_Departments").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DepartmentO).WithMany(p => p.RL_Users_Departments)
                .HasForeignKey(d => d.DepartmentOid)
                .HasConstraintName("FK_RL_Users_Departments_DepartmentOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_Users_Departments)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_Users_Departments_UserOid");
        });

        modelBuilder.Entity<RL_Users_MySummaryItems>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.MySummaryItemsOid, e.UserOid }, "iMySummaryItemsOidUserOid_RL_Users_MySummaryItems")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.MySummaryItemsOid, "iMySummaryItemsOid_RL_Users_MySummaryItems").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_RL_Users_MySummaryItems").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.MySummaryItemsO).WithMany(p => p.RL_Users_MySummaryItems)
                .HasForeignKey(d => d.MySummaryItemsOid)
                .HasConstraintName("FK_RL_Users_MySummaryItems_MySummaryItemsOid");

            entity.HasOne(d => d.UserO).WithMany(p => p.RL_Users_MySummaryItems)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_RL_Users_MySummaryItems_UserOid");
        });

        modelBuilder.Entity<SS_CloudDrive_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_CLOUDDRİVE_SETTİNGS");

            entity.HasIndex(e => e.AuthUser, "İAUTHUSER_SS_CLOUDDRİVE_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_CLOUDDRİVE_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.AuthUserNavigation).WithMany(p => p.SS_CloudDrive_Settings)
                .HasForeignKey(d => d.AuthUser)
                .HasConstraintName("FK_SS_CLOUDDRİVE_SETTİNGS_AUTHUSER");
        });

        modelBuilder.Entity<SS_DBUpdates>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_DBUPDATES");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_DBUPDATES").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UpdateIssue).HasMaxLength(100);
        });

        modelBuilder.Entity<SS_FilePath_Setting>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_FİLEPATH_SETTİNG");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_FİLEPATH_SETTİNG").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
        });

        modelBuilder.Entity<SS_Generated_Ids>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_Generated_Ids").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.BaseKey).HasMaxLength(100);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<SS_IPS_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_IPS_SETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_IPS_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_SS_IPS_SETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_SS_IPS_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Click2CallUrl).HasMaxLength(250);
            entity.Property(e => e.IPAddress).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.ServiceIPAddress).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.SS_IPS_Settings_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_SS_IPS_SETTİNGS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.SS_IPS_Settings_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_SS_IPS_SETTİNGS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<SS_ListView_Sizes>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_LİSTVİEW_SİZES");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_LİSTVİEW_SİZES");

            entity.HasIndex(e => e.OwnerUser, "İOWNERUSER_SS_LİSTVİEW_SİZES");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ColumnId).HasMaxLength(100);
            entity.Property(e => e.ViewId).HasMaxLength(100);

            entity.HasOne(d => d.OwnerUserNavigation).WithMany(p => p.SS_ListView_Sizes)
                .HasForeignKey(d => d.OwnerUser)
                .HasConstraintName("FK_SS_LİSTVİEW_SİZES_OWNERUSER");
        });

        modelBuilder.Entity<SS_Popup_Window_Sizes>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_Popup_Window_Sizes").HasFillFactor(70);

            entity.HasIndex(e => e.OwnerUser, "iOwnerUser_SS_Popup_Window_Sizes").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ViewId).HasMaxLength(100);

            entity.HasOne(d => d.OwnerUserNavigation).WithMany(p => p.SS_Popup_Window_Sizes)
                .HasForeignKey(d => d.OwnerUser)
                .HasConstraintName("FK_SS_Popup_Window_Sizes_OwnerUser");
        });

        modelBuilder.Entity<SS_SavedView>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_SavedView").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.OwnerView).HasMaxLength(100);
            entity.Property(e => e.ViewName).HasMaxLength(100);
        });

        modelBuilder.Entity<SS_SavedView_Columns>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_SavedView_Columns").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.colCaption).HasMaxLength(100);
            entity.Property(e => e.colFieldName).HasMaxLength(100);
            entity.Property(e => e.colGroupSummaryFormat).HasMaxLength(100);
            entity.Property(e => e.colTotalSummaryFormat).HasMaxLength(100);
        });

        modelBuilder.Entity<SS_Twitter_UserSettings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_TWİTTER_USERSETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_TWİTTER_USERSETTİNGS").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_SS_TWİTTER_USERSETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.SS_Twitter_UserSettings)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_SS_TWİTTER_USERSETTİNGS_USER");
        });

        modelBuilder.Entity<SS_User_Cache>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_USER_CACHE");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_USER_CACHE").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_SS_USER_CACHE").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.WebConfig).HasMaxLength(100);
            entity.Property(e => e.XAFML1).HasMaxLength(100);
            entity.Property(e => e.XAFML2).HasMaxLength(100);
            entity.Property(e => e.XAFML3).HasMaxLength(100);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.SS_User_Cache)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_SS_USER_CACHE_USER");
        });

        modelBuilder.Entity<SS_User_Preferences_General>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_User_Preferences_General").HasFillFactor(70);

            entity.HasIndex(e => e.OwnerUser, "iOwnerUser_SS_User_Preferences_General").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_SS_User_Preferences_General").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.GoogleCalendarSyncStartDate).HasColumnType("datetime");
            entity.Property(e => e.StartupNavigationItem).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.OwnerUserNavigation).WithMany(p => p.SS_User_Preferences_GeneralOwnerUserNavigation)
                .HasForeignKey(d => d.OwnerUser)
                .HasConstraintName("FK_SS_User_Preferences_General_OwnerUser");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.SS_User_Preferences_General_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_SS_User_Preferences_General__LastModifiedBy");
        });

        modelBuilder.Entity<SS_User_Reminder>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_SS_User_Reminder").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ReminderId).HasMaxLength(100);
            entity.Property(e => e.User).HasMaxLength(60);
        });

        modelBuilder.Entity<SS_User_Status>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SS_USER_STATUS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SS_USER_STATUS").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_SS_USER_STATUS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LastDate).HasColumnType("datetime");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.SS_User_Status)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_SS_USER_STATUS_USER");
        });

        modelBuilder.Entity<ST_Action_Authorization>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_ACTİON_AUTHORİZATİON");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_ACTİON_AUTHORİZATİON").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_ST_ACTİON_AUTHORİZATİON").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActionId).HasMaxLength(100);
            entity.Property(e => e.ChoiceActionId).HasMaxLength(100);
            entity.Property(e => e.ObjectType).HasMaxLength(100);
            entity.Property(e => e.TargetDataObjectType).HasMaxLength(100);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.ST_Action_Authorization)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_ST_ACTİON_AUTHORİZATİON_USER");
        });

        modelBuilder.Entity<ST_Activity_Planning>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_ACTİVİTY_PLANNİNG");

            entity.HasIndex(e => e.ActivityOid, "İACTİVİTYOİD_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.HasIndex(e => e.ActivityType, "İACTİVİTYTYPE_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.HasIndex(e => e.EventOid, "İEVENTOİD_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.HasIndex(e => e.FirmOid, "İFİRMOİD_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.HasIndex(e => e.SalesRepOid, "İSALESREPOİD_ST_ACTİVİTY_PLANNİNG").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActivityDate).HasColumnType("datetime");

            entity.HasOne(d => d.ActivityO).WithMany(p => p.ST_Activity_Planning)
                .HasForeignKey(d => d.ActivityOid)
                .HasConstraintName("FK_ST_ACTİVİTY_PLANNİNG_ACTİVİTYOİD");

            entity.HasOne(d => d.ActivityTypeNavigation).WithMany(p => p.ST_Activity_Planning)
                .HasForeignKey(d => d.ActivityType)
                .HasConstraintName("FK_ST_ACTİVİTY_PLANNİNG_ACTİVİTYTYPE");

            entity.HasOne(d => d.EventO).WithMany(p => p.ST_Activity_Planning)
                .HasForeignKey(d => d.EventOid)
                .HasConstraintName("FK_ST_ACTİVİTY_PLANNİNG_EVENTOİD");

            entity.HasOne(d => d.FirmO).WithMany(p => p.ST_Activity_Planning)
                .HasForeignKey(d => d.FirmOid)
                .HasConstraintName("FK_ST_ACTİVİTY_PLANNİNG_FİRMOİD");

            entity.HasOne(d => d.SalesRepO).WithMany(p => p.ST_Activity_Planning)
                .HasForeignKey(d => d.SalesRepOid)
                .HasConstraintName("FK_ST_ACTİVİTY_PLANNİNG_SALESREPOİD");
        });

        modelBuilder.Entity<ST_Comment>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_COMMENT");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_COMMENT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.FileMimeType).HasMaxLength(100);
            entity.Property(e => e.FileURL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModuleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NotifyUsers).HasMaxLength(100);
            entity.Property(e => e.OrderNo).HasMaxLength(100);
            entity.Property(e => e.Parent).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ST_Comment_Upvotes>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_COMMENT_UPVOTES");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_COMMENT_UPVOTES").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ST_Company_Info>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AddressOid, "iAddressOid_ST_Company_Info").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Company_Info").HasFillFactor(70);

            entity.HasIndex(e => e.PhoneOid, "iPhoneOid_ST_Company_Info").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ST_Company_Info").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Company_Info").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppVersion).HasMaxLength(100);
            entity.Property(e => e.EmailAddress1).HasMaxLength(321);
            entity.Property(e => e.FirmId).HasMaxLength(100);
            entity.Property(e => e.FirmTitle).HasMaxLength(100);
            entity.Property(e => e.TaxNo).HasMaxLength(16);
            entity.Property(e => e.TaxOffice).HasMaxLength(25);
            entity.Property(e => e.WebAddress).HasMaxLength(2083);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AddressO).WithMany(p => p.ST_Company_Info)
                .HasForeignKey(d => d.AddressOid)
                .HasConstraintName("FK_ST_Company_Info_AddressOid");

            entity.HasOne(d => d.PhoneO).WithMany(p => p.ST_Company_Info)
                .HasForeignKey(d => d.PhoneOid)
                .HasConstraintName("FK_ST_Company_Info_PhoneOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Company_Info_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_Company_Info__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Company_Info_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Company_Info__LastModifiedBy");
        });

        modelBuilder.Entity<ST_Exchange_Rates>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Exchange_Rates").HasFillFactor(70);

            entity.HasIndex(e => e.RateCurrencyType, "iRateCurrencyType_ST_Exchange_Rates").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Exchange_Rates").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ExchangeRateDate).HasMaxLength(100);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.RateCurrencyTypeNavigation).WithMany(p => p.ST_Exchange_Rates)
                .HasForeignKey(d => d.RateCurrencyType)
                .HasConstraintName("FK_ST_Exchange_Rates_RateCurrencyType");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Exchange_Rates)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Exchange_Rates__LastModifiedBy");
        });

        modelBuilder.Entity<ST_Full_Search>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Full_Search").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SearchText).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Full_Search_Objects>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Full_Search_Objects").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ST_Full_Search_Objects").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Full_Search_Objects").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.BOCriteria).HasMaxLength(100);
            entity.Property(e => e.BODisplayProperty).HasMaxLength(200);
            entity.Property(e => e.BOName).HasMaxLength(100);
            entity.Property(e => e.BONamespace).HasMaxLength(200);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Full_Search_Objects_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_Full_Search_Objects__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Full_Search_Objects_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Full_Search_Objects__LastModifiedBy");
        });

        modelBuilder.Entity<ST_IPS_Logs>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_IPS_LOGS");

            entity.HasIndex(e => e.AgentUser, "İAGENTUSER_ST_IPS_LOGS").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_IPS_LOGS").HasFillFactor(70);

            entity.HasIndex(e => e.LoggedInUser, "İLOGGEDINUSER_ST_IPS_LOGS").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedContact, "İRELATEDCONTACT_ST_IPS_LOGS").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedFirm, "İRELATEDFİRM_ST_IPS_LOGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AgentId).HasMaxLength(20);
            entity.Property(e => e.CallUniqueId).HasMaxLength(60);
            entity.Property(e => e.CallerId).HasMaxLength(60);
            entity.Property(e => e.Date_).HasColumnType("datetime");
            entity.Property(e => e.Extension).HasMaxLength(20);

            entity.HasOne(d => d.AgentUserNavigation).WithMany(p => p.ST_IPS_LogsAgentUserNavigation)
                .HasForeignKey(d => d.AgentUser)
                .HasConstraintName("FK_ST_IPS_LOGS_AGENTUSER");

            entity.HasOne(d => d.LoggedInUserNavigation).WithMany(p => p.ST_IPS_LogsLoggedInUserNavigation)
                .HasForeignKey(d => d.LoggedInUser)
                .HasConstraintName("FK_ST_IPS_LOGS_LOGGEDINUSER");

            entity.HasOne(d => d.RelatedContactNavigation).WithMany(p => p.ST_IPS_Logs)
                .HasForeignKey(d => d.RelatedContact)
                .HasConstraintName("FK_ST_IPS_LOGS_RELATEDCONTACT");

            entity.HasOne(d => d.RelatedFirmNavigation).WithMany(p => p.ST_IPS_Logs)
                .HasForeignKey(d => d.RelatedFirm)
                .HasConstraintName("FK_ST_IPS_LOGS_RELATEDFİRM");
        });

        modelBuilder.Entity<ST_Id_Starters>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Id_Starters").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProposalId).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Installed_Apps>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Installed_Apps").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppName).HasMaxLength(100);
            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.ModuleName).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
            entity.Property(e => e.TargetView).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Installed_Apps_Names>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AppOid, "iAppOid_ST_Installed_Apps_Names").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Installed_Apps_Names").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppMLName).HasMaxLength(100);
            entity.Property(e => e.LanguageCode).HasMaxLength(100);

            entity.HasOne(d => d.AppO).WithMany(p => p.ST_Installed_Apps_Names)
                .HasForeignKey(d => d.AppOid)
                .HasConstraintName("FK_ST_Installed_Apps_Names_AppOid");
        });

        modelBuilder.Entity<ST_MySummary>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_MySummary").HasFillFactor(70);

            entity.HasIndex(e => e.User_, "iUser__ST_MySummary").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UserDepartment).HasMaxLength(100);

            entity.HasOne(d => d.User_Navigation).WithMany(p => p.ST_MySummary)
                .HasForeignKey(d => d.User_)
                .HasConstraintName("FK_ST_MySummary_User_");
        });

        modelBuilder.Entity<ST_MySummary_Cache>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_MySummary_Cache").HasFillFactor(70);

            entity.HasIndex(e => e._Summary, "i_Summary_ST_MySummary_Cache").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._Description).HasMaxLength(100);
            entity.Property(e => e._ItemRef).HasMaxLength(100);
            entity.Property(e => e._Ref).HasMaxLength(100);
            entity.Property(e => e._TargetType).HasMaxLength(100);
            entity.Property(e => e._TargetView).HasMaxLength(100);

            entity.HasOne(d => d._SummaryNavigation).WithMany(p => p.ST_MySummary_Cache)
                .HasForeignKey(d => d._Summary)
                .HasConstraintName("FK_ST_MySummary_Cache__Summary");
        });

        modelBuilder.Entity<ST_MySummary_Items>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_MySummary_Items").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DirectText).HasMaxLength(100);
            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.LocalizationKey).HasMaxLength(100);
            entity.Property(e => e.LocalizationPath).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
            entity.Property(e => e.TargetView).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Prepared_Form_Export_Types>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Prepared_Form_Export_Types").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ExportType).HasMaxLength(100);
            entity.Property(e => e.Extension).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Proposal_Category>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_PROPOSAL_CATEGORY");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.HasIndex(e => e.Parent, "İPARENT_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.HasIndex(e => e.Proposal, "İPROPOSAL_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.HasIndex(e => e.RelatedRevisal, "İRELATEDREVİSAL_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_ST_PROPOSAL_CATEGORY").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ParentNavigation).WithMany(p => p.InverseParentNavigation)
                .HasForeignKey(d => d.Parent)
                .HasConstraintName("FK_ST_PROPOSAL_CATEGORY_PARENT");

            entity.HasOne(d => d.ProposalNavigation).WithMany(p => p.ST_Proposal_Category)
                .HasForeignKey(d => d.Proposal)
                .HasConstraintName("FK_ST_PROPOSAL_CATEGORY_PROPOSAL");

            entity.HasOne(d => d.RelatedRevisalNavigation).WithMany(p => p.ST_Proposal_Category)
                .HasForeignKey(d => d.RelatedRevisal)
                .HasConstraintName("FK_ST_PROPOSAL_CATEGORY_RELATEDREVİSAL");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Proposal_Category_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_PROPOSAL_CATEGORY__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Proposal_Category_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_PROPOSAL_CATEGORY__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<ST_Proposals_ReCalculate_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Proposals_ReCalculate_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ST_Proposals_ReCalculate_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Proposals_ReCalculate_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.PropertyName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Proposals_ReCalculate_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_Proposals_ReCalculate_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Proposals_ReCalculate_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Proposals_ReCalculate_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<ST_Reports>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ReportDescription).HasMaxLength(100);
            entity.Property(e => e.UserDisplayName).HasMaxLength(100);

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.ST_Reports)
                .HasForeignKey<ST_Reports>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ST_Reports_Oid");
        });

        modelBuilder.Entity<ST_Scheduler_User_Settings>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_SCHEDULER_USER_SETTİNGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_SCHEDULER_USER_SETTİNGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UserOid).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Shortcuts>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Shortcuts").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.ShortcutName).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
            entity.Property(e => e.TargetView).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Store_Apps>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Store_Apps").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AddDate).HasColumnType("datetime");
            entity.Property(e => e.AppIsFreeStr).HasMaxLength(100);
            entity.Property(e => e.AppName).HasMaxLength(100);
            entity.Property(e => e.AppShortDescription).HasMaxLength(100);
            entity.Property(e => e.AppSize).HasMaxLength(100);
            entity.Property(e => e.AppVersion).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.Developer).HasMaxLength(100);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_Task_Assign>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_TASK_ASSİGN");

            entity.HasIndex(e => e.AssignedDepartment, "İASSİGNEDDEPARTMENT_ST_TASK_ASSİGN");

            entity.HasIndex(e => e.AssignedTo, "İASSİGNEDTO_ST_TASK_ASSİGN");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_TASK_ASSİGN");

            entity.HasIndex(e => e.TaskOid, "İTASKOİD_ST_TASK_ASSİGN");

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_ST_TASK_ASSİGN");

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_ST_TASK_ASSİGN");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedDepartmentNavigation).WithMany(p => p.ST_Task_Assign)
                .HasForeignKey(d => d.AssignedDepartment)
                .HasConstraintName("FK_ST_TASK_ASSİGN_ASSİGNEDDEPARTMENT");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ST_Task_AssignAssignedToNavigation)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK_ST_TASK_ASSİGN_ASSİGNEDTO");

            entity.HasOne(d => d.TaskO).WithMany(p => p.ST_Task_Assign)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_ST_TASK_ASSİGN_TASKOİD");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Task_Assign_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_TASK_ASSİGN__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Task_Assign_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_TASK_ASSİGN__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<ST_Task_State>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_TASK_STATE");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_TASK_STATE");

            entity.HasIndex(e => e.TaskOid, "İTASKOİD_ST_TASK_STATE");

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_ST_TASK_STATE");

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_ST_TASK_STATE");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Duration).HasMaxLength(70);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.TaskO).WithMany(p => p.ST_Task_State)
                .HasForeignKey(d => d.TaskOid)
                .HasConstraintName("FK_ST_TASK_STATE_TASKOİD");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Task_State_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_TASK_STATE__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Task_State_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_TASK_STATE__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<ST_Ticket_Assign>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AssignedDepartment, "iAssignedDepartment_ST_Ticket_Assign").HasFillFactor(70);

            entity.HasIndex(e => e.AssignedTo, "iAssignedTo_ST_Ticket_Assign").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Ticket_Assign").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_ST_Ticket_Assign").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ST_Ticket_Assign").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Ticket_Assign").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedDepartmentNavigation).WithMany(p => p.ST_Ticket_Assign)
                .HasForeignKey(d => d.AssignedDepartment)
                .HasConstraintName("FK_ST_Ticket_Assign_AssignedDepartment");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ST_Ticket_AssignAssignedToNavigation)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK_ST_Ticket_Assign_AssignedTo");

            entity.HasOne(d => d.TicketO).WithMany(p => p.ST_Ticket_Assign)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_ST_Ticket_Assign_TicketOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Ticket_Assign_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_Ticket_Assign__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Ticket_Assign_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Ticket_Assign__LastModifiedBy");
        });

        modelBuilder.Entity<ST_Ticket_State>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_Ticket_State").HasFillFactor(70);

            entity.HasIndex(e => e.TicketOid, "iTicketOid_ST_Ticket_State").HasFillFactor(70);

            entity.HasIndex(e => e.TicketState, "iTicketState_ST_Ticket_State").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ST_Ticket_State").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_Ticket_State").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Duration).HasMaxLength(70);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.TicketO).WithMany(p => p.ST_Ticket_State)
                .HasForeignKey(d => d.TicketOid)
                .HasConstraintName("FK_ST_Ticket_State_TicketOid");

            entity.HasOne(d => d.TicketStateNavigation).WithMany(p => p.ST_Ticket_State)
                .HasForeignKey(d => d.TicketState)
                .HasConstraintName("FK_ST_Ticket_State_TicketState");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ST_Ticket_State_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ST_Ticket_State__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_Ticket_State_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_Ticket_State__LastModifiedBy");
        });

        modelBuilder.Entity<ST_Update_Schema_Logic>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_UPDATE_SCHEMA_LOGİC");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_UPDATE_SCHEMA_LOGİC").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LogicKey).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_User>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.DefaultIntegrationSet, "İDEFAULTINTEGRATİONSET_ST_USER").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AgentId).HasMaxLength(100);
            entity.Property(e => e.AvatarUrl).HasMaxLength(100);
            entity.Property(e => e.Caption).HasMaxLength(100);
            entity.Property(e => e.DeviceToken).HasMaxLength(100);
            entity.Property(e => e.EMailAddress).HasMaxLength(321);
            entity.Property(e => e.ERPUserName).HasMaxLength(100);
            entity.Property(e => e.Extension).HasMaxLength(100);
            entity.Property(e => e.MailChimpAPIKey).HasMaxLength(300);
            entity.Property(e => e.MySummaryHeaderFilterButtons).HasMaxLength(100);
            entity.Property(e => e.MySummaryToolbarColor).HasMaxLength(100);
            entity.Property(e => e.NetsisDefaultBranchCode).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e._CreatedBy).HasMaxLength(303);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedBy).HasMaxLength(303);
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.DefaultIntegrationSetNavigation).WithMany(p => p.ST_User)
                .HasForeignKey(d => d.DefaultIntegrationSet)
                .HasConstraintName("FK_ST_USER_DEFAULTINTEGRATİONSET");

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.ST_User)
                .HasForeignKey<ST_User>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ST_User_Oid");
        });

        modelBuilder.Entity<ST_UserMessages>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_USERMESSAGES");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_USERMESSAGES").HasFillFactor(70);

            entity.HasIndex(e => e.User, "İUSER_ST_USERMESSAGES").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.ST_UserMessages)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_ST_USERMESSAGES_USER");
        });

        modelBuilder.Entity<ST_UserShortcuts>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_USERSHORTCUTS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_USERSHORTCUTS");

            entity.HasIndex(e => e.UserOid, "İUSEROİD_ST_USERSHORTCUTS");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.HeaderColor).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
            entity.Property(e => e.ViewType).HasMaxLength(100);
            entity.Property(e => e.ViewVariant).HasMaxLength(100);

            entity.HasOne(d => d.UserO).WithMany(p => p.ST_UserShortcuts)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_ST_USERSHORTCUTS_USEROİD");
        });

        modelBuilder.Entity<ST_UserWidgets>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_USERWİDGETS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_USERWİDGETS");

            entity.HasIndex(e => e.UserOid, "İUSEROİD_ST_USERWİDGETS");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.HeaderColor).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);

            entity.HasOne(d => d.UserO).WithMany(p => p.ST_UserWidgets)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_ST_USERWİDGETS_USEROİD");
        });

        modelBuilder.Entity<ST_User_Access_Rights>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AccessDefinitionCode, "iAccessDefinitionCode_ST_User_Access_Rights").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_User_Access_Rights").HasFillFactor(70);

            entity.HasIndex(e => e.UserOId, "iUserOId_ST_User_Access_Rights").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ST_User_Access_Rights").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AccessDefinitionCodeNavigation).WithMany(p => p.ST_User_Access_Rights)
                .HasForeignKey(d => d.AccessDefinitionCode)
                .HasConstraintName("FK_ST_User_Access_Rights_AccessDefinitionCode");

            entity.HasOne(d => d.UserO).WithMany(p => p.ST_User_Access_RightsUserO)
                .HasForeignKey(d => d.UserOId)
                .HasConstraintName("FK_ST_User_Access_Rights_UserOId");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ST_User_Access_Rights_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ST_User_Access_Rights__LastModifiedBy");
        });

        modelBuilder.Entity<ST_User_Apps>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_User_Apps").HasFillFactor(70);

            entity.HasIndex(e => e.UserOid, "iUserOid_ST_User_Apps").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppName).HasMaxLength(100);
            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.ModuleName).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
            entity.Property(e => e.TargetView).HasMaxLength(100);

            entity.HasOne(d => d.UserO).WithMany(p => p.ST_User_Apps)
                .HasForeignKey(d => d.UserOid)
                .HasConstraintName("FK_ST_User_Apps_UserOid");
        });

        modelBuilder.Entity<ST_User_Apps_Names>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ST_User_Apps_Names").HasFillFactor(70);

            entity.HasIndex(e => e.UserAppOid, "iUserAppOid_ST_User_Apps_Names").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppMLName).HasMaxLength(100);
            entity.Property(e => e.LanguageCode).HasMaxLength(100);

            entity.HasOne(d => d.UserAppO).WithMany(p => p.ST_User_Apps_Names)
                .HasForeignKey(d => d.UserAppOid)
                .HasConstraintName("FK_ST_User_Apps_Names_UserAppOid");
        });

        modelBuilder.Entity<ST_User_DockPanelLayouts>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_USER_DOCKPANELLAYOUTS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_USER_DOCKPANELLAYOUTS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.WindowName).HasMaxLength(100);
        });

        modelBuilder.Entity<ST_User_Logs>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ST_USER_LOGS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ST_USER_LOGS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ClassName).HasMaxLength(150);
            entity.Property(e => e.CreatedByUserName).HasMaxLength(60);
            entity.Property(e => e.Date_).HasColumnType("datetime");
            entity.Property(e => e.LocalIP).HasMaxLength(50);
            entity.Property(e => e.NewValue).HasMaxLength(100);
            entity.Property(e => e.ObjectDescription).HasMaxLength(150);
            entity.Property(e => e.ObjectKeyValue).HasMaxLength(50);
            entity.Property(e => e.OldValue).HasMaxLength(100);
            entity.Property(e => e.PropertyName).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(60);
            entity.Property(e => e.WanIP).HasMaxLength(50);
        });

        modelBuilder.Entity<ST_User_Works>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ST_User_Works");

            entity.Property(e => e.Moddate).HasColumnType("datetime");
            entity.Property(e => e.ObjectType)
                .HasMaxLength(49)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(39)
                .IsUnicode(false);
            entity.Property(e => e.ViewId)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SetrowLists>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_SETROWLİSTS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_SETROWLİSTS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
        });

        modelBuilder.Entity<TEKLIF>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TEKLIF");

            entity.Property(e => e.AKTIF_REVIZEID)
                .HasMaxLength(100)
                .HasColumnName("AKTIF REVIZEID");
            entity.Property(e => e.ASAMA).HasMaxLength(100);
            entity.Property(e => e.BIRIM_FIYAT).HasColumnName("BIRIM FIYAT");
            entity.Property(e => e.DURUM)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.FIRMA_KOD)
                .HasMaxLength(42)
                .HasColumnName("FIRMA KOD");
            entity.Property(e => e.FIRMA_UNVAN)
                .HasMaxLength(200)
                .HasColumnName("FIRMA UNVAN");
            entity.Property(e => e.Firma_Rolü)
                .HasMaxLength(30)
                .HasColumnName("Firma Rolü");
            entity.Property(e => e.KISI).HasMaxLength(100);
            entity.Property(e => e.Müşteri_Tipi)
                .HasMaxLength(100)
                .HasColumnName("Müşteri Tipi");
            entity.Property(e => e.Referans_Kaynağı)
                .HasMaxLength(100)
                .HasColumnName("Referans Kaynağı");
            entity.Property(e => e.SATIS_TEMSILCISI)
                .HasMaxLength(100)
                .HasColumnName("SATIS TEMSILCISI");
            entity.Property(e => e.TANIM).HasMaxLength(120);
            entity.Property(e => e.TD_GEN_TOPLAM).HasColumnName("TD GEN TOPLAM");
            entity.Property(e => e.TEKLIF_DOVIZI)
                .HasMaxLength(10)
                .HasColumnName("TEKLIF DOVIZI");
            entity.Property(e => e.TEKLIF_ID).HasColumnName("TEKLIF ID");
            entity.Property(e => e.Teklif_Grubu)
                .HasMaxLength(100)
                .HasColumnName("Teklif Grubu");
            entity.Property(e => e.Teklif_Türü)
                .HasMaxLength(100)
                .HasColumnName("Teklif Türü");
            entity.Property(e => e.URUN).HasMaxLength(200);
            entity.Property(e => e.URUN_DOVIZI)
                .HasMaxLength(10)
                .HasColumnName("URUN DOVIZI");
            entity.Property(e => e.YP_GEN_TOPLAM).HasColumnName("YP GEN TOPLAM");
            entity.Property(e => e.Ürün_Grup_Kodu)
                .HasMaxLength(41)
                .HasColumnName("Ürün Grup Kodu");
            entity.Property(e => e.Ürün_Özel_Kodu)
                .HasMaxLength(41)
                .HasColumnName("Ürün Özel Kodu");
            entity.Property(e => e.Ürün_Özel_Kodu2)
                .HasMaxLength(41)
                .HasColumnName("Ürün Özel Kodu2");
        });

        modelBuilder.Entity<TICKET_USERS>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TICKET_USERS");

            entity.Property(e => e.AD_SOYAD)
                .HasMaxLength(302)
                .HasColumnName("AD SOYAD");
            entity.Property(e => e.E_POSTA)
                .HasMaxLength(321)
                .HasColumnName("E-POSTA");
            entity.Property(e => e.FİRMA).HasMaxLength(200);
            entity.Property(e => e.KULLANICI_ADI)
                .HasMaxLength(120)
                .HasColumnName("KULLANICI ADI");
            entity.Property(e => e.TELEFON_NUMARALARI)
                .HasMaxLength(4000)
                .HasColumnName("TELEFON NUMARALARI");
            entity.Property(e => e.ŞİFRE).HasMaxLength(120);
        });

        modelBuilder.Entity<X1_Analysis>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_Analysis").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ObjectTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_AuditDataItemPersistent>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.AuditedObject, "iAuditedObject_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.ModifiedOn, "iModifiedOn_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.NewObject, "iNewObject_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.OldObject, "iOldObject_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.OperationType, "iOperationType_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.HasIndex(e => e.UserName, "iUserName_X1_AuditDataItemPersistent").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(2048);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NewValue).HasMaxLength(1024);
            entity.Property(e => e.OldValue).HasMaxLength(1024);
            entity.Property(e => e.OperationType).HasMaxLength(100);
            entity.Property(e => e.PropertyName).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.AuditedObjectNavigation).WithMany(p => p.X1_AuditDataItemPersistent)
                .HasForeignKey(d => d.AuditedObject)
                .HasConstraintName("FK_X1_AuditDataItemPersistent_AuditedObject");

            entity.HasOne(d => d.NewObjectNavigation).WithMany(p => p.X1_AuditDataItemPersistentNewObjectNavigation)
                .HasForeignKey(d => d.NewObject)
                .HasConstraintName("FK_X1_AuditDataItemPersistent_NewObject");

            entity.HasOne(d => d.OldObjectNavigation).WithMany(p => p.X1_AuditDataItemPersistentOldObjectNavigation)
                .HasForeignKey(d => d.OldObject)
                .HasConstraintName("FK_X1_AuditDataItemPersistent_OldObject");
        });

        modelBuilder.Entity<X1_AuditedObjectWeakReference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.DisplayName).HasMaxLength(250);

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.X1_AuditedObjectWeakReference)
                .HasForeignKey<X1_AuditedObjectWeakReference>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_X1_AuditedObjectWeakReference_Oid");
        });

        modelBuilder.Entity<X1_KpiDefinition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_KpiDefinition").HasFillFactor(70);

            entity.HasIndex(e => e.KpiInstance, "iKpiInstance_X1_KpiDefinition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Changed).HasColumnType("datetime");
            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Range).HasMaxLength(100);
            entity.Property(e => e.RangeToCompare).HasMaxLength(100);
            entity.Property(e => e.SuppressedSeries).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);

            entity.HasOne(d => d.KpiInstanceNavigation).WithMany(p => p.X1_KpiDefinition)
                .HasForeignKey(d => d.KpiInstance)
                .HasConstraintName("FK_X1_KpiDefinition_KpiInstance");
        });

        modelBuilder.Entity<X1_KpiHistoryItem>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.KpiInstance, "iKpiInstance_X1_KpiHistoryItem").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.RangeEnd).HasColumnType("datetime");
            entity.Property(e => e.RangeStart).HasColumnType("datetime");

            entity.HasOne(d => d.KpiInstanceNavigation).WithMany(p => p.X1_KpiHistoryItem)
                .HasForeignKey(d => d.KpiInstance)
                .HasConstraintName("FK_X1_KpiHistoryItem_KpiInstance");
        });

        modelBuilder.Entity<X1_KpiInstance>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_KpiInstance").HasFillFactor(70);

            entity.HasIndex(e => e.KpiDefinition, "iKpiDefinition_X1_KpiInstance").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ForceMeasurementDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.KpiDefinitionNavigation).WithMany(p => p.X1_KpiInstance)
                .HasForeignKey(d => d.KpiDefinition)
                .HasConstraintName("FK_X1_KpiInstance_KpiDefinition");
        });

        modelBuilder.Entity<X1_KpiScorecard>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_KpiScorecard").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_Kpi_Scorecards_Indicators>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.Indicators, e.Scorecards }, "iIndicatorsScorecards_X1_Kpi_Scorecards_Indicators")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.Indicators, "iIndicators_X1_Kpi_Scorecards_Indicators").HasFillFactor(70);

            entity.HasIndex(e => e.Scorecards, "iScorecards_X1_Kpi_Scorecards_Indicators").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.IndicatorsNavigation).WithMany(p => p.X1_Kpi_Scorecards_Indicators)
                .HasForeignKey(d => d.Indicators)
                .HasConstraintName("FK_X1_Kpi_Scorecards_Indicators_Indicators");

            entity.HasOne(d => d.ScorecardsNavigation).WithMany(p => p.X1_Kpi_Scorecards_Indicators)
                .HasForeignKey(d => d.Scorecards)
                .HasConstraintName("FK_X1_Kpi_Scorecards_Indicators_Scorecards");
        });

        modelBuilder.Entity<X1_ModelDifference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_ModelDifference").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "İOBJECTTYPE_X1_MODELDİFFERENCE").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ContextId).HasMaxLength(100);
            entity.Property(e => e.HistoryCreateActionExecutor).HasMaxLength(100);
            entity.Property(e => e.HistoryCreateDate).HasColumnType("datetime");
            entity.Property(e => e.HistoryModifyActionExecutor).HasMaxLength(100);
            entity.Property(e => e.HistoryModifyDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_ModelDifference)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_MODELDİFFERENCE_OBJECTTYPE");
        });

        modelBuilder.Entity<X1_ModelDifferenceAspect>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_ModelDifferenceAspect").HasFillFactor(70);

            entity.HasIndex(e => e.Owner, "iOwner_X1_ModelDifferenceAspect").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.X1_ModelDifferenceAspect)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_X1_ModelDifferenceAspect_Owner");
        });

        modelBuilder.Entity<X1_ModuleInfo>(entity =>
        {
            entity.Property(e => e.AssemblyFileName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Version).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_ReportDataV2>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_ReportDataV2").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_X1_ReportDataV2").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ObjectTypeName).HasMaxLength(512);
            entity.Property(e => e.ParametersObjectTypeName).HasMaxLength(512);
            entity.Property(e => e.PredefinedReportType).HasMaxLength(512);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_ReportDataV2)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_ReportDataV2_ObjectType");
        });

        modelBuilder.Entity<X1_SecuritySystemMemberPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_SecuritySystemMemberPermissionsObject").HasFillFactor(70);

            entity.HasIndex(e => e.Owner, "iOwner_X1_SecuritySystemMemberPermissionsObject").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.X1_SecuritySystemMemberPermissionsObject)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_X1_SecuritySystemMemberPermissionsObject_Owner");
        });

        modelBuilder.Entity<X1_SecuritySystemObjectPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_SecuritySystemObjectPermissionsObject").HasFillFactor(70);

            entity.HasIndex(e => e.Owner, "iOwner_X1_SecuritySystemObjectPermissionsObject").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.X1_SecuritySystemObjectPermissionsObject)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_X1_SecuritySystemObjectPermissionsObject_Owner");
        });

        modelBuilder.Entity<X1_SecuritySystemRole>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_SecuritySystemRole").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_X1_SecuritySystemRole").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.HiddenNavigationItems).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_SecuritySystemRole)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_SecuritySystemRole_ObjectType");
        });

        modelBuilder.Entity<X1_SecuritySystemTypePermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_SecuritySystemTypePermissionsObject").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_X1_SecuritySystemTypePermissionsObject").HasFillFactor(70);

            entity.HasIndex(e => e.Owner, "iOwner_X1_SecuritySystemTypePermissionsObject").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_SecuritySystemTypePermissionsObject)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_SecuritySystemTypePermissionsObject_ObjectType");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.X1_SecuritySystemTypePermissionsObject)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("FK_X1_SecuritySystemTypePermissionsObject_Owner");
        });

        modelBuilder.Entity<X1_SecuritySystemUser>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_SecuritySystemUser").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_X1_SecuritySystemUser").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_SecuritySystemUser)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_SecuritySystemUser_ObjectType");
        });

        modelBuilder.Entity<X1_SecurityUserBase>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_X1_SECURİTYUSERBASE");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_X1_SECURİTYUSERBASE").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_Security_System_Parent_Child_Roles>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.ChildRoles, e.ParentRoles }, "iChildRolesParentRoles_X1_Security_System_Parent_Child_Roles")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.ChildRoles, "iChildRoles_X1_Security_System_Parent_Child_Roles").HasFillFactor(70);

            entity.HasIndex(e => e.ParentRoles, "iParentRoles_X1_Security_System_Parent_Child_Roles").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.ChildRolesNavigation).WithMany(p => p.X1_Security_System_Parent_Child_RolesChildRolesNavigation)
                .HasForeignKey(d => d.ChildRoles)
                .HasConstraintName("FK_X1_Security_System_Parent_Child_Roles_ChildRoles");

            entity.HasOne(d => d.ParentRolesNavigation).WithMany(p => p.X1_Security_System_Parent_Child_RolesParentRolesNavigation)
                .HasForeignKey(d => d.ParentRoles)
                .HasConstraintName("FK_X1_Security_System_Parent_Child_Roles_ParentRoles");
        });

        modelBuilder.Entity<X1_Security_System_User_Roles>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.Roles, e.Users }, "iRolesUsers_X1_Security_System_User_Roles")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.Roles, "iRoles_X1_Security_System_User_Roles").HasFillFactor(70);

            entity.HasIndex(e => e.Users, "iUsers_X1_Security_System_User_Roles").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.X1_Security_System_User_Roles)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_X1_Security_System_User_Roles_Roles");

            entity.HasOne(d => d.UsersNavigation).WithMany(p => p.X1_Security_System_User_Roles)
                .HasForeignKey(d => d.Users)
                .HasConstraintName("FK_X1_Security_System_User_Roles_Users");
        });

        modelBuilder.Entity<X1_XPObjectType>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.TypeName, "iTypeName_X1_XPObjectType")
                .IsUnique()
                .HasFillFactor(70);

            entity.Property(e => e.AssemblyName).HasMaxLength(254);
            entity.Property(e => e.TypeName).HasMaxLength(254);
        });

        modelBuilder.Entity<X1_XPWeakReference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XPWeakReference").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_X1_XPWeakReference").HasFillFactor(70);

            entity.HasIndex(e => e.TargetType, "iTargetType_X1_XPWeakReference").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TargetKey).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.X1_XPWeakReferenceObjectTypeNavigation)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_X1_XPWeakReference_ObjectType");

            entity.HasOne(d => d.TargetTypeNavigation).WithMany(p => p.X1_XPWeakReferenceTargetTypeNavigation)
                .HasForeignKey(d => d.TargetType)
                .HasConstraintName("FK_X1_XPWeakReference_TargetType");
        });

        modelBuilder.Entity<X1_XpoInstanceKey>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoInstanceKey").HasFillFactor(70);
        });

        modelBuilder.Entity<X1_XpoRunningWorkflowInstanceInfo>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoRunningWorkflowInstanceInfo").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.TargetObjectHandle).HasMaxLength(255);
            entity.Property(e => e.WorkflowName).HasMaxLength(255);
            entity.Property(e => e.WorkflowUniqueId).HasMaxLength(255);
        });

        modelBuilder.Entity<X1_XpoStartWorkflowRequest>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoStartWorkflowRequest").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TargetObjectKey).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);
            entity.Property(e => e.TargetWorkflowUniqueId).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_XpoState>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoState").HasFillFactor(70);

            entity.HasIndex(e => e.StateMachine, "iStateMachine_X1_XpoState").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Caption).HasMaxLength(100);
            entity.Property(e => e.MarkerValue).IsUnicode(false);

            entity.HasOne(d => d.StateMachineNavigation).WithMany(p => p.X1_XpoState)
                .HasForeignKey(d => d.StateMachine)
                .HasConstraintName("FK_X1_XpoState_StateMachine");
        });

        modelBuilder.Entity<X1_XpoStateAppearance>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoStateAppearance").HasFillFactor(70);

            entity.HasIndex(e => e.State, "iState_X1_XpoStateAppearance").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppearanceItemType).HasMaxLength(100);
            entity.Property(e => e.Context).HasMaxLength(100);
            entity.Property(e => e.Method).HasMaxLength(100);
            entity.Property(e => e.TargetItems).HasMaxLength(100);

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.X1_XpoStateAppearance)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK_X1_XpoStateAppearance_State");
        });

        modelBuilder.Entity<X1_XpoStateMachine>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoStateMachine").HasFillFactor(70);

            entity.HasIndex(e => e.StartState, "iStartState_X1_XpoStateMachine").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StatePropertyName).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);

            entity.HasOne(d => d.StartStateNavigation).WithMany(p => p.X1_XpoStateMachine)
                .HasForeignKey(d => d.StartState)
                .HasConstraintName("FK_X1_XpoStateMachine_StartState");
        });

        modelBuilder.Entity<X1_XpoTrackingRecord>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoTrackingRecord").HasFillFactor(70);

            entity.Property(e => e.ActivityId).HasMaxLength(100);
            entity.Property(e => e.DateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<X1_XpoTransition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoTransition").HasFillFactor(70);

            entity.HasIndex(e => e.SourceState, "iSourceState_X1_XpoTransition").HasFillFactor(70);

            entity.HasIndex(e => e.TargetState, "iTargetState_X1_XpoTransition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Caption).HasMaxLength(100);

            entity.HasOne(d => d.SourceStateNavigation).WithMany(p => p.X1_XpoTransitionSourceStateNavigation)
                .HasForeignKey(d => d.SourceState)
                .HasConstraintName("FK_X1_XpoTransition_SourceState");

            entity.HasOne(d => d.TargetStateNavigation).WithMany(p => p.X1_XpoTransitionTargetStateNavigation)
                .HasForeignKey(d => d.TargetState)
                .HasConstraintName("FK_X1_XpoTransition_TargetState");
        });

        modelBuilder.Entity<X1_XpoUserActivityVersion>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoUserActivityVersion").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.WorkflowUniqueId).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_XpoWorkflowDefinition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoWorkflowDefinition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_XpoWorkflowInstance>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoWorkflowInstance").HasFillFactor(70);

            entity.Property(e => e.ExpirationDateTime).HasColumnType("datetime");
            entity.Property(e => e.Owner).HasMaxLength(100);
        });

        modelBuilder.Entity<X1_XpoWorkflowInstanceControlCommandRequest>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_X1_XpoWorkflowInstanceControlCommandRequest").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.TargetWorkflowUniqueId).HasMaxLength(100);
        });

        modelBuilder.Entity<XF_CustomAppearanceRule>(entity =>
        {
            entity.Property(e => e.CriteriaObjectType).HasMaxLength(1000);
            entity.Property(e => e.Method).HasMaxLength(100);
            entity.Property(e => e.TargetItems).HasMaxLength(100);
        });

        modelBuilder.Entity<XF_GuidWeakManyToMany>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_XF_GUİDWEAKMANYTOMANY");

            entity.HasIndex(e => new { e.LeftTypeId, e.LeftId }, "İLEFTTYPEIDLEFTID_XF_GUİDWEAKMANYTOMANY").HasFillFactor(70);

            entity.HasIndex(e => e.RelationName, "İRELATİONNAME_XF_GUİDWEAKMANYTOMANY").HasFillFactor(70);

            entity.HasIndex(e => new { e.RightTypeId, e.RightId }, "İRİGHTTYPEIDRİGHTID_XF_GUİDWEAKMANYTOMANY").HasFillFactor(70);

            entity.Property(e => e.RelationName).HasMaxLength(100);
        });

        modelBuilder.Entity<XF_XPObjectSet>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.CurrentUserName, "iCurrentUserName_XF_XPObjectSet").HasFillFactor(70);

            entity.HasIndex(e => e.GlobalContext, "iGlobalContext_XF_XPObjectSet").HasFillFactor(70);

            entity.HasIndex(e => e.LocalContext, "iLocalContext_XF_XPObjectSet").HasFillFactor(70);

            entity.HasIndex(e => e.OwnerId, "iOwnerId_XF_XPObjectSet").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Criteria).HasMaxLength(100);
            entity.Property(e => e.CurrentUserName).HasMaxLength(100);
            entity.Property(e => e.GlobalContext).HasMaxLength(100);
            entity.Property(e => e.LocalContext).HasMaxLength(100);
            entity.Property(e => e.ObjectsSelectableType).HasMaxLength(100);
            entity.Property(e => e.OwnerId).HasMaxLength(100);
        });

        modelBuilder.Entity<XF_XPObjectSetItem>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GuidKey, "iGuidKey_XF_XPObjectSetItem").HasFillFactor(70);

            entity.HasIndex(e => e.IntKey, "iIntKey_XF_XPObjectSetItem").HasFillFactor(70);

            entity.HasIndex(e => e.StringKey, "iStringKey_XF_XPObjectSetItem").HasFillFactor(70);

            entity.HasIndex(e => e.XPObjectSet, "iXPObjectSet_XF_XPObjectSetItem").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.StringKey).HasMaxLength(100);

            entity.HasOne(d => d.XPObjectSetNavigation).WithMany(p => p.XF_XPObjectSetItem)
                .HasForeignKey(d => d.XPObjectSet)
                .HasConstraintName("FK_XF_XPObjectSetItem_XPObjectSet");
        });

        modelBuilder.Entity<XF_XPWeakManyToMany>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_XF_XPWEAKMANYTOMANY");

            entity.HasIndex(e => new { e.LeftTargetType, e.LeftTargetKey }, "İLEFTTARGETTYPELEFTTARGETKEY_XF_XPWEAKMANYTOMANY").HasFillFactor(70);

            entity.HasIndex(e => e.RelationName, "İRELATİONNAME_XF_XPWEAKMANYTOMANY").HasFillFactor(70);

            entity.HasIndex(e => new { e.RightTargetType, e.RightTargetKey }, "İRİGHTTARGETTYPERİGHTTARGETKEY_XF_XPWEAKMANYTOMANY").HasFillFactor(70);

            entity.Property(e => e.LeftTargetKey).HasMaxLength(100);
            entity.Property(e => e.RelationName).HasMaxLength(100);
            entity.Property(e => e.RightTargetKey).HasMaxLength(100);
        });

        modelBuilder.Entity<XPWeakReference>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XPWeakReference").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_XPWeakReference").HasFillFactor(70);

            entity.HasIndex(e => e.TargetType, "iTargetType_XPWeakReference").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.TargetKey).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.XPWeakReferenceObjectTypeNavigation)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_XPWeakReference_ObjectType");

            entity.HasOne(d => d.TargetTypeNavigation).WithMany(p => p.XPWeakReferenceTargetTypeNavigation)
                .HasForeignKey(d => d.TargetType)
                .HasConstraintName("FK_XPWeakReference_TargetType");
        });

        modelBuilder.Entity<XP_AnonymousLoginOperationPermissionData>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.XP_AnonymousLoginOperationPermissionData)
                .HasForeignKey<XP_AnonymousLoginOperationPermissionData>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XP_AnonymousLoginOperationPermissionData_Oid");
        });

        modelBuilder.Entity<XP_DashboardDefinition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XP_DashboardDefinition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ChangedProperties).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<XP_Dashboard_Definitions_Roles>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => e.DashboardDefinitions, "iDashboardDefinitions_XP_Dashboard_Definitions_Roles").HasFillFactor(70);

            entity.HasIndex(e => new { e.Roles, e.DashboardDefinitions }, "iRolesDashboardDefinitions_XP_Dashboard_Definitions_Roles")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.Roles, "iRoles_XP_Dashboard_Definitions_Roles").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DashboardDefinitionsNavigation).WithMany(p => p.XP_Dashboard_Definitions_Roles)
                .HasForeignKey(d => d.DashboardDefinitions)
                .HasConstraintName("FK_XP_Dashboard_Definitions_Roles_DashboardDefinitions");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.XP_Dashboard_Definitions_Roles)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_XP_Dashboard_Definitions_Roles_Roles");
        });

        modelBuilder.Entity<XP_MyDetailsOperationPermissionData>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.XP_MyDetailsOperationPermissionData)
                .HasForeignKey<XP_MyDetailsOperationPermissionData>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XP_MyDetailsOperationPermissionData_Oid");
        });

        modelBuilder.Entity<XP_XpandPermissionData>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XP_XpandPermissionData").HasFillFactor(70);

            entity.HasIndex(e => e.ObjectType, "iObjectType_XP_XpandPermissionData").HasFillFactor(70);

            entity.HasIndex(e => e.Role, "iRole_XP_XpandPermissionData").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ChangedProperties).HasMaxLength(1);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.XP_XpandPermissionData)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_XP_XpandPermissionData_ObjectType");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.XP_XpandPermissionData)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_XP_XpandPermissionData_Role");
        });

        modelBuilder.Entity<XP_XpandUser>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Activation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);

            entity.HasOne(d => d.OidNavigation).WithOne(p => p.XP_XpandUser)
                .HasForeignKey<XP_XpandUser>(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XP_XpandUser_Oid");
        });

        modelBuilder.Entity<XpoState>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XpoState").HasFillFactor(70);

            entity.HasIndex(e => e.StateMachine, "iStateMachine_XpoState").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Caption).HasMaxLength(100);
            entity.Property(e => e.MarkerValue).HasMaxLength(100);

            entity.HasOne(d => d.StateMachineNavigation).WithMany(p => p.XpoState)
                .HasForeignKey(d => d.StateMachine)
                .HasConstraintName("FK_XpoState_StateMachine");
        });

        modelBuilder.Entity<XpoStateAppearance>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XpoStateAppearance").HasFillFactor(70);

            entity.HasIndex(e => e.State, "iState_XpoStateAppearance").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.AppearanceItemType).HasMaxLength(100);
            entity.Property(e => e.Context).HasMaxLength(100);
            entity.Property(e => e.Method).HasMaxLength(100);
            entity.Property(e => e.TargetItems).HasMaxLength(100);

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.XpoStateAppearance)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK_XpoStateAppearance_State");
        });

        modelBuilder.Entity<XpoStateMachine>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XpoStateMachine").HasFillFactor(70);

            entity.HasIndex(e => e.StartState, "iStartState_XpoStateMachine").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StatePropertyName).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);

            entity.HasOne(d => d.StartStateNavigation).WithMany(p => p.XpoStateMachine)
                .HasForeignKey(d => d.StartState)
                .HasConstraintName("FK_XpoStateMachine_StartState");
        });

        modelBuilder.Entity<XpoTransition>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_XpoTransition").HasFillFactor(70);

            entity.HasIndex(e => e.SourceState, "iSourceState_XpoTransition").HasFillFactor(70);

            entity.HasIndex(e => e.TargetState, "iTargetState_XpoTransition").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Caption).HasMaxLength(100);

            entity.HasOne(d => d.SourceStateNavigation).WithMany(p => p.XpoTransitionSourceStateNavigation)
                .HasForeignKey(d => d.SourceState)
                .HasConstraintName("FK_XpoTransition_SourceState");

            entity.HasOne(d => d.TargetStateNavigation).WithMany(p => p.XpoTransitionTargetStateNavigation)
                .HasForeignKey(d => d.TargetState)
                .HasConstraintName("FK_XpoTransition_TargetState");
        });

        modelBuilder.Entity<ZD_Copy_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ZD_COPY_FİELDS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ZD_COPY_FİELDS").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_ZD_COPY_FİELDS").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_ZD_COPY_FİELDS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SourceObjectType).HasMaxLength(100);
            entity.Property(e => e.SourceProperty).HasMaxLength(100);
            entity.Property(e => e.TargetObjectType).HasMaxLength(100);
            entity.Property(e => e.TargetProperty).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ZD_Copy_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ZD_COPY_FİELDS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ZD_Copy_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ZD_COPY_FİELDS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<ZD_Default_Values>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ZD_Default_Values").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ZD_Default_Values").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ZD_Default_Values").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.SourceClass).HasMaxLength(100);
            entity.Property(e => e.TargetChangeProperty).HasMaxLength(100);
            entity.Property(e => e.TargetClass).HasMaxLength(100);
            entity.Property(e => e.TargetProperty).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ZD_Default_Values_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ZD_Default_Values__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ZD_Default_Values_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ZD_Default_Values__LastModifiedBy");
        });

        modelBuilder.Entity<ZD_External_Link_Object>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ZD_EXTERNAL_LİNK_OBJECT");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ZD_EXTERNAL_LİNK_OBJECT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LinkId).HasMaxLength(100);
            entity.Property(e => e.MenuCaption).HasMaxLength(100);
            entity.Property(e => e.URL).HasMaxLength(100);
        });

        modelBuilder.Entity<ZD_External_Links>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_ZD_EXTERNAL_LİNKS");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_ZD_EXTERNAL_LİNKS").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "İ_CREATEDBY_ZD_EXTERNAL_LİNKS").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "İ_LASTMODİFİEDBY_ZD_EXTERNAL_LİNKS").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LinkId).HasMaxLength(100);
            entity.Property(e => e.MenuCaption).HasMaxLength(100);
            entity.Property(e => e.ParentId).HasMaxLength(100);
            entity.Property(e => e.URL).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ZD_External_Links_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ZD_EXTERNAL_LİNKS__CREATEDBY");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ZD_External_Links_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ZD_EXTERNAL_LİNKS__LASTMODİFİEDBY");
        });

        modelBuilder.Entity<ZD_Extra_Fields>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ZD_Extra_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ZD_Extra_Fields").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ZD_Extra_Fields").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.CheckedListSourceType).HasMaxLength(100);
            entity.Property(e => e.ExtraPropertyName).HasMaxLength(50);
            entity.Property(e => e.FieldCaption).HasMaxLength(100);
            entity.Property(e => e.FieldDisplayFormat).HasMaxLength(100);
            entity.Property(e => e.LayoutGroupId).HasMaxLength(100);
            entity.Property(e => e.LookupDataField).HasMaxLength(50);
            entity.Property(e => e.LookupDisplayField).HasMaxLength(50);
            entity.Property(e => e.TargetClass).HasMaxLength(150);
            entity.Property(e => e.TargetDataObjectType).HasMaxLength(100);
            entity.Property(e => e.TargetDataType).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ZD_Extra_Fields_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ZD_Extra_Fields__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ZD_Extra_Fields_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ZD_Extra_Fields__LastModifiedBy");
        });

        modelBuilder.Entity<ZD_Extra_Fields_Columns>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.ExtraFieldOid, "iExtraFieldOid_ZD_Extra_Fields_Columns").HasFillFactor(70);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ZD_Extra_Fields_Columns").HasFillFactor(70);

            entity.HasIndex(e => e._CreatedBy, "i_CreatedBy_ZD_Extra_Fields_Columns").HasFillFactor(70);

            entity.HasIndex(e => e._LastModifiedBy, "i_LastModifiedBy_ZD_Extra_Fields_Columns").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ColumnCaption).HasMaxLength(100);
            entity.Property(e => e.ColumnFieldName).HasMaxLength(100);
            entity.Property(e => e._CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e._LastModifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.ExtraFieldO).WithMany(p => p.ZD_Extra_Fields_Columns)
                .HasForeignKey(d => d.ExtraFieldOid)
                .HasConstraintName("FK_ZD_Extra_Fields_Columns_ExtraFieldOid");

            entity.HasOne(d => d._CreatedByNavigation).WithMany(p => p.ZD_Extra_Fields_Columns_CreatedByNavigation)
                .HasForeignKey(d => d._CreatedBy)
                .HasConstraintName("FK_ZD_Extra_Fields_Columns__CreatedBy");

            entity.HasOne(d => d._LastModifiedByNavigation).WithMany(p => p.ZD_Extra_Fields_Columns_LastModifiedByNavigation)
                .HasForeignKey(d => d._LastModifiedBy)
                .HasConstraintName("FK_ZD_Extra_Fields_Columns__LastModifiedBy");
        });

        modelBuilder.Entity<ZD_Search_Extensions>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_ZD_Search_Extensions").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ItemProperty).HasMaxLength(100);
            entity.Property(e => e.ItemSubProperty).HasMaxLength(100);
            entity.Property(e => e.TargetType).HasMaxLength(100);
        });

        modelBuilder.Entity<foProductSelectionItem>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_foProductSelectionItem").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e._Code).HasMaxLength(100);
            entity.Property(e => e._Description).HasMaxLength(100);
        });

        modelBuilder.Entity<foProductSelectionList>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.GCRecord, "iGCRecord_foProductSelectionList").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
        });

        modelBuilder.Entity<foProductVariant>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_FOPRODUCTVARİANT");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_FOPRODUCTVARİANT").HasFillFactor(70);

            entity.HasIndex(e => e.Product, "İPRODUCT_FOPRODUCTVARİANT").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ProductCode).HasMaxLength(100);
            entity.Property(e => e.ProductDescription).HasMaxLength(100);

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.foProductVariant)
                .HasForeignKey(d => d.Product)
                .HasConstraintName("FK_FOPRODUCTVARİANT_PRODUCT");
        });

        modelBuilder.Entity<foProductVariantItem>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK_FOPRODUCTVARİANTITEM");

            entity.HasIndex(e => e.GCRecord, "İGCRECORD_FOPRODUCTVARİANTITEM").HasFillFactor(70);

            entity.HasIndex(e => e.Unit, "İUNİT_FOPRODUCTVARİANTITEM").HasFillFactor(70);

            entity.HasIndex(e => e.Variant, "İVARİANT_FOPRODUCTVARİANTITEM").HasFillFactor(70);

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.VariantCode).HasMaxLength(50);
            entity.Property(e => e.VariantDescription).HasMaxLength(300);
            entity.Property(e => e.VariantDescription2).HasMaxLength(300);

            entity.HasOne(d => d.UnitNavigation).WithMany(p => p.foProductVariantItem)
                .HasForeignKey(d => d.Unit)
                .HasConstraintName("FK_FOPRODUCTVARİANTITEM_UNİT");

            entity.HasOne(d => d.VariantNavigation).WithMany(p => p.foProductVariantItem)
                .HasForeignKey(d => d.Variant)
                .HasConstraintName("FK_FOPRODUCTVARİANTITEM_VARİANT");
        });

        modelBuilder.Entity<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions>(entity =>
        {
            entity.HasKey(e => e.OID).HasName("PK_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS");

            entity.HasIndex(e => e.DashboardDefinitions, "İDASHBOARDDEFİNİTİONS_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS").HasFillFactor(70);

            entity.HasIndex(e => new { e.Roles, e.DashboardDefinitions }, "İROLESDASHBOARDDEFİNİTİONS_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS")
                .IsUnique()
                .HasFillFactor(70);

            entity.HasIndex(e => e.Roles, "İROLES_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS").HasFillFactor(70);

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.DashboardDefinitionsNavigation).WithMany(p => p.logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions)
                .HasForeignKey(d => d.DashboardDefinitions)
                .HasConstraintName("FK_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS_DASHBOARDDEFİNİTİONS");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_LOGOCRM_NET_MODULE_BUSİNESSOBJECTS_CODES_CT_ROLEDASHBOARDDEFİNİTİONDASHBOARDDEFİNİTİONS_ROLES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder
    //        .UseLazyLoadingProxies();


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.laz
    //    base.OnConfiguring(optionsBuilder);
    //}
}

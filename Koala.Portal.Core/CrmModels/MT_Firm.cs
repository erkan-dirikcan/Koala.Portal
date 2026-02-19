namespace Koala.Portal.Core.CrmModels;

public partial class MT_Firm
{
    public Guid Oid { get; set; }

    public string? FirmCode { get; set; }

    public string? FirmTitle { get; set; }

    public bool? InUse { get; set; }

    public bool? IsPersonCompany { get; set; }

    public string? PersonId { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNo { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? EmailAddress3 { get; set; }

    public string? WebAddress1 { get; set; }

    public string? WebAddress2 { get; set; }

    public Guid? Networks_ { get; set; }

    public Guid? ParentFirm { get; set; }

    public double? Latitude { get; set; }

    public double? Longtitude { get; set; }

    public Guid? SalesRep { get; set; }

    public Guid? MainSector { get; set; }

    public Guid? SubSector { get; set; }

    public Guid? FirmRole { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? FirmCategory01 { get; set; }

    public Guid? FirmCategory02 { get; set; }

    public Guid? FirmCategory03 { get; set; }

    public Guid? FirmCategory04 { get; set; }

    public Guid? FirmCategory05 { get; set; }

    public Guid? ReferenceSource { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ARPUsesInSales { get; set; }

    public string? ARPUsesInPurchase { get; set; }

    public string? ARPDeliveryType { get; set; }

    public string? ARPTradingGroup { get; set; }

    public string? ARPAuthCode { get; set; }

    public string? ARPUsesInFinance { get; set; }

    public string? Auxiliary_Code5 { get; set; }

    public string? Auxiliary_Code1 { get; set; }

    public string? ARPUsesInImports { get; set; }

    public string? ARPPaymentPlan { get; set; }

    public string? ARPAccountType { get; set; }

    public string? ARPUsesInExports { get; set; }

    public string? Auxiliary_Code3 { get; set; }

    public string? Auxiliary_Code2 { get; set; }

    public string? Auxiliary_Code4 { get; set; }

    public byte[]? FirmLogo { get; set; }

    public string? CityOfMainAddress { get; set; }

    public string? MainAddress { get; set; }

    public string? Phones { get; set; }

    public bool? IsRoutineVisit { get; set; }

    public int? VisitFrequency { get; set; }

    public string? ARPShippingAgent { get; set; }

    public bool? FirmLogoBakimAnlasmasi { get; set; }

    public DateTime? FirmLogoBakimBaslangicTarihi { get; set; }

    public DateTime? FirmLogoBakimBitisTarihi { get; set; }

    public bool? FirmTeknikBakimAnlasmasi { get; set; }

    public DateTime? FirmTeknikBakimBaslangicTarihi { get; set; }

    public DateTime? FirmTeknikBakimBitisTarihi { get; set; }

    public string? CountryOfMainAddress { get; set; }

    public string? FirmRiskOrderProp { get; set; }

    public string? FirmRiskMyCs { get; set; }

    public string? FirmRiskOrder { get; set; }

    public string? FirmRiskDispatch { get; set; }

    public string? FirmRiskAcc { get; set; }

    public string? FirmRiskCustomerCs { get; set; }

    public string? FirmRiskCiroCs { get; set; }

    public string? FirmRiskDispatchProp { get; set; }

    public string? CountyOfMainAddress { get; set; }

    public string? DistrictOfMainAddress { get; set; }

    public string? ParishOfMainAddress { get; set; }

    public string? _MusteriTipi { get; set; }

    public bool? FirmYeniDonanimBakimAnlasmasi { get; set; }

    public DateTime? FirmYeniDonanimBakimBaslangicTarihi { get; set; }

    public DateTime? FirmYeniDonanimBakimBitisTarihi { get; set; }

    public bool? FirmYeniLogoBakimAnlasmasi { get; set; }

    public DateTime? FirmYeniLogoBakimBaslangicTarihi { get; set; }

    public DateTime? FirmYeniLogoBakimBitisTarihi { get; set; }

    public string? ApiSKey { get; set; }

    public string? ApiBaseAddress { get; set; }

    public virtual ICollection<AA_CompetitorManagement_Opportunity> AA_CompetitorManagement_Opportunity { get; set; } = new List<AA_CompetitorManagement_Opportunity>();

    public virtual ICollection<AA_CompetitorManagement_Proposals> AA_CompetitorManagement_Proposals { get; set; } = new List<AA_CompetitorManagement_Proposals>();

    public virtual ICollection<AA_Email_Report> AA_Email_Report { get; set; } = new List<AA_Email_Report>();

    public virtual ICollection<AA_GoogleMaps_GeoPoint> AA_GoogleMaps_GeoPoint { get; set; } = new List<AA_GoogleMaps_GeoPoint>();

    public virtual ICollection<AA_Sms_Report> AA_Sms_Report { get; set; } = new List<AA_Sms_Report>();

    public virtual ICollection<EI_Firm_Relations> EI_Firm_Relations { get; set; } = new List<EI_Firm_Relations>();

    public virtual ICollection<EX_Firm_Applications> EX_Firm_Applications { get; set; } = new List<EX_Firm_Applications>();

    public virtual ICollection<EX_Firm_Applications_payment> EX_Firm_Applications_payment { get; set; } = new List<EX_Firm_Applications_payment>();

    public virtual ICollection<EX_Firm_SecretKey> EX_Firm_SecretKey { get; set; } = new List<EX_Firm_SecretKey>();

    public virtual GK_Firm_Category01? FirmCategory01Navigation { get; set; }

    public virtual GK_Firm_Category02? FirmCategory02Navigation { get; set; }

    public virtual GK_Firm_Category03? FirmCategory03Navigation { get; set; }

    public virtual GK_Firm_Category04? FirmCategory04Navigation { get; set; }

    public virtual GK_Firm_Category05? FirmCategory05Navigation { get; set; }

    public virtual CT_Firm_Roles? FirmRoleNavigation { get; set; }

    public virtual ICollection<MT_Firm> InverseParentFirmNavigation { get; set; } = new List<MT_Firm>();

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Campaign_Lists> MT_Campaign_Lists { get; set; } = new List<MT_Campaign_Lists>();

    public virtual ICollection<MT_Contact> MT_Contact { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Notifications> MT_Notifications { get; set; } = new List<MT_Notifications>();

    public virtual ICollection<MT_Opportunity> MT_OpportunityOpportunityFirmNavigation { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Opportunity> MT_OpportunityWinningCompetitorNavigation { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals> MT_ProposalsERPShipmentAccountNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals> MT_ProposalsProposalFirmNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals> MT_ProposalsWinningCompetitorNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsERPShipmentAccountNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsProposalFirmNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsWinningCompetitorNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsERPShipmentAccountNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsProposalFirmNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsWinningCompetitorNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Task> MT_Task { get; set; } = new List<MT_Task>();

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual CT_Sectors? MainSectorNavigation { get; set; }

    public virtual PO_Social_Media? Networks_Navigation { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_Phone_Number> PO_Phone_Number { get; set; } = new List<PO_Phone_Number>();

    public virtual MT_Firm? ParentFirmNavigation { get; set; }

    public virtual ICollection<RI_Firm_Product> RI_Firm_Product { get; set; } = new List<RI_Firm_Product>();

    public virtual ICollection<RL_Document_Firm> RL_Document_Firm { get; set; } = new List<RL_Document_Firm>();

    public virtual ICollection<RL_Event_Firm> RL_Event_Firm { get; set; } = new List<RL_Event_Firm>();

    public virtual ICollection<RL_Firm_Actions_Lists> RL_Firm_Actions_Lists { get; set; } = new List<RL_Firm_Actions_Lists>();

    public virtual ICollection<RL_Firm_Contacts> RL_Firm_Contacts { get; set; } = new List<RL_Firm_Contacts>();

    public virtual ICollection<RL_Firm_List_Types> RL_Firm_List_Types { get; set; } = new List<RL_Firm_List_Types>();

    public virtual ICollection<RL_Firm_Sectors> RL_Firm_Sectors { get; set; } = new List<RL_Firm_Sectors>();

    public virtual ICollection<RL_Mail_Firm> RL_Mail_Firm { get; set; } = new List<RL_Mail_Firm>();

    public virtual ICollection<RL_Notes_Firm> RL_Notes_Firm { get; set; } = new List<RL_Notes_Firm>();

    public virtual ICollection<RL_Product_Firm> RL_Product_Firm { get; set; } = new List<RL_Product_Firm>();

    public virtual ICollection<RL_Proposal_OtherFirms> RL_Proposal_OtherFirms { get; set; } = new List<RL_Proposal_OtherFirms>();

    public virtual CT_Reference_Sources? ReferenceSourceNavigation { get; set; }

    public virtual ICollection<ST_Activity_Planning> ST_Activity_Planning { get; set; } = new List<ST_Activity_Planning>();

    public virtual ICollection<ST_IPS_Logs> ST_IPS_Logs { get; set; } = new List<ST_IPS_Logs>();

    public virtual CT_Sales_Rep? SalesRepNavigation { get; set; }

    public virtual CT_Sub_Sectors? SubSectorNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

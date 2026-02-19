namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals
{
    public Guid Oid { get; set; }

    public string? ActiveRevisalId { get; set; }

    public double? ProposalId { get; set; }

    public int? Alternative { get; set; }

    public string? ProposalDescription { get; set; }

    public Guid? ProposalFirm { get; set; }

    public Guid? ProposalContact { get; set; }

    public Guid? SalesRep { get; set; }

    public int? Priority { get; set; }

    public Guid? ProposalStage { get; set; }

    public int? ProposalState { get; set; }

    public DateTime? ProposalStartDate { get; set; }

    public DateTime? ProposalEstEndDate { get; set; }

    public Guid? ProposalCurrency { get; set; }

    public double? ProposalExchangeRate { get; set; }

    public string? Notes { get; set; }

    public Guid? Campaign { get; set; }

    public int? ExchangeRateType { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? Incoterm { get; set; }

    public double? Total_Amount { get; set; }

    public double? Total_LC_Price { get; set; }

    public double? Total_LC_PriceDiscounted { get; set; }

    public double? Total_LC_SubTotal { get; set; }

    public double? Total_LC_DiscountTotal { get; set; }

    public double? Total_LC_VATTotal { get; set; }

    public double? Total_LC_CommTAXTotal { get; set; }

    public double? Total_LC_GrandTotal { get; set; }

    public double? Total_PC_Price { get; set; }

    public double? Total_PC_PriceDiscounted { get; set; }

    public double? Total_PC_SubTotal { get; set; }

    public double? Total_PC_DiscountTotal { get; set; }

    public double? Total_PC_VATTotal { get; set; }

    public double? Total_PC_CommTAXTotal { get; set; }

    public double? Total_PC_GrandTotal { get; set; }

    public int? LastApprovalState { get; set; }

    public Guid? LastApprovalStateBy { get; set; }

    public DateTime? LastApprovalStateDate { get; set; }

    public Guid? LastApprovalWaitingOn { get; set; }

    public Guid? LastApprovalGivenBy { get; set; }

    public bool? IsContract { get; set; }

    public Guid? ContractType { get; set; }

    public bool? IsContractRenewal { get; set; }

    public DateTime? ContractStartDate { get; set; }

    public DateTime? ContractEndDate { get; set; }

    public DateTime? ContractSignedDate { get; set; }

    public Guid? ContractState { get; set; }

    public Guid? ShipmentAddress { get; set; }

    public string? ShipmentAddressCode { get; set; }

    public Guid? InvoiceAddress { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public Guid? RelatedOpportunityOid { get; set; }

    public Guid? TicketOid { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ERPWarehouse { get; set; }

    public string? ERPAuxCode_Dispatch { get; set; }

    public string? ERPTransactionCurrency_Transferred { get; set; }

    public string? ERPDescriptionLines2 { get; set; }

    public string? ERPDeliveryType { get; set; }

    public string? ERPPaymentPlan { get; set; }

    public string? ERPDescriptionLines3 { get; set; }

    public string? ERPAuthCode_Order { get; set; }

    public string? ERPAuthCode_Dispatch { get; set; }

    public string? ERPDescriptionLines1 { get; set; }

    public string? ERPOrderConfirmationStatus { get; set; }

    public string? ERPDocumentTrackingNumber { get; set; }

    public string? ERPShippingAgent { get; set; }

    public string? ERPCurrencyType_General { get; set; }

    public string? ERPDispatchType { get; set; }

    public string? ERPPricingCurrency_Transferred { get; set; }

    public string? ERPProjectCode { get; set; }

    public string? ERPDocumentNumber { get; set; }

    public string? ERPAuxCode_Order { get; set; }

    public string? ERPAffectsRisk { get; set; }

    public string? ERPTransactionCurrency { get; set; }

    public string? ERPCurrencyType_Lines { get; set; }

    public string? ERPDescriptionLines4 { get; set; }

    public string? ERPTradingGroup { get; set; }

    public string? ERPPrePayment { get; set; }

    public string? proposal_contract_urun { get; set; }

    public Guid? ProposalGroup { get; set; }

    public Guid? ProposalType { get; set; }

    public double? Total_LC_Surcharge { get; set; }

    public double? Total_PC_Surcharge { get; set; }

    public Guid? IntegrationSet { get; set; }

    public string? ERP_Division { get; set; }

    public DateTime? ProposalStateDate { get; set; }

    public bool? DiscountAmountIsByTotal { get; set; }

    public bool? CategoryVisible { get; set; }

    public string? LastApprovalWaitingOnAlternatives { get; set; }

    public int? LastApprovalOrderNumber { get; set; }

    public Guid? ERPShipmentAccount { get; set; }

    public double? Total_LC_TotalDiscountPercent { get; set; }

    public double? Total_PC_TotalDiscountPercent { get; set; }

    public int? RecordType { get; set; }

    public double? Total_LC_PromotionTotal { get; set; }

    public double? Total_LC_DiscountLineTotal { get; set; }

    public double? Total_PC_PromotionTotal { get; set; }

    public double? Total_PC_DiscountLineTotal { get; set; }

    public Guid? WinningCompetitor { get; set; }

    public double? WinningTotal { get; set; }

    public bool? cmo_ChartVisible { get; set; }

    public Guid? WinLoseReason { get; set; }

    public bool? CampaignApplied { get; set; }

    public double? Total_LC_SpecialConsumptionTaxTotal { get; set; }

    public double? Total_PC_SpecialConsumptionTaxTotal { get; set; }

    public string? ERP_Department { get; set; }

    public string? ERP_Factory { get; set; }

    public double? Total_LC_GiftDiscount { get; set; }

    public double? Total_PC_GiftDiscount { get; set; }

    public bool? DeleteProductsWhenCategoryDeleted { get; set; }

    public bool? UpdateProductLinesSalesPersonInfo { get; set; }

    public string? ERPReportingCurrencyDate { get; set; }

    public string? ERPPricingExchangeRate_Transferred { get; set; }

    public bool? RequestFromTicket { get; set; }

    public string? ERPRiskControl { get; set; }

    public string? ITEXT { get; set; }

    public string? ERPDispatchConfirmationStatus { get; set; }

    public double? Total_LC_AddCostTotal { get; set; }

    public double? Total_PC_AddCostTotal { get; set; }

    public Guid? AdditionalCost { get; set; }

    public bool? ApplyAddCost { get; set; }

    public string? Total_LC_GrandTotal_String { get; set; }

    public string? Total_PC_GrandTotal_String { get; set; }

    public double? Average_VAT_Rate { get; set; }

    public double? Total_LC_VATAmount_WithoutSurcharge { get; set; }

    public double? Total_PC_VATAmount_WithoutSurcharge { get; set; }

    public double? Total_LC_GlobalSurcharge_VATAmount { get; set; }

    public double? Total_PC_GlobalSurcharge_VATAmount { get; set; }

    public double? Total_LC_Surcharge_VATAmount { get; set; }

    public double? Total_PC_Surcharge_VATAmount { get; set; }

    public double? Total_LC_GrandTotal_BeforeNetDiscount { get; set; }

    public double? Total_PC_GrandTotal_BeforeNetDiscount { get; set; }

    public bool? IsProposalDate { get; set; }

    public string? ERPTransactionCurrency_Transfer { get; set; }

    public string? TypeOf_ERPTransactionCurrency_Transfer { get; set; }

    public double? ERPTransactionCurrencyRate { get; set; }

    public virtual ICollection<AA_CompetitorManagement_Proposals> AA_CompetitorManagement_Proposals { get; set; } = new List<AA_CompetitorManagement_Proposals>();

    public virtual MT_Proposals_Additional_Cost? AdditionalCostNavigation { get; set; }

    public virtual MT_Campaign? CampaignNavigation { get; set; }

    public virtual CT_Contract_States? ContractStateNavigation { get; set; }

    public virtual CT_Contract_Types? ContractTypeNavigation { get; set; }

    public virtual ICollection<EI_Proposal_Relations> EI_Proposal_Relations { get; set; } = new List<EI_Proposal_Relations>();

    public virtual MT_Firm? ERPShipmentAccountNavigation { get; set; }

    public virtual CT_Incoterm? IncotermNavigation { get; set; }

    public virtual EI_Integration_Sets? IntegrationSetNavigation { get; set; }

    public virtual PO_Address? InvoiceAddressNavigation { get; set; }

    public virtual ST_User? LastApprovalGivenByNavigation { get; set; }

    public virtual ST_User? LastApprovalStateByNavigation { get; set; }

    public virtual ST_User? LastApprovalWaitingOnNavigation { get; set; }

    public virtual ICollection<MT_Proposals_Additional_Cost> MT_Proposals_Additional_Cost { get; set; } = new List<MT_Proposals_Additional_Cost>();

    public virtual ICollection<MT_Proposals_Approvals> MT_Proposals_Approvals { get; set; } = new List<MT_Proposals_Approvals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_History> MT_Proposals_History { get; set; } = new List<MT_Proposals_History>();

    public virtual ICollection<MT_Proposals_Prepared_Forms> MT_Proposals_Prepared_Forms { get; set; } = new List<MT_Proposals_Prepared_Forms>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual MT_Contact? ProposalContactNavigation { get; set; }

    public virtual CT_Currency_Types? ProposalCurrencyNavigation { get; set; }

    public virtual MT_Firm? ProposalFirmNavigation { get; set; }

    public virtual CT_Proposal_Groups? ProposalGroupNavigation { get; set; }

    public virtual CT_Proposal_Stages? ProposalStageNavigation { get; set; }

    public virtual CT_Proposal_Types? ProposalTypeNavigation { get; set; }

    public virtual ICollection<RL_Event_Proposal> RL_Event_Proposal { get; set; } = new List<RL_Event_Proposal>();

    public virtual ICollection<RL_Mail_Proposal> RL_Mail_Proposal { get; set; } = new List<RL_Mail_Proposal>();

    public virtual ICollection<RL_Proposal_Activity> RL_Proposal_Activity { get; set; } = new List<RL_Proposal_Activity>();

    public virtual ICollection<RL_Proposal_OtherFirms> RL_Proposal_OtherFirms { get; set; } = new List<RL_Proposal_OtherFirms>();

    public virtual ICollection<RL_Proposal_Task> RL_Proposal_Task { get; set; } = new List<RL_Proposal_Task>();

    public virtual ICollection<RL_Proposals_Documents> RL_Proposals_Documents { get; set; } = new List<RL_Proposals_Documents>();

    public virtual ICollection<RL_Ticket_Proposal> RL_Ticket_Proposal { get; set; } = new List<RL_Ticket_Proposal>();

    public virtual MT_Opportunity? RelatedOpportunityO { get; set; }

    public virtual ICollection<ST_Proposal_Category> ST_Proposal_Category { get; set; } = new List<ST_Proposal_Category>();

    public virtual CT_Sales_Rep? SalesRepNavigation { get; set; }

    public virtual PO_Address? ShipmentAddressNavigation { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }

    public virtual AA_CompetitorManagement_Reason? WinLoseReasonNavigation { get; set; }

    public virtual MT_Firm? WinningCompetitorNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

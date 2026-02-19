namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_Products_Approvals_Details
{
    public Guid Oid { get; set; }

    public Guid? RelatedProposal { get; set; }

    public Guid? ProposalProductOid { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public Guid? ImagePath { get; set; }

    public string? ImagePathName { get; set; }

    public double? LineNo { get; set; }

    public int? LineType { get; set; }

    public Guid? ProductOid { get; set; }

    public string? ProductExtDescription { get; set; }

    public int? Alternative { get; set; }

    public bool? IsMainProduct { get; set; }

    public bool? IsOptional { get; set; }

    public Guid? Unit { get; set; }

    public Guid? Currency { get; set; }

    public double? ExchangeRate { get; set; }

    public double? Amount { get; set; }

    public double? Price { get; set; }

    public double? NoAddCostPrice { get; set; }

    public double? VAT { get; set; }

    public bool? VATIncluded { get; set; }

    public double? CommTAX { get; set; }

    public double? GiftDiscount { get; set; }

    public double? SpecialConsumptionTax { get; set; }

    public int? SctAddTaxAmntIsUpd { get; set; }

    public bool? RecalculateSCT { get; set; }

    public bool? ReadPrice { get; set; }

    public double? Discount1Percent { get; set; }

    public double? Discount1Amount { get; set; }

    public double? Discount2Percent { get; set; }

    public double? Discount2Amount { get; set; }

    public double? Discount3Percent { get; set; }

    public double? Discount3Amount { get; set; }

    public double? Discount4Percent { get; set; }

    public double? Discount4Amount { get; set; }

    public double? Discount5Percent { get; set; }

    public double? Discount5Amount { get; set; }

    public double? Discount6Percent { get; set; }

    public double? Discount6Amount { get; set; }

    public double? PriceDiscounted { get; set; }

    public double? SubTotal { get; set; }

    public double? VATValue { get; set; }

    public double? DiscountTotal { get; set; }

    public double? CommTAXValue { get; set; }

    public double? GrandTotal { get; set; }

    public double? LC_Price { get; set; }

    public double? LC_AddCostAmount { get; set; }

    public double? LC_PriceDiscounted { get; set; }

    public double? LC_SpecialConsumptionTax { get; set; }

    public double? LC_GiftDiscount { get; set; }

    public double? LC_SubTotal { get; set; }

    public double? LC_DiscountTotal { get; set; }

    public double? LC_VatValue { get; set; }

    public double? LC_CommTAXValue { get; set; }

    public double? LC_GrandTotal { get; set; }

    public Guid? ProposalCurrency { get; set; }

    public Guid? PriceType { get; set; }

    public double? ProposalExchangeRate { get; set; }

    public double? PC_Price { get; set; }

    public double? PC_AddCostAmount { get; set; }

    public double? PC_PriceDiscounted { get; set; }

    public double? PC_SpecialConsumptionTax { get; set; }

    public double? PC_GiftDiscount { get; set; }

    public double? PC_SubTotal { get; set; }

    public double? PC_DiscountTotal { get; set; }

    public double? PC_VatValue { get; set; }

    public double? PC_CommTAXValue { get; set; }

    public double? PC_GrandTotal { get; set; }

    public double? AddCostAmount { get; set; }

    public bool? ApplyAddCost { get; set; }

    public string? Notes { get; set; }

    public Guid? RelatedRevisal { get; set; }

    public double? UnitConversionFactorMultiply { get; set; }

    public double? UnitConversionFactorDivide { get; set; }

    public Guid? RelatedLine { get; set; }

    public Guid? PromotionRelationOid { get; set; }

    public int? CampaignLineType { get; set; }

    public Guid? Category { get; set; }

    public bool? BasedOnPercent { get; set; }

    public double? RealPrice { get; set; }

    public double? LC_RealPrice { get; set; }

    public double? PC_RealPrice { get; set; }

    public bool? PriceNotReadBasedOnUnit { get; set; }

    public string? ERPCampCode1 { get; set; }

    public string? ERPCampCode2 { get; set; }

    public string? ERPCampCode3 { get; set; }

    public string? ERPCampCode4 { get; set; }

    public string? ERPCampCode5 { get; set; }

    public string? ERPCampCode6 { get; set; }

    public string? ERPPCampCode { get; set; }

    public string? ERPCampLnNo { get; set; }

    public string? ERPCAMPDetailLevel { get; set; }

    public bool? CampaignApplied_Discount1 { get; set; }

    public bool? CampaignApplied_Discount2 { get; set; }

    public bool? CampaignApplied_Discount3 { get; set; }

    public bool? CampaignApplied_Discount4 { get; set; }

    public bool? CampaignApplied_Discount5 { get; set; }

    public bool? CampaignApplied_Discount6 { get; set; }

    public bool? IsARPDiscount { get; set; }

    public bool? IsReadERPPrice { get; set; }

    public string? VariantCode { get; set; }

    public string? VariantName { get; set; }

    public string? VariantDescription { get; set; }

    public string? VariantRef { get; set; }

    public string? VariantCanConfig { get; set; }

    public double? _specialConsumptionTax { get; set; }

    public string? _OzelBirim { get; set; }

    public DateTime? ERPReserveDate { get; set; }

    public DateTime? ERPOrderDueDate { get; set; }

    public string? ERPWarehouse { get; set; }

    public string? ERPReserved { get; set; }

    public string? ERPAuxCode_Dispatch { get; set; }

    public string? ERPLineDescription { get; set; }

    public string? ERPSalesman { get; set; }

    public string? ERPProjectCode { get; set; }

    public string? ERPAuxCode_Order { get; set; }

    public string? ERPAuxCode_Dispatch2 { get; set; }

    public double? LineErpWeight { get; set; }

    public string? _DummyAciklama { get; set; }

    public int? DiscountLineType { get; set; }

    public double? AssumedVATRate { get; set; }

    public virtual ST_Proposal_Category? CategoryNavigation { get; set; }

    public virtual CT_Currency_Types? CurrencyNavigation { get; set; }

    public virtual PO_FilePath? ImagePathNavigation { get; set; }

    public virtual CT_Price_Types? PriceTypeNavigation { get; set; }

    public virtual MT_Product? ProductO { get; set; }

    public virtual CT_Currency_Types? ProposalCurrencyNavigation { get; set; }

    public virtual MT_Proposals_Products? ProposalProductO { get; set; }

    public virtual MT_Proposals_Approvals_Details? RelatedProposalNavigation { get; set; }

    public virtual MT_Proposals_Revisals? RelatedRevisalNavigation { get; set; }

    public virtual CT_Units? UnitNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

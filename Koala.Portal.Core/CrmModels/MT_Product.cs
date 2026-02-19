namespace Koala.Portal.Core.CrmModels;

public partial class MT_Product
{
    public Guid Oid { get; set; }

    public string? ProductCode { get; set; }

    public string? Description { get; set; }

    public string? ProducerCode { get; set; }

    public string? Barcode { get; set; }

    public Guid? ProductUnitSet { get; set; }

    public Guid? GroupCode { get; set; }

    public int? ProductType { get; set; }

    public int? MainStatus { get; set; }

    public Guid? Class { get; set; }

    public double? SellVAT { get; set; }

    public double? CommTAX { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? ProductCategory01 { get; set; }

    public Guid? ProductCategory02 { get; set; }

    public Guid? ProductCategory03 { get; set; }

    public Guid? ProductCategory04 { get; set; }

    public Guid? ProductCategory05 { get; set; }

    public string? DescInTurkish { get; set; }

    public string? DescInEnglish { get; set; }

    public string? DescInFrench { get; set; }

    public string? DescInChinese { get; set; }

    public string? DescInGerman { get; set; }

    public string? DescInItalian { get; set; }

    public string? DescInJapanese { get; set; }

    public string? DescInRussian { get; set; }

    public string? DescInSpanish { get; set; }

    public byte[]? Image01 { get; set; }

    public byte[]? Image02 { get; set; }

    public byte[]? Image03 { get; set; }

    public byte[]? Image04 { get; set; }

    public byte[]? Image05 { get; set; }

    public byte[]? Image06 { get; set; }

    public byte[]? Image07 { get; set; }

    public byte[]? Image08 { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? Auxiliary_Code2 { get; set; }

    public string? ERPPaymentPlan { get; set; }

    public string? Auxiliary_Code4 { get; set; }

    public string? ARPUsesInSales { get; set; }

    public string? ERPGroupCode { get; set; }

    public string? Auxiliary_Code1 { get; set; }

    public string? ARPUsesInMM { get; set; }

    public string? Auxiliary_Code5 { get; set; }

    public string? ERPAuthCode { get; set; }

    public string? ARPUsesInPurchase { get; set; }

    public string? Auxiliary_Code3 { get; set; }

    public string? DescInArabic { get; set; }

    public string? ERPDescription2 { get; set; }

    public string? HasVariants { get; set; }

    public string? ITEXTENG { get; set; }

    public string? ITEXT { get; set; }

    public string? _DetayBilgi { get; set; }

    public bool? IsWarranty { get; set; }

    public int? WarrantyInterval { get; set; }

    public int? WarrantyPeriod { get; set; }

    public int? WarrantyBeginningType { get; set; }

    public double? _EN { get; set; }

    public virtual CT_Product_Classes? ClassNavigation { get; set; }

    public virtual ICollection<EI_Product_Relations> EI_Product_Relations { get; set; } = new List<EI_Product_Relations>();

    public virtual CT_Product_Groups? GroupCodeNavigation { get; set; }

    public virtual ICollection<MT_Product_Prices> MT_Product_Prices { get; set; } = new List<MT_Product_Prices>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual GK_Product_Category01? ProductCategory01Navigation { get; set; }

    public virtual GK_Product_Category02? ProductCategory02Navigation { get; set; }

    public virtual GK_Product_Category03? ProductCategory03Navigation { get; set; }

    public virtual GK_Product_Category04? ProductCategory04Navigation { get; set; }

    public virtual GK_Product_Category05? ProductCategory05Navigation { get; set; }

    public virtual CT_Units_Collections? ProductUnitSetNavigation { get; set; }

    public virtual ICollection<RI_Activity_Product> RI_Activity_Product { get; set; } = new List<RI_Activity_Product>();

    public virtual ICollection<RI_Contact_Product> RI_Contact_Product { get; set; } = new List<RI_Contact_Product>();

    public virtual ICollection<RI_Event_Product> RI_Event_Product { get; set; } = new List<RI_Event_Product>();

    public virtual ICollection<RI_Firm_Product> RI_Firm_Product { get; set; } = new List<RI_Firm_Product>();

    public virtual ICollection<RI_Opportunity_Product> RI_Opportunity_Product { get; set; } = new List<RI_Opportunity_Product>();

    public virtual ICollection<RI_Product_Units_Collections_Properties> RI_Product_Units_Collections_Properties { get; set; } = new List<RI_Product_Units_Collections_Properties>();

    public virtual ICollection<RI_Ticket_Product> RI_Ticket_Product { get; set; } = new List<RI_Ticket_Product>();

    public virtual ICollection<RL_Campaign_Product> RL_Campaign_Product { get; set; } = new List<RL_Campaign_Product>();

    public virtual ICollection<RL_Document_Product> RL_Document_Product { get; set; } = new List<RL_Document_Product>();

    public virtual ICollection<RL_Product_Activity> RL_Product_Activity { get; set; } = new List<RL_Product_Activity>();

    public virtual ICollection<RL_Product_Event> RL_Product_Event { get; set; } = new List<RL_Product_Event>();

    public virtual ICollection<RL_Product_Firm> RL_Product_Firm { get; set; } = new List<RL_Product_Firm>();

    public virtual ICollection<RL_Product_Opportunity> RL_Product_Opportunity { get; set; } = new List<RL_Product_Opportunity>();

    public virtual ICollection<RL_Product_Ticket> RL_Product_Ticket { get; set; } = new List<RL_Product_Ticket>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }

    public virtual ICollection<foProductVariant> foProductVariant { get; set; } = new List<foProductVariant>();
}

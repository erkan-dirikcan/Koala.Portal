namespace Koala.Portal.Core.CrmModels;

public partial class EI_Integration_Sets
{
    public Guid Oid { get; set; }

    public string? SetDescription { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDefault { get; set; }

    public bool? ForAllUsers { get; set; }

    public int? ERPApplication { get; set; }

    public string? ServiceLink { get; set; }

    public string? ERPWebServiceLink { get; set; }

    public string? CRMDatabaseServer { get; set; }

    public int? CRMDatabaseType { get; set; }

    public int? CRMDatabaseAuthType { get; set; }

    public string? CRMDatabaseName { get; set; }

    public string? CRMDatabaseUser { get; set; }

    public string? CRMDatabasePassword { get; set; }

    public int? CRMDatabasePort { get; set; }

    public string? ERPDatabaseServer { get; set; }

    public int? ERPDatabaseType { get; set; }

    public int? ERPDatabaseAuthType { get; set; }

    public string? ERPDatabaseName { get; set; }

    public string? ERPMainDatabaseName { get; set; }

    public string? ERPDatabaseUser { get; set; }

    public string? ERPDatabasePassword { get; set; }

    public int? ERPDatabasePort { get; set; }

    public string? ERPApplicationUser { get; set; }

    public string? ERPApplicationPassword { get; set; }

    public string? ERPSecurityCode { get; set; }

    public int? ERPApplicationFirmNumber { get; set; }

    public int? ERPApplicationPeriodNumber { get; set; }

    public string? ProductImportFilterSQL { get; set; }

    public string? FirmImportFilterSQL { get; set; }

    public int? StockControlOnProduct { get; set; }

    public int? StockControlOnProductTiming { get; set; }

    public int? StockControlOnProductType { get; set; }

    public string? StockControlSQL { get; set; }

    public int? ARPBalanceControl { get; set; }

    public string? ARPBalanceControlSQL { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ServiceImportFilterSQL { get; set; }

    public bool? SyncProductPrices { get; set; }

    public bool? SyncInChargeWithARP { get; set; }

    public bool? UseCompressedXML { get; set; }

    public int? ProposalToERPDate { get; set; }

    public bool? NETSISTemelSet { get; set; }

    public bool? ARPCodeIsUnique { get; set; }

    public bool? ARPTaxNoIsUnique { get; set; }

    public bool? ProductCodeIsUnique { get; set; }

    public bool? NETSISCalcPrice_BasedOnConditions { get; set; }

    public bool? NETSISCalcPrice_BasedOnStockCard { get; set; }

    public bool? NETSISCalcPrice_BasedOnPriceSystem { get; set; }

    public bool? UsePriceSQLs { get; set; }

    public string? GetPriceSQL { get; set; }

    public string? GetCurrencySQL { get; set; }

    public string? GetDiscount1SQL { get; set; }

    public string? GetDiscount2SQL { get; set; }

    public string? GetPriceConnectionString { get; set; }

    public int? StockControlOnProductAdd { get; set; }

    public int? StockControlOnProductSave { get; set; }

    public int? StockControlOnProductSale { get; set; }

    public bool? UseCompressedXMLOldMethod { get; set; }

    public int? NetsisRESTApiVersion { get; set; }

    public string? NetsisDefaultBranchCode { get; set; }

    public string? NETSISInvoiceSerialDefaultValue { get; set; }

    public virtual ICollection<EI_Contact_Relations> EI_Contact_Relations { get; set; } = new List<EI_Contact_Relations>();

    public virtual ICollection<EI_Firm_Relations> EI_Firm_Relations { get; set; } = new List<EI_Firm_Relations>();

    public virtual ICollection<EI_Product_Relations> EI_Product_Relations { get; set; } = new List<EI_Product_Relations>();

    public virtual ICollection<EI_Proposal_Relations> EI_Proposal_Relations { get; set; } = new List<EI_Proposal_Relations>();

    public virtual ICollection<EI_Shipment_Address_Relations> EI_Shipment_Address_Relations { get; set; } = new List<EI_Shipment_Address_Relations>();

    public virtual ICollection<EI_Unit_Collection_Relations> EI_Unit_Collection_Relations { get; set; } = new List<EI_Unit_Collection_Relations>();

    public virtual ICollection<EI_Unit_Relations> EI_Unit_Relations { get; set; } = new List<EI_Unit_Relations>();

    public virtual ICollection<EI_User_ERPBalanceControl_Settings> EI_User_ERPBalanceControl_Settings { get; set; } = new List<EI_User_ERPBalanceControl_Settings>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<RI_User_ERPWarehouse> RI_User_ERPWarehouse { get; set; } = new List<RI_User_ERPWarehouse>();

    public virtual ICollection<RL_Integration_Sets_User> RL_Integration_Sets_User { get; set; } = new List<RL_Integration_Sets_User>();

    public virtual ICollection<ST_User> ST_User { get; set; } = new List<ST_User>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

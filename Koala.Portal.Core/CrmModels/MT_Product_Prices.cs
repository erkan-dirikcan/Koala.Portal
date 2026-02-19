namespace Koala.Portal.Core.CrmModels;

public partial class MT_Product_Prices
{
    public Guid Oid { get; set; }

    public Guid? ProductOid { get; set; }

    public DateTime? PriceStartDate { get; set; }

    public DateTime? PriceEndDate { get; set; }

    public Guid? CurrencyType { get; set; }

    public double? Price { get; set; }

    public Guid? PriceType { get; set; }

    public string? ERPCode { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? VATIncluded { get; set; }

    public virtual CT_Currency_Types? CurrencyTypeNavigation { get; set; }

    public virtual CT_Price_Types? PriceTypeNavigation { get; set; }

    public virtual MT_Product? ProductO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

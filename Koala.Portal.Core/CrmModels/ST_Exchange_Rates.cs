namespace Koala.Portal.Core.CrmModels;

public partial class ST_Exchange_Rates
{
    public Guid Oid { get; set; }

    public string? ExchangeRateDate { get; set; }

    public Guid? RateCurrencyType { get; set; }

    public double? Rate1 { get; set; }

    public double? Rate2 { get; set; }

    public double? Rate3 { get; set; }

    public double? Rate4 { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Currency_Types? RateCurrencyTypeNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class foProductVariantItem
{
    public Guid Oid { get; set; }

    public int? VariantRef { get; set; }

    public int? CharRef { get; set; }

    public int? ValRef { get; set; }

    public string? VariantCode { get; set; }

    public string? VariantDescription { get; set; }

    public double? Amount { get; set; }

    public double? Price { get; set; }

    public bool? Listed { get; set; }

    public Guid? Variant { get; set; }

    public Guid? Unit { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? VariantDescription2 { get; set; }

    public bool? VariantPriceRead { get; set; }

    public bool? ReadPrice { get; set; }

    public double? Onhand { get; set; }

    public double? RealValue { get; set; }

    public bool? SelectedVariantItem { get; set; }

    public virtual CT_Units? UnitNavigation { get; set; }

    public virtual foProductVariant? VariantNavigation { get; set; }
}

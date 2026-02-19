namespace Koala.Portal.Core.CrmModels;

public partial class foProductVariant
{
    public Guid Oid { get; set; }

    public Guid? Product { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductDescription { get; set; }

    public double? Amount { get; set; }

    public double? Price { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Product? ProductNavigation { get; set; }

    public virtual ICollection<foProductVariantItem> foProductVariantItem { get; set; } = new List<foProductVariantItem>();
}

namespace Koala.Portal.Core.CrmModels;

public partial class foProductSelectionItem
{
    public Guid Oid { get; set; }

    public string? _Code { get; set; }

    public string? _Description { get; set; }

    public Guid? _ProductOid { get; set; }

    public double? Amount { get; set; }

    public double? Discount1Percent { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

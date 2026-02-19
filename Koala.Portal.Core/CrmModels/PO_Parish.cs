namespace Koala.Portal.Core.CrmModels;

public partial class PO_Parish
{
    public Guid Oid { get; set; }

    public string? ParishName { get; set; }

    public Guid? DistrictOid { get; set; }

    public int? GlobalDBId { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual PO_District? DistrictO { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();
}

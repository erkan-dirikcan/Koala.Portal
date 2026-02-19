namespace Koala.Portal.Core.CrmModels;

public partial class PO_District
{
    public Guid Oid { get; set; }

    public string? DistrictName { get; set; }

    public Guid? CountyOid { get; set; }

    public int? GlobalDBId { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual PO_County? CountyO { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_Parish> PO_Parish { get; set; } = new List<PO_Parish>();
}

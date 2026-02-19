namespace Koala.Portal.Core.CrmModels;

public partial class PO_County
{
    public Guid Oid { get; set; }

    public string? CountyName { get; set; }

    public Guid? CityOid { get; set; }

    public int? GlobalDBId { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual PO_City? CityO { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_District> PO_District { get; set; } = new List<PO_District>();
}

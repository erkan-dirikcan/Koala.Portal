namespace Koala.Portal.Core.CrmModels;

public partial class PO_City
{
    public Guid Oid { get; set; }

    public string? CityName { get; set; }

    public string? AreaCode { get; set; }

    public Guid? CountryOid { get; set; }

    public int? GlobalDBId { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? LicensePlateCode { get; set; }

    public virtual PO_Country? CountryO { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_County> PO_County { get; set; } = new List<PO_County>();
}

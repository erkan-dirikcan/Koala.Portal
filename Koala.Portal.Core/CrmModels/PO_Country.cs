namespace Koala.Portal.Core.CrmModels;

public partial class PO_Country
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public string? PhoneCode { get; set; }

    public string? TripleCode { get; set; }

    public int? GlobalDBId { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? BinaryCode { get; set; }

    public virtual ICollection<PO_Address> PO_Address { get; set; } = new List<PO_Address>();

    public virtual ICollection<PO_City> PO_City { get; set; } = new List<PO_City>();

    public virtual ICollection<PO_Phone_Number> PO_Phone_Number { get; set; } = new List<PO_Phone_Number>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

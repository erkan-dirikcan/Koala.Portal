namespace Koala.Portal.Core.CrmModels;

public partial class PO_Phone_Type
{
    public Guid Oid { get; set; }

    public string? TypeName { get; set; }

    public int? PhoneTypeClass { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<PO_Phone_Number> PO_Phone_Number { get; set; } = new List<PO_Phone_Number>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

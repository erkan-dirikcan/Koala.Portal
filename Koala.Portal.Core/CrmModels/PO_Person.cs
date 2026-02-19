namespace Koala.Portal.Core.CrmModels;

public partial class PO_Person
{
    public Guid Oid { get; set; }

    public int? InternalPersonType { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Email { get; set; }

    public byte[]? Photo { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual ICollection<CT_Personnel> CT_Personnel { get; set; } = new List<CT_Personnel>();

    public virtual ICollection<CT_Sales_Rep> CT_Sales_Rep { get; set; } = new List<CT_Sales_Rep>();

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual ST_User? ST_User { get; set; }
}

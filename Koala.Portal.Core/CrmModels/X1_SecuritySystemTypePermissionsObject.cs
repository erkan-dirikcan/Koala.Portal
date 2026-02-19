namespace Koala.Portal.Core.CrmModels;

public partial class X1_SecuritySystemTypePermissionsObject
{
    public Guid Oid { get; set; }

    public string? TargetType { get; set; }

    public bool? AllowRead { get; set; }

    public bool? AllowWrite { get; set; }

    public bool? AllowCreate { get; set; }

    public bool? AllowDelete { get; set; }

    public bool? AllowNavigate { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public Guid? Owner { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual X1_SecuritySystemRole? OwnerNavigation { get; set; }

    public virtual ICollection<X1_SecuritySystemMemberPermissionsObject> X1_SecuritySystemMemberPermissionsObject { get; set; } = new List<X1_SecuritySystemMemberPermissionsObject>();

    public virtual ICollection<X1_SecuritySystemObjectPermissionsObject> X1_SecuritySystemObjectPermissionsObject { get; set; } = new List<X1_SecuritySystemObjectPermissionsObject>();
}

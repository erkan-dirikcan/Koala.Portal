namespace Koala.Portal.Core.CrmModels;

public partial class X1_SecuritySystemObjectPermissionsObject
{
    public Guid Oid { get; set; }

    public string? Criteria { get; set; }

    public bool? AllowRead { get; set; }

    public bool? AllowWrite { get; set; }

    public bool? AllowDelete { get; set; }

    public bool? AllowNavigate { get; set; }

    public Guid? Owner { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_SecuritySystemTypePermissionsObject? OwnerNavigation { get; set; }
}

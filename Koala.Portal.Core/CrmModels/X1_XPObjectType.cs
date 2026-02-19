namespace Koala.Portal.Core.CrmModels;

public partial class X1_XPObjectType
{
    public int OID { get; set; }

    public string? TypeName { get; set; }

    public string? AssemblyName { get; set; }

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<PO_Person> PO_Person { get; set; } = new List<PO_Person>();

    public virtual ICollection<X1_ModelDifference> X1_ModelDifference { get; set; } = new List<X1_ModelDifference>();

    public virtual ICollection<X1_ReportDataV2> X1_ReportDataV2 { get; set; } = new List<X1_ReportDataV2>();

    public virtual ICollection<X1_SecuritySystemRole> X1_SecuritySystemRole { get; set; } = new List<X1_SecuritySystemRole>();

    public virtual ICollection<X1_SecuritySystemTypePermissionsObject> X1_SecuritySystemTypePermissionsObject { get; set; } = new List<X1_SecuritySystemTypePermissionsObject>();

    public virtual ICollection<X1_SecuritySystemUser> X1_SecuritySystemUser { get; set; } = new List<X1_SecuritySystemUser>();

    public virtual ICollection<X1_XPWeakReference> X1_XPWeakReferenceObjectTypeNavigation { get; set; } = new List<X1_XPWeakReference>();

    public virtual ICollection<X1_XPWeakReference> X1_XPWeakReferenceTargetTypeNavigation { get; set; } = new List<X1_XPWeakReference>();

    public virtual ICollection<XPWeakReference> XPWeakReferenceObjectTypeNavigation { get; set; } = new List<XPWeakReference>();

    public virtual ICollection<XPWeakReference> XPWeakReferenceTargetTypeNavigation { get; set; } = new List<XPWeakReference>();

    public virtual ICollection<XP_XpandPermissionData> XP_XpandPermissionData { get; set; } = new List<XP_XpandPermissionData>();
}

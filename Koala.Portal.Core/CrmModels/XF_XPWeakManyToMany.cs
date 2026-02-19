namespace Koala.Portal.Core.CrmModels;

public partial class XF_XPWeakManyToMany
{
    public int OID { get; set; }

    public int? LeftTargetType { get; set; }

    public string? LeftTargetKey { get; set; }

    public int? RightTargetType { get; set; }

    public string? RightTargetKey { get; set; }

    public string? RelationName { get; set; }

    public int? OptimisticLockField { get; set; }
}

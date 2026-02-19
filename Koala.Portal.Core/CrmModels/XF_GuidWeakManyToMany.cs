namespace Koala.Portal.Core.CrmModels;

public partial class XF_GuidWeakManyToMany
{
    public int OID { get; set; }

    public int? LeftTypeId { get; set; }

    public Guid? LeftId { get; set; }

    public int? RightTypeId { get; set; }

    public Guid? RightId { get; set; }

    public string? RelationName { get; set; }

    public int? OptimisticLockField { get; set; }
}

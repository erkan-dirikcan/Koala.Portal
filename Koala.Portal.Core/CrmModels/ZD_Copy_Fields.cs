namespace Koala.Portal.Core.CrmModels;

public partial class ZD_Copy_Fields
{
    public Guid Oid { get; set; }

    public int? UseCase { get; set; }

    public bool? IsActive { get; set; }

    public string? SourceProperty { get; set; }

    public string? TargetProperty { get; set; }

    public string? UsersAndDepartments { get; set; }

    public string? SourceObjectType { get; set; }

    public string? SourceCriteria { get; set; }

    public string? TargetObjectType { get; set; }

    public string? TargetCriteria { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

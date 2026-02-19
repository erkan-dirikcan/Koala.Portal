namespace Koala.Portal.Core.CrmModels;

public partial class ZD_Default_Values
{
    public Guid Oid { get; set; }

    public string? TargetClass { get; set; }

    public string? SourceClass { get; set; }

    public int? DaysToAdd { get; set; }

    public bool? IsActive { get; set; }

    public string? TargetProperty { get; set; }

    public string? TargetChangeProperty { get; set; }

    public string? AssignValue { get; set; }

    public int? AssignOn { get; set; }

    public string? UsersAndDepartments { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? UseUpperCase { get; set; }

    public string? ListViewIds { get; set; }

    public string? Criterion { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

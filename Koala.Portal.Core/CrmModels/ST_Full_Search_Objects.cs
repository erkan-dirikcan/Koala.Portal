namespace Koala.Portal.Core.CrmModels;

public partial class ST_Full_Search_Objects
{
    public Guid Oid { get; set; }

    public string? BOName { get; set; }

    public string? BONamespace { get; set; }

    public string? BODisplayProperty { get; set; }

    public string? BOCriteria { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

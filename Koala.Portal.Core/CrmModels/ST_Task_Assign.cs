namespace Koala.Portal.Core.CrmModels;

public partial class ST_Task_Assign
{
    public Guid Oid { get; set; }

    public Guid? TaskOid { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public Guid? AssignedTo { get; set; }

    public Guid? AssignedDepartment { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_User_Departments? AssignedDepartmentNavigation { get; set; }

    public virtual ST_User? AssignedToNavigation { get; set; }

    public virtual MT_Task? TaskO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class EI_User_ERPBalanceControl_Settings
{
    public Guid Oid { get; set; }

    public Guid? SetOid { get; set; }

    public Guid? UserOid { get; set; }

    public int? ARPBalanceControl { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual EI_Integration_Sets? SetO { get; set; }

    public virtual ST_User? UserO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

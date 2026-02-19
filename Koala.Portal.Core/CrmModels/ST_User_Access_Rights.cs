namespace Koala.Portal.Core.CrmModels;

public partial class ST_User_Access_Rights
{
    public Guid Oid { get; set; }

    public Guid? UserOId { get; set; }

    public Guid? AccessDefinitionCode { get; set; }

    public bool? Granted { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_User_Access_Definitions? AccessDefinitionCodeNavigation { get; set; }

    public virtual ST_User? UserO { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

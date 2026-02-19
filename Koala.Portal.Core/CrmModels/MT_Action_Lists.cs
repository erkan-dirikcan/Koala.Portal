namespace Koala.Portal.Core.CrmModels;

public partial class MT_Action_Lists
{
    public Guid Oid { get; set; }

    public string? ListName { get; set; }

    public Guid? ListType { get; set; }

    public int? ListObjectType { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? FirmSQL { get; set; }

    public bool? IsActiveFirmSQL { get; set; }

    public string? ContactSQL { get; set; }

    public bool? IsActiveContactSQL { get; set; }

    public virtual CT_List_Types? ListTypeNavigation { get; set; }

    public virtual ICollection<RL_Contact_Actions_Lists> RL_Contact_Actions_Lists { get; set; } = new List<RL_Contact_Actions_Lists>();

    public virtual ICollection<RL_Firm_Actions_Lists> RL_Firm_Actions_Lists { get; set; } = new List<RL_Firm_Actions_Lists>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

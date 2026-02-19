namespace Koala.Portal.Core.CrmModels;

public partial class CT_List_Types
{
    public Guid Oid { get; set; }

    public string? ListTypeDescription { get; set; }

    public bool? IsActive { get; set; }

    public bool? DefaultSendEnabled { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Action_Lists> MT_Action_Lists { get; set; } = new List<MT_Action_Lists>();

    public virtual ICollection<RL_Campaign_List_Types> RL_Campaign_List_Types { get; set; } = new List<RL_Campaign_List_Types>();

    public virtual ICollection<RL_Contact_List_Types> RL_Contact_List_Types { get; set; } = new List<RL_Contact_List_Types>();

    public virtual ICollection<RL_Firm_List_Types> RL_Firm_List_Types { get; set; } = new List<RL_Firm_List_Types>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class CT_Sectors
{
    public Guid Oid { get; set; }

    public string? SectorName { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<CT_Sub_Sectors> CT_Sub_Sectors { get; set; } = new List<CT_Sub_Sectors>();

    public virtual ICollection<MT_Contact> MT_Contact { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Firm> MT_Firm { get; set; } = new List<MT_Firm>();

    public virtual ICollection<RL_Firm_Sectors> RL_Firm_Sectors { get; set; } = new List<RL_Firm_Sectors>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

namespace Koala.Portal.Core.CrmModels;

public partial class MT_Shares
{
    public Guid Oid { get; set; }

    public string? ShareDescription { get; set; }

    public int? Priority { get; set; }

    public string? ShareContent { get; set; }

    public string? Tags { get; set; }

    public string? ShareWith { get; set; }

    public string? NavigateUrl { get; set; }

    public string? ImageUrl { get; set; }

    public string? SeenBy { get; set; }

    public string? ObjectClassName { get; set; }

    public Guid? ObjectOid { get; set; }

    public string? ObjectDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<RL_Document_Shares> RL_Document_Shares { get; set; } = new List<RL_Document_Shares>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

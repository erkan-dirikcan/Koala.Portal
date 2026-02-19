namespace Koala.Portal.Core.CrmModels;

public partial class MT_Campaign_Lists
{
    public Guid Oid { get; set; }

    public Guid? Campaign { get; set; }

    public Guid? ObjectOid { get; set; }

    public int? ObjectType { get; set; }

    public string? ObjectDescription { get; set; }

    public Guid? Firm { get; set; }

    public Guid? Contact { get; set; }

    public string? Tags { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Campaign? CampaignNavigation { get; set; }

    public virtual MT_Contact? ContactNavigation { get; set; }

    public virtual MT_Firm? FirmNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}

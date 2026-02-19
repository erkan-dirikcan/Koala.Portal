namespace Koala.Portal.Core.CrmModels;

public partial class ST_IPS_Logs
{
    public Guid Oid { get; set; }

    public DateTime? Date_ { get; set; }

    public Guid? LoggedInUser { get; set; }

    public Guid? AgentUser { get; set; }

    public int? Action { get; set; }

    public string? CallUniqueId { get; set; }

    public string? CallerId { get; set; }

    public string? Extension { get; set; }

    public string? AgentId { get; set; }

    public Guid? RelatedFirm { get; set; }

    public Guid? RelatedContact { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? AgentUserNavigation { get; set; }

    public virtual ST_User? LoggedInUserNavigation { get; set; }

    public virtual MT_Contact? RelatedContactNavigation { get; set; }

    public virtual MT_Firm? RelatedFirmNavigation { get; set; }
}

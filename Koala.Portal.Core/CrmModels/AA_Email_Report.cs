namespace Koala.Portal.Core.CrmModels;

public partial class AA_Email_Report
{
    public Guid Oid { get; set; }

    public string? PacketId { get; set; }

    public string? MainPacketId { get; set; }

    public Guid? Firm { get; set; }

    public Guid? Contact { get; set; }

    public string? ReceiverEmail { get; set; }

    public string? ApiKey { get; set; }

    public string? EmailMessageId { get; set; }

    public string? SessionId { get; set; }

    public string? SendDate { get; set; }

    public string? EmailAddress { get; set; }

    public string? Status { get; set; }

    public string? StatusDescription { get; set; }

    public string? UserName { get; set; }

    public string? ListType { get; set; }

    public string? CreatedDate { get; set; }

    public string? AccountName { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Contact? ContactNavigation { get; set; }

    public virtual MT_Firm? FirmNavigation { get; set; }
}

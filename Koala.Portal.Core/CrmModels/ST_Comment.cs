namespace Koala.Portal.Core.CrmModels;

public partial class ST_Comment
{
    public Guid Oid { get; set; }

    public Guid? UserOid { get; set; }

    public string? OrderNo { get; set; }

    public string? Parent { get; set; }

    public string? Comment { get; set; }

    public Guid? RelatedOid { get; set; }

    public int? UpVoteCount { get; set; }

    public string? FileURL { get; set; }

    public string? FileMimeType { get; set; }

    public string? NotifyUsers { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public Guid? _CreatedBy { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ModuleName { get; set; }

    public int? OrderNumber { get; set; }

    public int? ParentNumber { get; set; }
}

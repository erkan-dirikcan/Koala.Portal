namespace Koala.Portal.Core.CrmModels;

public partial class ST_Comment_Upvotes
{
    public Guid Oid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid? CommentOid { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public Guid? _CreatedBy { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

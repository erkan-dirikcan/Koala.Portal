namespace Koala.Portal.Core.CrmModels;

public partial class PO_File
{
    public Guid Oid { get; set; }

    public int? size { get; set; }

    public string? FileName { get; set; }

    public byte[]? Content { get; set; }

    public string? FullName { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Document> MT_Document { get; set; } = new List<MT_Document>();
}

namespace Koala.Portal.Core.CrmModels;

public partial class SS_FilePath_Setting
{
    public Guid Oid { get; set; }

    public string? ImageFolderPath { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}

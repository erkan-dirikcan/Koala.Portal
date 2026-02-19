namespace Koala.Portal.Core.CrmModels;

public partial class ST_Installed_Apps_Names
{
    public Guid Oid { get; set; }

    public string? AppMLName { get; set; }

    public string? LanguageCode { get; set; }

    public Guid? AppOid { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_Installed_Apps? AppO { get; set; }
}

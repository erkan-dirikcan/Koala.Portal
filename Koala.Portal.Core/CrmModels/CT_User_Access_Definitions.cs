namespace Koala.Portal.Core.CrmModels;

public partial class CT_User_Access_Definitions
{
    public Guid Oid { get; set; }

    public int? AccessCode { get; set; }

    public string? AccessDefinition { get; set; }

    public int? ParentCode { get; set; }

    public string? LanguageId { get; set; }

    public string? ModuleId { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<ST_User_Access_Rights> ST_User_Access_Rights { get; set; } = new List<ST_User_Access_Rights>();
}

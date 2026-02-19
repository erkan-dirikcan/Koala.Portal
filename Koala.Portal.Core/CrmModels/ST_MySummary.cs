namespace Koala.Portal.Core.CrmModels;

public partial class ST_MySummary
{
    public Guid Oid { get; set; }

    public Guid? User_ { get; set; }

    public string? UserDepartment { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<ST_MySummary_Cache> ST_MySummary_Cache { get; set; } = new List<ST_MySummary_Cache>();

    public virtual ST_User? User_Navigation { get; set; }
}

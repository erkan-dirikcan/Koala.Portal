namespace Koala.Portal.Core.CrmModels;

public partial class X1_ModelDifferenceAspect
{
    public Guid Oid { get; set; }

    public string? Name { get; set; }

    public string? Xml { get; set; }

    public Guid? Owner { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_ModelDifference? OwnerNavigation { get; set; }
}

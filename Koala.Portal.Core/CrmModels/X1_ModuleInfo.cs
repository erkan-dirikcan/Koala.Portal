namespace Koala.Portal.Core.CrmModels;

public partial class X1_ModuleInfo
{
    public int ID { get; set; }

    public string? Version { get; set; }

    public string? Name { get; set; }

    public string? AssemblyFileName { get; set; }

    public bool? IsMain { get; set; }

    public int? OptimisticLockField { get; set; }
}

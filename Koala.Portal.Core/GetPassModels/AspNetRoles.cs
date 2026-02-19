namespace Koala.Portal.Core.GetPassModels;

public partial class AspNetRoles
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUsers> User { get; set; } = new List<AspNetUsers>();
}

namespace Koala.Portal.Core.CrmModels;

public partial class XP_XpandUser
{
    public Guid Oid { get; set; }

    public string? Activation { get; set; }

    public string? Email { get; set; }

    public virtual X1_SecuritySystemUser OidNavigation { get; set; } = null!;
}

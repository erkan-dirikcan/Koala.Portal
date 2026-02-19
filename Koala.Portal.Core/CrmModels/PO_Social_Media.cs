namespace Koala.Portal.Core.CrmModels;

public partial class PO_Social_Media
{
    public Guid Oid { get; set; }

    public string? smFacebook { get; set; }

    public string? smTwitter { get; set; }

    public string? smInstagram { get; set; }

    public string? smGooglePlus { get; set; }

    public string? smLinkedIn { get; set; }

    public string? smSkype { get; set; }

    public string? smYoutube { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Contact> MT_Contact { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Firm> MT_Firm { get; set; } = new List<MT_Firm>();
}

namespace Koala.Portal.Core.CrmModels;

public partial class ST_User_Works
{
    public Guid ID { get; set; }

    public string Type { get; set; } = null!;

    public string? UserID { get; set; }

    public string SeenBy { get; set; } = null!;

    public string? ShareWith { get; set; }

    public string ObjectType { get; set; } = null!;

    public DateTime? Moddate { get; set; }

    public string ViewId { get; set; } = null!;
}

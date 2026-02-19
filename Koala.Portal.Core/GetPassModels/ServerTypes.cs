namespace Koala.Portal.Core.GetPassModels;

public partial class ServerTypes
{
    public string Id { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string? CreateUserId { get; set; }

    public string? LastUpdateUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public virtual ICollection<MyDatas> MyDatas { get; set; } = new List<MyDatas>();
}

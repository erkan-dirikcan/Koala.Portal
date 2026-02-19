namespace Koala.Portal.Core.GetPassModels;

public partial class MyDatas
{
    public string Id { get; set; } = null!;

    public string? ReleatedUserId { get; set; }

    public string? ServerTypeId { get; set; }

    public string? FirmName { get; set; }

    public string? Ip { get; set; }

    public string? LocalIp { get; set; }

    public string? Port { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? CreateUserId { get; set; }

    public string? LastUpdateUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public string? VpnAplication { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Status { get; set; }

    public virtual AspNetUsers? ReleatedUser { get; set; }

    public virtual ServerTypes? ServerType { get; set; }
}

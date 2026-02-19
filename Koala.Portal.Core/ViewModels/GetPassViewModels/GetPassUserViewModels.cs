namespace Koala.Portal.Core.ViewModels.GetPassViewModels;

public class GetPassGetUserSkeySelectListViewModels
{
	public string FullName { get; set; }
	public string Skey { get; set; }
}
public class GetPassGetUserInfoViewModels
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FirmName { get; set; }
    public string ServerType { get; set; }
    public string VpnAplication { get; set; }
}
public class GetPassGetLineInfoViewModel
{
    public string Ip { get; set; }
    public string LocalIp { get; set; }
    public string Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class GetSummaryUserInfoViewModel
{
    public string Id { get; set; } = null!;
    public string? Email { get; set; }
}

public class CreateNewPassViewModels
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Firm { get; set; }
    public string VpnAplication { get; set; }
    public string Ip { get; set; }
    public string LocalIp { get; set; }
    public string Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
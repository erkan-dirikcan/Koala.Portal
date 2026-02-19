namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class EmailSettingViewModel
    {
        public EmailSettingViewModel()
        {

        }
        public EmailSettingViewModel(string host, string password, string email)
        {
            Host = host;
            Password = password;
            Email = email;
        }

        public string? Host { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }

}

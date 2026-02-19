using Koala.Portal.Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.WebUI.Models
{
    public class AppUser:IdentityUser<string>
    {
        public string Oid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public UserStatusEnum Status { get; set; }

    }
}

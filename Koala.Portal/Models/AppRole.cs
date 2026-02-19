using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.WebUI.Models
{
    public class AppRole:IdentityRole<string>
    {
        public string Description { get; set; }


    }
}

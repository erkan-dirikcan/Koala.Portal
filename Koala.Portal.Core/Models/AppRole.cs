using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.Core.Models
{
    public class AppRole:IdentityRole<string>
    {

        public string Description { get; set; }


    }
}

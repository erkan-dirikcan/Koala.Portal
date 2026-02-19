using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.Repository.SeedData
{
    public class ModuleSeed
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IModuleService _service;

        public ModuleSeed(IHttpContextAccessor contextAccessor,UserManager<AppUser> userManager,IModuleService service)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _service = service;
        }
        public static async Task Seed(IHttpContextAccessor _contextAccessor)
        {
           
        }
    }
}

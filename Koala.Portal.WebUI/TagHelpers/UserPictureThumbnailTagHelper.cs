using Koala.Portal.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class UserPictureThumbnailTagHelper : TagHelper
    {
        public UserPictureThumbnailTagHelper(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _contextAccessor.HttpContext?.User;
            var userInfo = _userManager.GetUserAsync(user).Result;
            output.TagName = "img";
            output.Attributes.SetAttribute("src",
                string.IsNullOrEmpty(userInfo.Avatar)
                    ? "/media/avatar/KoalaNoPic.png"
                    : $"/media/avatar/{userInfo.Avatar}");
            output.Attributes.SetAttribute(" accept","=\"image/png, image/jpeg\"");

            output.Attributes.SetAttribute("id", "AvatarImg");


            base.Process(context, output);
        }
    }
}

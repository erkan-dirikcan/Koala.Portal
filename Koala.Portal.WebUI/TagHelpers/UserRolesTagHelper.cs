using System.Text;
using Koala.Portal.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class UserRolesTagHelper:TagHelper
    {
        public string UserId { get; set; }
        private readonly UserManager<AppUser> _userManager;

        public UserRolesTagHelper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var userRoles=await _userManager.GetRolesAsync(user!);
            var html = new StringBuilder();
            userRoles.ToList().ForEach(x =>
            {
                html.Append(@$"<span class=""label label-success label-inline mr-2"">{x}</span> <br />");
            });
            output.Content.SetHtmlContent(html.ToString());

        }
    }
}

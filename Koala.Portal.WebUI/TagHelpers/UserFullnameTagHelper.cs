using System.Text.Encodings.Web;
using Koala.Portal.Core.Models;
using Koala.Portal.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class UserFullnameTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserFullnameTagHelper(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _contextAccessor.HttpContext?.User;
            var userName = _userManager.GetUserAsync(user).Result;
            output.TagName = "span";
            output.Content.SetContent(userName.Name + " " + userName.Lastname);
            output.AddClass("text-dark-50", HtmlEncoder.Default);
            output.AddClass("font-weight-bolder", HtmlEncoder.Default);
            output.AddClass("font-size-base", HtmlEncoder.Default);
            output.AddClass("d-none", HtmlEncoder.Default);
            output.AddClass("d-md-inline", HtmlEncoder.Default);
            output.AddClass("mr-3", HtmlEncoder.Default);

        }
    }
    //<span class="symbol-label font-size-h5 font-weight-bold">S</span>
    public class UserFirstWordTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserFirstWordTagHelper(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _contextAccessor.HttpContext.User;
            var userName = _userManager.GetUserAsync(user).Result;
            output.TagName = "span";
            output.Content.SetContent(userName.Name.Substring(0, 1).ToUpper());
            output.AddClass("symbol-label", HtmlEncoder.Default);
            output.AddClass("font-size-h5", HtmlEncoder.Default);
            output.AddClass("font-weight-bold", HtmlEncoder.Default);

        }
    }

    public class UserFullNameWithOidTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;
        public string UserOid { get; set; }

        public UserFullNameWithOidTagHelper(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var userInfo = _userManager.Users.FirstOrDefault(x => x.Oid == UserOid);
            output.TagName = "a";
            //<a class="text-muted font-weight-bold text-hover-primary  font-size-xs" href="#">Cevap Bekleyen</a>

            output.AddClass("font-size-xs", HtmlEncoder.Default);
            output.AddClass("text-muted", HtmlEncoder.Default);
            output.AddClass("text-hover-primary", HtmlEncoder.Default);
            if (string.IsNullOrEmpty(UserOid) || userInfo == null)
            {
                output.Content.SetContent($"-");
            }
            else
            {
                output.Content.SetContent($"{userInfo.Name} {userInfo.Lastname}");
            }


        }

    }
    public class CrmUserFullNameWithOidTagHelper : TagHelper
    {
        public string UserOid { get; set; }

        private readonly SistemCrmContext _context;

        public CrmUserFullNameWithOidTagHelper(SistemCrmContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "a";
            //<a class="text-muted font-weight-bold text-hover-primary  font-size-xs" href="#">Cevap Bekleyen</a>

            output.AddClass("font-size-xs", HtmlEncoder.Default);
            output.AddClass("text-muted", HtmlEncoder.Default);
            output.AddClass("text-hover-primary", HtmlEncoder.Default);
            if (string.IsNullOrEmpty(UserOid))
            {
                output.Content.SetContent($"-");
            }
            else
            {
                try
                {
                    var userInfo = _context.ST_User.FirstOrDefault(x => x.Oid == new Guid(UserOid));
                    output.Content.SetContent(userInfo == null ? $"-" : $"{userInfo.Caption}");
                }
                catch (Exception ex)
                {
                    output.Content.SetContent($"-");
                }
            }


        }


    }
}

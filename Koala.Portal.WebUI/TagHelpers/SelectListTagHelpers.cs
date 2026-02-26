using System.Text;
using System.Text.Encodings.Web;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class FirmSelectTagHelper:TagHelper
    {
        private readonly IFirmService _firmService;

        public FirmSelectTagHelper(IFirmService firmService)
        {
            _firmService = firmService;
        }

        public string SelectedId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);
            var sb = new StringBuilder();
            var selected = "selected=\"selected\"";
            var firms = _firmService.GetFirmList().Result;
            if (!firms.IsSuccess)
            {
                output.Content.SetHtmlContent(sb.ToString());
                return;
            }
            foreach (var item in firms.Data)
            {
                sb.Append($"<option value=\"{item.Id}\" {(string.Equals(item.Id, SelectedId, StringComparison.OrdinalIgnoreCase) ? selected : string.Empty)}>({item.Code}) - {item.Title}</option>");
            }
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
    public class FirmContactSelectTagHelper:TagHelper
    {
        private readonly ICrmSelectListService _crmSelectListService;

        public FirmContactSelectTagHelper(ICrmSelectListService crmSelectListService)
        {
            _crmSelectListService = crmSelectListService;
        }

        public string SelectedId { get; set; }
        public string FirmId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);
            var sb = new StringBuilder();
            var selected = "selected=\"selected\"";
            var contacts = _crmSelectListService.GetFirmContactListWithOid(FirmId, SelectedId).Result;
            if (!contacts.IsSuccess)
            {
                output.Content.SetHtmlContent(sb.ToString());
                return;
            }
            foreach (var item in contacts.Data)
            {
                sb.Append($"<option value=\"{item.Value}\" {(item.Selected ? selected : string.Empty)}>{item.Text}</option>");
            }
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
    public class UserSelectTagHelper:TagHelper
    {
        private readonly IUserService _userService;

        public UserSelectTagHelper(IUserService userService)
        {
            _userService = userService;
        }

        public string SelectedId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);
            var sb = new StringBuilder();
            var selected = "selected=\"selected\"";
            var users = _userService.GetUserActiveList().Result;
            if (!users.IsSuccess)
            {
                output.Content.SetHtmlContent(sb.ToString());
                return;
            }
            foreach (var item in users.Data)
            {
                sb.Append($"<option value=\"{item.Id}\" {(string.Equals(item.Id, SelectedId, StringComparison.OrdinalIgnoreCase) ? selected : string.Empty)}>{item.Fullname}</option>");
            }
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}

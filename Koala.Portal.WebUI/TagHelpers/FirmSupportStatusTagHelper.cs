using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class FirmSupportStatusTagHelper:TagHelper
    {
        public string? FirmOid { get; set; }
        private readonly IFirmService _firmService;
        public FirmSupportStatusTagHelper(IFirmService firmService)
        {
            _firmService = firmService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var firm = _firmService.GetFirmList();
            
            base.Process(context, output);
        }
    }
}

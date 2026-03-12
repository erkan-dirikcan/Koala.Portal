using Koala.Portal.Core.CrmServices;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Text.Encodings.Web;

namespace Koala.Portal.WebUI.TagHelpers
{
    public class CrmFirmSelectTagHelper : TagHelper
    {
        private readonly ICrmFirmService _firmService;
        public string SelectedOid { get; set; } = string.Empty;
        public CrmFirmSelectTagHelper(ICrmFirmService firmService)
        {
            _firmService = firmService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            /*
             select class="form-control" id="kt_select2_1" name="param">
            <option value="AK">Alaska</option>
            </select>
             */
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);

            var firms = _firmService.Where(x => x.InUse == true);
            if (!firms.IsSuccess)
            {
                output.Content.SetHtmlContent(string.Empty);
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var item in firms.Data)
                {
                    if (SelectedOid.ToUpper() == item.Oid.ToUpper())
                    {
                        sb.Append($"<option value=\"{item.Oid}\" selected=\"selected\">({item.Code}) - {item.Title} </option>");
                    }
                    else
                    {
                        sb.Append($"<option value=\"{item.Oid}\">({item.Code}) - {item.Title} </option>");
                    }

                }
                output.Content.SetHtmlContent(sb.ToString());
            }
        }
    }
    public class CrmDepartmentSelectTagHelper : TagHelper
    {
        private readonly ICrmDepartmentService _departmentService;
        public string SelectedOid { get; set; } = string.Empty;

        public CrmDepartmentSelectTagHelper(ICrmDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);

            var departments = _departmentService.Where(x => x.GCRecord == null);
            if (!departments.IsSuccess)
            {
                output.Content.SetHtmlContent(string.Empty);
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var item in departments.Data)
                {
                    if (SelectedOid.ToUpper() == item.Oid.ToUpper())
                    {
                        sb.Append($"<option value=\"{item.Oid}\" selected=\"selected\">{item.DepartmentName} </option>");
                    }
                    else
                    {
                        sb.Append($"<option value=\"{item.Oid}\"> {item.DepartmentName} </option>");
                    }
                }
                output.Content.SetHtmlContent(sb.ToString());
            }
        }
    }
    public class CrmDepartmentUserSelectTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);
            // Dinamik olarak JavaScript ile doldurulacak
            output.Content.SetHtmlContent("<option value=\"\">Önce Departman Seçiniz</option>");
        }
    }
    public class CrmCategorySelectTagHelper : TagHelper
    {
        private readonly ICrmCategoryService _categoryService;
        public string SelectedOid { get; set; } = string.Empty;

        public CrmCategorySelectTagHelper(ICrmCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.AddClass("form-control", HtmlEncoder.Default);

            var categories = _categoryService.Where(x => x.IsActive == true && x.GCRecord == null);
            if (!categories.IsSuccess)
            {
                output.Content.SetHtmlContent(string.Empty);
            }
            else
            {
                var sb = new StringBuilder();
                foreach(var item in categories.Data)
                {
                    if (SelectedOid.ToUpper()== item.Oid.ToUpper())
                    {
                         sb.Append($"<option value=\"{item.Oid}\" selected=\"selected\">{item.ActivityCategoryDescription} </option>");
                    }
                    else
                    {
                         sb.Append($"<option value=\"{item.Oid}\" selected=\"selected\">{item.ActivityCategoryDescription} </option>");

                    }
                }
                output.Content.SetHtmlContent(sb.ToString());
            }
        }

    }
}

using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class CustomerPortalController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ICrmSqlService _crmSqlService;
        private readonly ICrmSupportService _crmSupportService;
        private readonly ISupportFileService _supportFileService;
        private readonly ICrmSelectListService _crmSelectListService;
        private readonly IFirmService _firmService;
        private readonly ICrmFirmService _crmFirmService;
        private readonly ICrmSupportStateService _crmSupportStateService;
        private readonly ICrmDepartmentService _crmSupportDepartmentService;
        private readonly ICrmCategoryService _crmSupportCategoryService;
        public CustomerPortalController()
        {
            
        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}

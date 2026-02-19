using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    public class CustomerSupportController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("https://sistem-koala.com:44160/CustomerSupport");
        }
        public IActionResult Login()
        {
            return Redirect("https://sistem-koala.com:44160/CustomerSupport");
        }
    }
}

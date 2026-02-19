using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    public class VacationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

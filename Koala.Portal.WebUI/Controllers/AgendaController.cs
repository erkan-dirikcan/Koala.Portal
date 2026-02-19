using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private readonly IAgendaTypeService _service;
        private readonly ILogger<AgendaController> _logger;
        private readonly UserManager<AppUser> _userManager;


        public AgendaController(IAgendaTypeService service, UserManager<AppUser> userManager, ILogger<AgendaController> logger)
        {
            _service = service;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAgenda()
        {
            try
            {
                var res = await _service.GetAllAsync();
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(Response<AgendaDetailViewModel>.FailData(400, "Etkinlik Takvimi Dataları Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));

            }
        }
    }
}

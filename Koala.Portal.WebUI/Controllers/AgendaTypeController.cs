using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize(Roles = "Yönetici, Yazılım")]
    public class AgendaTypeController : Controller
    {
        private readonly IAgendaTypeService _agendaTypeService;

        private readonly ILogger<DashboardController> _logger;
        private readonly IMapper _mapper;

        public AgendaTypeController(IAgendaTypeService agendaTypeService, IMapper mapper, ILogger<DashboardController> logger)
        {
            _agendaTypeService = agendaTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _agendaTypeService.GetAllAsync();
            if (!res.IsSuccess)
            {
                // var errors = (Koala.Portal.Core.Dtos.Response)TempData["Error"];
                TempData["Error"] = res;
                return View("Error");
            }
            return View(_mapper.Map<List<AgendaTypeListViewModel>>(res.Data));
        }

        public IActionResult CreateAgendaType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgendaType(CreateAgendaTypeViewModel model)
        {
            var res = await _agendaTypeService.AddAsyc(_mapper.Map<AgendaType>(model));
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = "Etkinlik tipi başarıyla eklendi";
            return RedirectToAction("Index", "AgendaType");
        }

        public async Task<IActionResult> UpdateAgendaType(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index","AgendaType");
            }

            var agendaType = await _agendaTypeService.GetByIdAsyc(id);
            if (agendaType == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Etkinlik Tipi Bulunamadı";
                return RedirectToAction("Index", "AgendaType");
            }
            return View(_mapper.Map<UpdateAgendaTypeViewModel>(agendaType.Data));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAgendaType(UpdateAgendaTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var res = await _agendaTypeService.Update(_mapper.Map<AgendaType>(model), model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = $"{model.Name} isimli etkinlik tipi başarıyla güncellendi";
            return RedirectToAction("Index", "AgendaType");
        }

        public async Task<IActionResult> AgendaTypeChangeStatus(string id, bool isActive)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Güncellenmek istenilen etkininlik tipinin kimlik bilgisine ulaşılamadı";
                return RedirectToAction("Index", "AgendaType");
            }

            var agendaType = await _agendaTypeService.GetByIdAsyc(id);
            if (agendaType == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek istenilen etkininlik tipinin bilgilerine ulaşılamadı";
                return RedirectToAction("Index", "AgendaType");
            }

            agendaType.Data.IsActive = isActive;
            var res =await _agendaTypeService.Update(agendaType.Data, id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                TempData["ErrorMessage"] = item;
                return RedirectToAction("Index", "AgendaType");
            }

            TempData["InfoMessage"] = $"Etkinlik tipi durumu başarıyla değiştirildi";
            return RedirectToAction("Index", "AgendaType");
        }
    }
}

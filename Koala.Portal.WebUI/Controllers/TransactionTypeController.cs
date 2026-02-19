using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class TransactionTypeController : Controller
    {
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly IMapper _mapper;

        public TransactionTypeController(ITransactionTypeService transactionTypeService, IMapper mapper)
        {
            _transactionTypeService = transactionTypeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _transactionTypeService.GetTransactionTypeList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public IActionResult CreateTransactionType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransactionType(CreateTransactionTypeViewModels model)
        {
            var res = await _transactionTypeService.AddAsync(model);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = "Transaction Tipi Başarıyla Eklendi";
            return RedirectToAction("Index", "TransactionType");
        }
        public async Task<IActionResult> UpdateTransactionType(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "Module");
            }

            var module = await _transactionTypeService.GetUpdateInfoAsync(id);
            if (module.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Modül Bulunamadı";
                return RedirectToAction("Index", "Module");
            }
            if (!module.IsSuccess)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Modül Bulunamadı";
                return RedirectToAction("Index", "Module");
            }
            var classTypeSelectList = new List<SelectListItem>
            {
                new SelectListItem{Text="Kırmızı", Value="timeline-desc-light-danger",Selected=module.Data.ColorClass=="timeline-desc-light-danger"},
                new SelectListItem{Text="Mavi", Value="timeline-desc-light-primary",Selected=module.Data.ColorClass=="timeline-desc-light-primary"},
                new SelectListItem{Text="Mor", Value="timeline-desc-light-info",Selected=module.Data.ColorClass=="timeline-desc-light-info"},
                new SelectListItem{Text="Yeşil", Value="timeline-desc-light-success",Selected=module.Data.ColorClass=="timeline-desc-light-success"},
                new SelectListItem{Text="Sarı", Value="timeline-desc-light-warning",Selected=module.Data.ColorClass=="timeline-desc-light-warning"}
            };
            var classIconSelectList = new List<SelectListItem>
            {
                new SelectListItem{Text="Kod", Value="fas fa-code",Selected=module.Data.Icon=="fas fa-code"},
                new SelectListItem{Text="E-Mail", Value="flaticon-multimedia",Selected=module.Data.Icon=="flaticon-multimedia"},
                new SelectListItem{Text="Çöp", Value="flaticon2-rubbish-bin-delete-button",Selected=module.Data.Icon=="tflaticon2-rubbish-bin-delete-button"},
                new SelectListItem{Text="Chat", Value="flaticon2-chat",Selected=module.Data.Icon=="flaticon2-chat"},
                new SelectListItem{Text="Takvim", Value="flaticon-event-calendar-symbol",Selected=module.Data.Icon=="flaticon-event-calendar-symbol"},
                new SelectListItem{Text="Kullanıcı", Value="flaticon2-user",Selected=module.Data.Icon=="flaticon2-user"},
                new SelectListItem{Text="Ana Sayfa", Value="flaticon-home",Selected=module.Data.Icon=="flaticon-home"},
                new SelectListItem{Text="Projeler", Value="flaticon2-layers",Selected=module.Data.Icon=="flaticon2-layers"}
            };
            TempData["ClassTypeList"] = classTypeSelectList;
            TempData["ClassIconList"] = classIconSelectList;
            return View(module.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransactionType(UpdateTransactionTypeViewModels model)
        {

            if (!ModelState.IsValid)
            {
                var classTypeSelectList = new List<SelectListItem>
            {
              new SelectListItem{Text="Kırmızı", Value="timeline-desc-light-danger",Selected=model.ColorClass=="timeline-desc-light-danger"},
                new SelectListItem{Text="Mavi", Value="timeline-desc-light-primary",Selected=model.ColorClass=="timeline-desc-light-primary"},
                new SelectListItem{Text="Mor", Value="timeline-desc-light-info",Selected=model.ColorClass=="timeline-desc-light-info"},
                new SelectListItem{Text="Yeşil", Value="timeline-desc-light-success",Selected=model.ColorClass=="timeline-desc-light-success"},
                new SelectListItem{Text="Sarı", Value="timeline-desc-light-warning",Selected=model.ColorClass=="timeline-desc-light-warning"}
            };
                TempData["ClassTypeList"] = classTypeSelectList;
                return View(model);
            }
            var res = await _transactionTypeService.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                var classTypeSelectList = new List<SelectListItem>
            {
                new SelectListItem{Text="Kırmızı", Value="timeline-desc-light-danger",Selected=model.ColorClass=="timeline-desc-light-danger"},
                new SelectListItem{Text="Mavi", Value="timeline-desc-light-primary",Selected=model.ColorClass=="timeline-desc-light-primary"},
                new SelectListItem{Text="Mor", Value="timeline-desc-light-info",Selected=model.ColorClass=="timeline-desc-light-info"},
                new SelectListItem{Text="Yeşil", Value="timeline-desc-light-success",Selected=model.ColorClass=="timeline-desc-light-success"},
                new SelectListItem{Text="Sarı", Value="timeline-desc-light-warning",Selected=model.ColorClass=="timeline-desc-light-warning"}
            };
                TempData["ClassTypeList"] = classTypeSelectList;
                return View(model);
            }
            TempData["InfoMessage"] = $"{model.Name} isimli Transaction Tipi başarıyla güncellendi";
            return RedirectToAction("Index", "TransactionType");
        }
        [HttpPost]
        public async Task<IActionResult> ChangeTypeStatus(TransactionTypeChangeStatusViewModel model)
        {
            var tType = await _transactionTypeService.GetByIdAsync(model.Id);
            var res = await _transactionTypeService.ChangeStatusAsync(model);

            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = $"{tType.Data.Name} İsimli Transaction Tipi durumu {(model.Status == StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellendi";
            }
            else
            {
                TempData["errorMessage"] = $"{tType.Data.Name} İsimli Transaction Tipi durumu {(model.Status == StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellenirken Bir Sorunla Karşılaşıldı";
            }
            return RedirectToAction("Index", "TransactionType");
        }

    }
}

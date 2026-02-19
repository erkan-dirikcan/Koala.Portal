using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        private readonly IModuleService _moduleService;

        public RoleController(ILogger<UserAccountController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IRoleService roleService, IMapper mapper, IClaimService claimService, IModuleService moduleService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _roleService = roleService;
            _mapper = mapper;
            _claimService = claimService;
            _moduleService = moduleService;
        }

        public IActionResult Index()
        {
            var res = _roleService.GetRoleList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }

        //public IActionResult AddClaimToRole()
        //{
        //    return View();
        //}

        public async Task<IActionResult> UpdateRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "Role");
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Rol Bulunamadı";
                return RedirectToAction("Index", "Role");
            }
            return View(_mapper.Map<UpdateRoleViewModel>(role));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _roleService.Update(model, model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = $"{model.Name} isimli Rol başarıyla güncellendi";
            return RedirectToAction("Index", "Role");
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var res = await _roleService.AddAsync(model);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = "Rol başarıyla eklendi";
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public async Task<IActionResult> AddClaimToRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = Core.Dtos.Response.Fail(404, "Role Id Bilgisi Alınamadı", "Role Id Bilgisi Alınamadı", true);
                return View("Error");
            }
            var role = await _roleManager.FindByIdAsync(id);
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var claims = await _claimService.GetClaimToRoleList();
            var claimData = new List<SelectListDto<string>>();
            var modules=await _moduleService.GetModuleList();
            foreach (var claim in claims.Data)
            {
                var isSelected = roleClaims.Any(x => x.Value == claim.Name);

                claimData.Add(new SelectListDto<string>
                {
                    IsSelected = isSelected,
                    Key =$"{modules.Data.FirstOrDefault(x=>x.Id==claim.ModuleId).DisplayName} - {claim.DisplayName}",
                    Val = claim.Name
                });
            }
            claimData = claimData.OrderBy(x => x.Key).ToList();
            TempData["Claims"] = claimData.OrderBy(x=>x.Key).ToList();
            ViewData["RoleInfo"] = $"{role.Name}";
            var model = new AddClaimToRoleViewModel { RoleId = id, Claims = new List<string>() };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddClaimToRole(AddClaimToRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var claims = await _claimService.GetClaimToRoleList();
            var claimData = new List<SelectListDto<string>>();
            foreach (var claim in claims.Data)
            {
                var isSelected = roleClaims.Any(x => x.Value == claim.Name);
                claimData.Add(new SelectListDto<string>
                {
                    IsSelected = isSelected,
                    Key = claim.DisplayName,
                    Val = claim.Name
                });
            }
            claimData = claimData.OrderBy(x => x.Key).ToList();
            TempData["Claims"] = claimData;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var currentClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in currentClaims)
            {
                if (claim.Type == "Permission")
                {
                    await _roleManager.RemoveClaimAsync(role, claim);

                }
            }

            foreach (var item in model.Claims)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", item));
            }
            TempData.Clear();
            return RedirectToAction("Index");
        }

    }
}

using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.Service.Services
{
    public class RoleService: IRoleService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IClaimRepository _claimRepository;
        public RoleService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IClaimRepository claimRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _claimRepository = claimRepository;
        }

        public async Task<Response> AddAsync(CreateRoleViewModel model)
        {
            try
            {
                var role= _mapper.Map<AppRole>(model);
                role.Id=Tools.CreateGuidStr();
                var rolRes=await _roleManager.CreateAsync(role);
                //await _roleRepository.AddAsync(_mapper.Map<AppRole>(model));
                //await _unitOfWork.CommitAsyn();
                return Response.Success(200, "Rol başarıyla tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Role tanımlanırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }


        public async Task<Response> Delete(string id)
        {
            var role=_roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return Response<RoleListViewModel>.FailData(404, "Silinmek istenilen rol bilgilerine ulaşılamadı", $"{id} li rol bilgilerine ulaşılamadı.", true);

            }
            try
            {
                _roleManager.DeleteAsync(_mapper.Map<AppRole>(role));
                return Response.Success(200, "Rol başarıyla silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400,"Rol silinirken bir sorunla karşılaşıldı",ex.Message, false);
            }
            
        }

        public Response<List<RoleListViewModel>> GetRoleList()
        {
            var retVal = _roleManager.Roles;
            return Response<List<RoleListViewModel>>.SuccessData(200,"Rol Listesi Başarıyla Alındı",_mapper.Map<List<RoleListViewModel>>(retVal));
        }
        //var firms = await _repository.GetAllAsync();
        //    return Response<List<InfoCrmFirmViewModel>>.SuccessData(200, "Firma Listesi Başarıyla Alındı", _mapper.Map<List<InfoCrmFirmViewModel>>(firms));
        public async Task<Response<RoleListViewModel>> Update(UpdateRoleViewModel model, string id)
        {
            try
            {
                var role=await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return Response<RoleListViewModel>.FailData(404, "Güncellenmek istenilen rol bilgilerine ulaşılamadı", $"{id} li rol bilgilerine ulaşılamadı.", true);

                }
                if (model.Name!=role.Name)
                {
                    role.Name = model.Name;
                }
                if (model.Description!=role.Description)
                {
                    role.Description = model.Description;
                }
                var res=await _roleManager.UpdateAsync(role);
                return Response<RoleListViewModel>.SuccessData(200, "Rol başarıyla tanımlandı",_mapper.Map<RoleListViewModel>(role));
            }
            catch (Exception ex)
            {
                return Response<RoleListViewModel>.FailData(400, "Role tanımlanırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        //public async Task<Response> AddClaimToRole(AddClaimToRoleViewModel model)
        //{
        //    try
        //    {
        //        var role = await _roleManager.FindByIdAsync(model.RoleId);
        //        if (role == null)
        //        {
        //            return Response<RoleListViewModel>.FailData(404, "Yetki eklenmek istenilen rol bilgilerine ulaşılamadı", $"{model.RoleId} li rol bilgilerine ulaşılamadı.", true);
        //        }
        //        //var claims=await _claimRepository.GetAllAsync();
        //        //foreach (var claim in claims)
        //        //{
        //        //    var name=claim.Name;
        //        //}
        //        var res= await _roleManager.AddClaimAsync(role, new Claim(model.ClaimType, model.ClaimValue));
        //        if (res.Errors.Any())
        //        {
        //            return Response.Fail(400, "Role Eklenirken Bir Sorunla Karşılaşıldı", string.Join(", ", res.Errors), false);
        //        }
        //        return Response.Success(200, "Role yetki başarıyla eklendi");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Response.Fail(400, "Yetki tanımlanırken bir sornula karşılaşıldı", ex.Message, false);
        //    }
        //}

        public async Task<Response> RemoveClaimToRole(string id)
        {
            return Response.Success(200, "Yetki kaldırma başarıyla tanımlandı");   
        }

    }
}

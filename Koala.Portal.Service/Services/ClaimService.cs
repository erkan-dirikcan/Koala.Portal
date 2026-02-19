using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IMapper _mapper;
        private readonly IClaimRepository _claimRepository;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly RoleManager<AppRole> _roleManager;

        public ClaimService(IMapper mapper, IClaimRepository claimRepository, IUnitOfWork<AppDbContext> unitOfWork, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _claimRepository = claimRepository;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        public async Task<Response> AddAsync(CreateClaimViewModels model)
        {

            try
            {
                await _claimRepository.AddAsync(_mapper.Map<Claims>(model));
                return Response.Success(200, "Yetki Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yetki eklenirken bir sorunla karşılaşıldı", ex.Message, false);
            }

        }

        public async Task<Response> DeleteAsync(string id)
        {
            try
            {
                var claim = await _claimRepository.GetByIdAsyc(id);

                _claimRepository.Delete(claim);
                await _unitOfWork.CommitAsync();
                //TODO: Yetkinin atandığı bütün gurplardan çıkart
                //d14e78e1-e856-11ee-a5b6-704d7b71982b
                var rolles = await _roleManager.Roles.ToListAsync();
                foreach (var role in rolles)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    if (roleClaims.Any(x => x.Value == claim.Name))
                    {
                        var rClaim = roleClaims.First(x => x.Value == claim.Name);
                       var res=await _roleManager.RemoveClaimAsync(role, rClaim);
                        
                    }
                }

                return Response.Success(200, "Claim başarıyla silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Claim silinirken bir sorunla karşılaşıldı", ex.Message, false);
            }

        }

        public async Task<Response<IEnumerable<ClaimListViewModels>>> GetAllAsync()
        {
            try
            {
                var items = await _claimRepository.GetAllAsync();
                return Response<IEnumerable<ClaimListViewModels>>.SuccessData(200, "Claim başarıyla alındı", _mapper.Map<List<ClaimListViewModels>>(items));
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<ClaimListViewModels>>.FailData(400, "Claim listesi alınamadı", ex.Message, false);
            }
        }

        public async Task<Response<ClaimListForModuleViewModels>> GetByIdAsync(string id)
        {
            try
            {
                var claim = await _claimRepository.GetByIdAsyc(id);
                return claim == null ?
                    Response<ClaimListForModuleViewModels>.FailData(404, "Görüntülenmek istenilen yetki bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen yetki bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<ClaimListForModuleViewModels>.SuccessData(200, "Yetki Bilgisi Başarıyla Alındı", _mapper.Map<ClaimListForModuleViewModels>(claim));
            }
            catch (Exception ex)
            {
                return Response<ClaimListForModuleViewModels>.FailData(400, "Yetki Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<UpdateClaimViewModels>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var claim = await _claimRepository.GetByIdAsyc(id);
                return claim == null ?
                    Response<UpdateClaimViewModels>.FailData(404, "Görüntülenmek istenilen yetki bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen yetki bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<UpdateClaimViewModels>.SuccessData(200, "Yetki Bilgisi Başarıyla Alındı", _mapper.Map<UpdateClaimViewModels>(claim));
            }
            catch (Exception ex)
            {
                return Response<UpdateClaimViewModels>.FailData(400, "Yetki Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<IEnumerable<ClaimListForModuleViewModels>>> GetClaimToModuleList(string moduleId)
        {
            try
            {
                var items = await _claimRepository.Where(x => x.ModuleId == moduleId).ToListAsync();
                return Response<IEnumerable<ClaimListForModuleViewModels>>.SuccessData(200, "Claim başarıyla alındı", _mapper.Map<List<ClaimListForModuleViewModels>>(items));
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<ClaimListForModuleViewModels>>.FailData(400, "Claim Listesi alınamadı", ex.Message, false);
            }
        }

        public async Task<Response<IEnumerable<ClaimListForRoleViewModels>>> GetClaimToRoleList()
        {
            try
            {
                var items = await _claimRepository.GetAllAsync();
                return Response<IEnumerable<ClaimListForRoleViewModels>>.SuccessData(200, "Claim başarıyla alındı", _mapper.Map<List<ClaimListForRoleViewModels>>(items));
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<ClaimListForRoleViewModels>>.FailData(400, "Claim listesi alınamadı", ex.Message, false);
            }
        }


        public async Task<Response> UpdateAsync(UpdateClaimViewModels model, string id)
        {
            try
            {
                var entity = _mapper.Map<Claims>(model);
                var dataEntity = await _claimRepository.GetByIdAsyc(id);
                if (dataEntity == null)
                {
                    return Response.Fail(404, "Güncellenmek İstenen Yetkinin Bilgilerine Ulaşılamadı", "Güncellenmek İstenen Yetkinin Bilgilerine Ulaşılamadı - Id:" + id, true);
                }
                dataEntity = entity;
                await _claimRepository.UpdateAsync(dataEntity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Modül Yetkisi Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Modül Yetkisi Güncellenirken Bir Sorunla KArşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<IEnumerable<ClaimListForUserViewModels>>> GetClaimToUserList(List<string> claims)
        {
            try
            {
                var allClaims = (await _claimRepository.GetAllAsync()).Where(x => claims.All(y => y == x.Name)).ToList();
                //var unSelected=allClaims.Select(x=>x).Except(claims);

                return Response<IEnumerable<ClaimListForUserViewModels>>.SuccessData(200, "Claim başarıyla alındı", _mapper.Map<List<ClaimListForUserViewModels>>(claims));
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<ClaimListForUserViewModels>>.FailData(400, "Claim listesi alınamadı", ex.Message, false);
            }
        }
    }
}

using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Service.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _repository;
    private readonly IClaimRepository _claimRepository;

   
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    public ModuleService(IUnitOfWork<AppDbContext> unitOfWork, IBaseRepository<Module> baseRepository,IModuleRepository repository,IMapper mapper, IClaimRepository claimRepository) 
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _claimRepository = claimRepository;
    }

    public async Task<Response> AddClaimToModule(CreateClaimViewModels claim)
    {
        try
        {
            var module = await _repository.GetByIdAsyc(claim.ModuleId);
            if (module == null)
            {
                return Response.Fail(404, "Yetki Eklenmek İstenilen Module Bilgisine Ulaşılamadı", "Yetki Eklenmek İstenilen Module Bilgisine Ulaşılamadı", true);
            }
            var clm = new Claims
            {
                Name = $"{module.Name}.{claim.Name}",
                Description = claim.Description,
                DisplayName = claim.DisplayName,
                ModuleId = claim.ModuleId
            };
            await _claimRepository.AddAsync(_mapper.Map<Claims>(clm));
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Modüle Yetki Başarıyla Aklendi");
        }
        catch (Exception ex)
        { 
            return Response.Fail(400, "Modüle Yetki Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public bool any()
    {
        return _repository.any();
    }

    public Response<List<ClaimListForModuleViewModels>> GetClaimToModule(string id)
    {
        try
        {
            var res = _claimRepository.Where(x=>x.ModuleId ==x.ModuleId);
            var ms = new List<ClaimListForModuleViewModels>();
            return Response<List<ClaimListForModuleViewModels>>.SuccessData(200,"Yetki Listesi Başarıyla Alındı",ms);
        }
        catch (Exception ex)
        {
            return Response<List<ClaimListForModuleViewModels>>.FailData(400, "Yetki Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
    public Response<List<SelectListItem>> GetModuleSelectList(string selected ="")
    {
        try
        {
           var res= _repository.Where(x => x.Status == StatusEnum.Active).Select(x => new SelectListItem { Text = x.DisplayName, Value = x.Id, Selected = x.Id == selected }).ToList();
            return Response<List<SelectListItem>>.SuccessData(200, "Modül Listesi Başarıyla Alındı", res);
        }
        catch (Exception ex)
        {
            return Response<List<SelectListItem>>.FailData(400, "Modül Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }

    }

    public async Task<Response<List<GetModuleListViewModels>>> GetModuleList()
    {
        var res =await _repository.GetModuleList();
        var retVal = _mapper.Map<List<GetModuleListViewModels>>(res);
        return Response<List<GetModuleListViewModels>>.SuccessData(200, "Modül Listesi Başarıyla Alındı", retVal);
    }

    public async Task<Response> AddAsync(CreateModuleListViewModels model)
    {
        try
        {
            await _repository.AddAsync(_mapper.Map<Module>(model));
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Modul Başarıyla Tanımlandı");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Modül Tanımlanırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response> Delete(string id)
    {
       var module =  _repository.GetByIdAsyc(id);
        if (module ==null)
        {
            return Response<GetModuleListViewModels>.FailData(404, "Silinmek istenilen modül bilgilerine ulaşılamadı", $"{id} li modül bilgilerine ulaşılamadı", true);
        }
        try
        {
            _repository.Delete(_mapper.Map<Module>(module));
            return Response.Success(200, "Modül başarıyla silindi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Modül silinirken bir sorunla karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<GetModuleListViewModels>> UpdateAsync(UpdateModuleViewModels model, string id)
    {
        try
        {
            var module = await _repository.GetByIdAsyc(id);
            if (module == null)
            {
                return Response<GetModuleListViewModels>.FailData(404, "Güncellenmek istenilen model bilgilerine ulaşılamadı", $"{id} li modül bilgilerine ulaşılamadı", true);
            }
            if (model.Name!=module.Name)
            {
                module.Name = model.Name;
            }
            if (model.DisplayName != module.DisplayName)
            {
                module.DisplayName = model.DisplayName;
            }
            if (model.Description != module.Description)
            {
                module.Description = model.Description;
            }
            var res =  _repository.UpdateAsync(module);
            await _unitOfWork.CommitAsync();
            return Response<GetModuleListViewModels>.SuccessData(200,"Modül Başarıyla Güncellendi",_mapper.Map<GetModuleListViewModels>(module));
        }
        catch (Exception ex)
        {
            return Response<GetModuleListViewModels>.FailData(400,"Modül Güncellenirken Bir Sorunla Karşılaşıldı",ex.Message, false);
        }
    }

    public async Task<Response<GetModuleListViewModels>> GetByIdAsync(string id)
    {
        try
        {
            //069f9c87-dbb5-11ee-a5b1-704d7b71982b
            var module =await _repository.GetByIdAsyc(id);
            return module == null ?
                Response<GetModuleListViewModels>.FailData(404, "Modül Bilgileri Alınırken Bir Sorunla Kaarşılaşıldı", "Bu Id Bilgisine Ait Modül Bilgisi Bulunmuyor", true) :
                Response<GetModuleListViewModels>.SuccessData(200, "Modül Bilgileri Başarıyla Alındı", _mapper.Map<GetModuleListViewModels>(module));
        }
        catch (Exception ex)
        {
            return Response<GetModuleListViewModels>.FailData(400, "Modül Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<UpdateModuleViewModels>> GetUpdateInfoAsync(string id)
    {
        try
        {
            var module = await _repository.GetByIdAsyc(id);
            return module == null ?
                Response<UpdateModuleViewModels>.FailData(404, "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                Response<UpdateModuleViewModels>.SuccessData(200, "Firmaa Bilgisi Başarıyla Alındı", _mapper.Map<UpdateModuleViewModels>(module));
        }
        catch (Exception ex)
        {
            return Response<UpdateModuleViewModels>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
}
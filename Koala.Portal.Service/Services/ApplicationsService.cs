using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services;

public class ApplicationsService : IApplicationsService
{
    private readonly IApplicationsRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;

    public ApplicationsService(IApplicationsRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> AddAsync(CreateApplicationsViewModel model)
    {
        try
        {
            var entity = _mapper.Map<Applications>(model);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Uygulama Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "", ex.Message, false);
        }
    }

    public async Task<Response<List<ApplicationsListViewModel>>> GetApplicationList()
    {
        try
        {
            var res = _repository.Where(x => x.Status != StatusEnum.Deleted);
            var entity = res.ToList();
            var retVal = _mapper.Map<List<ApplicationsListViewModel>>(res);
            return Response<List<ApplicationsListViewModel>>.SuccessData(200, "Uygulama Listesi Başarıyla Alındı", retVal);

        }
        catch (Exception ex)
        {
            return Response<List<ApplicationsListViewModel>>.FailData(400, "Uygulama Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response> UpdateAsync(UpdateApplicationsViewModel model)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return Response.Fail(404, "Güncellenmek İstenen Uygulama Bilgilerine Ulaşılamadı",
                    "Güncellenmek İstenilen Uygulama Bilgilerine Ulaşılamadı.", true);
            }

            entity.ExpDate = model.ExpDate;
            if (model.ExpDate>DateTime.Now)
            {
                entity.Status = StatusEnum.Active;
            }
            else
            {
                entity.Status = StatusEnum.Expiration;
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.AppId = model.AppId;
            entity.ExpDate=model.ExpDate;
            entity.MaxUserCount = model.MaxUserCount;
            entity.IsMultiModuleApplication=model.IsMultiModuleApplication;
            entity.IsPackageApplication=model.IsPackageApplication;
            entity.ApplicationSecretKey = model.ApplicationSecretKey;

            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Uygulama Bilgileri Başarıyla Güncellendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "", ex.Message, false);
        }
    }

    public async Task<Response> ChangeStatusAsync(ApplicationsChangeStatusViewModel model)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return Response.Fail(400, "Uygulama Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", "Durumu Değiştirilecek Olan Uygulama Bilgilerine Ulaşılamadı.", true);
            }

            entity.Status = model.Status;
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Uygulama Durumu Başarıyla Güncellendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Uygulama Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<DetailApplicationsViewModel>> GetByIdAsync(string id)
    {
        try
        {
            var res =await _repository.GetByIdAsync(id);
            var retVal = _mapper.Map<DetailApplicationsViewModel>(res);
            return Response<DetailApplicationsViewModel>.SuccessData(200, "uygualam Bilgileri Başarıyla Alındı",retVal);

        }
        catch (Exception ex)
        {
            return Response<DetailApplicationsViewModel>.FailData(400, "", ex.Message, false);
        }
    }

    public async Task<Response<DetailApplicationsViewModel>> GetByGuidAsync(string applicationGuid)
    {
        try
        {
            var res = await _repository.GetByGuidAsync(applicationGuid);
            return Response<DetailApplicationsViewModel>.SuccessData(200, "uygualam Bilgileri Başarıyla Alındı", _mapper.Map<DetailApplicationsViewModel>(res));

        }
        catch (Exception ex)
        {
            return Response<DetailApplicationsViewModel>.FailData(400, "", ex.Message, false);
        }
    }

    public async Task<Response<ApplicationsAddExpDateViewModel>> GetExpDateInfoAsync(string id)
    {
        try
        {
            var res =await _repository.GetByIdAsync(id);
            if (res == null)
            {
                return Response<ApplicationsAddExpDateViewModel>.FailData(404, "Tarihi Güncellenmek İstenilen Uygulamanın Bilgilerine Ulaşılamadı.", "Tarihi Güncellenmek İstenilen Uygulamanın Bilgilerine Ulaşılamadı.", true);
            }

            var retVal = _mapper.Map<ApplicationsAddExpDateViewModel>(res);
            return Response<ApplicationsAddExpDateViewModel>.SuccessData(200, "Tarihi Güncwelenecek Olan Uygulama Bilgileri Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<ApplicationsAddExpDateViewModel>.FailData(400, "Tarihi Güncellenmek İstenilen Uygulamanın Bilgilerine Ulaşılamadı", ex.Message, false);
        }
    }

    public async Task<Response> UpdateExpDateInfoAsync(ApplicationsAddExpDateViewModel model)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return Response.Fail(404, "Tarih Bilgisi Güncellenmek İstenilenilen Uygulama Bilgilerine Ulaşılamadı", "Tarih Bilgisi Güncellenmek İstenilenilen Uygulama Bilgilerine Ulaşılamadı", true);
            }
            entity.ExpDate = model.ExpDate;
            entity.Status = model.ExpDate > DateTime.Now ? StatusEnum.Active : StatusEnum.Expiration;
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, $"{entity.Name} İsimli Uygulamanın Son Kullanım Tarihi {model.ExpDate.ToString("dd-MM-yyyy HH:mm")} Olarak Güncellenmiştir");
        }
        catch (Exception ex)
        {
            return Response.Fail(404, "Tarih Bilgisi Güncellenmek İstenilenilen Uygulama Bilgilerine Ulaşılamadı", ex.Message, true);
        }

    }

    public async Task<Response<UpdateApplicationsViewModel>> GetUpdateDataAsync(string id)
    {
        try
        {
            var res =await _repository.GetByIdAsync(id);
            return Response<UpdateApplicationsViewModel>.SuccessData(200, "uygualam Bilgileri Başarıyla Alındı", _mapper.Map<UpdateApplicationsViewModel>(res));

        }
        catch (Exception ex)
        {
            return Response<UpdateApplicationsViewModel>.FailData(400, "", ex.Message, false);
        }
    }

    public async Task<Response<List<ApplicationsListViewModel>>> GetApplicationListForModule()
    {
        try
        {
            var res = _repository.Where(x => x.Status != StatusEnum.Deleted && x.IsMultiModuleApplication);
            var entity = res.ToList();
            var retVal = _mapper.Map<List<ApplicationsListViewModel>>(res);
            return Response<List<ApplicationsListViewModel>>.SuccessData(200, "Uygulama Listesi Başarıyla Alındı", retVal);

        }
        catch (Exception ex)
        {
            return Response<List<ApplicationsListViewModel>>.FailData(400, "Uygulama Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<string>> EncryptData(string data, string applicationId)
    {
        try
        {
            var app = await _repository.GetByIdAsync(applicationId);
            if (app == null)
            {
                return Response<string>.FailData(404, "Uygulama Bilgilerine Ulaşılamadı", "Uygulama Bilgilerine Ulaşılamadı", true);
            }
            var encryptedData = data.Encryption(app.ApplicationSecretKey);
            return Response<string>.SuccessData(200, "Veri Başarıyla Şifrelendi", encryptedData);
        }
        catch (Exception ex)
        {
            return Response<string>.FailData(400, "Veri Şifrelenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
    public async Task<Response<string>> DecryptData(string data, string applicationId)
    {
        try
        {
            var app = await _repository.GetByIdAsync(applicationId);
            if (app == null)
            {
                return Response<string>.FailData(404, "Uygulama Bilgilerine Ulaşılamadı", "Uygulama Bilgilerine Ulaşılamadı", true);
            }
            var decryptedData = data.Decryption(app.ApplicationSecretKey);
            return Response<string>.SuccessData(200, "Veri Başarıyla Şifresi Çözüldü", decryptedData);
        }
        catch (Exception ex)
        {
            return Response<string>.FailData(400, "Veri Şifresi Çözülürken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

}
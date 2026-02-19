using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Newtonsoft.Json;

namespace Koala.Portal.Service.Services;

public class ApplicationModulesService : IApplicationModulesService
{
    private readonly IApplicationModulesRepository _repository;
    private readonly IApplicationsRepository _applicationsRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;

    public ApplicationModulesService(IApplicationModulesRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork, IApplicationsRepository applicationsRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _applicationsRepository = applicationsRepository;
    }

    public async Task<Response<List<ApplicationModulesListViewModel>>> GetApplicationModulesListAsync(string applicationId)
    {
        try
        {
            var res = await _repository.GetApplicationModulesListAsync(applicationId);
            var retVal = _mapper.Map<List<ApplicationModulesListViewModel>>(res);
            return Response<List<ApplicationModulesListViewModel>>.SuccessData(200,
                "Uygulama Modul Listesi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<List<ApplicationModulesListViewModel>>.FailData(400, "Uygulama Modül Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response> CreateModuleForApplicationAsync(CreateApplicationModulesViewModel model)
    {
        try
        {
            await _repository.CreateModuleForApplicationAsync(_mapper.Map<ApplicationModules>(model));
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Modül uygulamaya başarıyla eklendi");

        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Uygulama Modülü Eklenirken Bir Soruınla Karşılaşıldı", ex.Message, false);
        }
    }

    public Response UpdateModuleForApplication(ApplicationModulesListViewModel model)
    {
        try
        {
            var entity = _repository.GetApplicationModulesAsync(model.Id).Result;
            if (entity == null)
            {
                return Response.Fail(404, "Güncellenmek istenen modül bilgilerine ulaşılamadı", $"{model.Id} kimlik bilgilerine sahip modül bilgilerine ulaşılamadı", true);
            }
            entity.Name = model.Name;
            entity.Desctiption = model.Desctiption;
            _repository.UpdateModuleForApplication(entity);
            _unitOfWork.Commit();
            return Response.Success(200, $"{model.Id} kimlikl bilgisine sahip modül başarıyla güncellendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Modül Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }



    public async Task<Response<List<ApplicationModulesDecryptedViewModel?>>> DeCryptApplicationModulesJsonAsync(ApplicationModulesDecrypJsonViewModel model)
    {
        try
        {
            var application = await _applicationsRepository.GetByIdAsync(model.ApplicationId);
            if (application == null)
            {
                return Response<List<ApplicationModulesDecryptedViewModel?>>.FailData(404,"Modül Uygulamasına ait bilgilere ulaşılamadı",$"{model.ApplicationId} kimlik bilgisine sahip uygulama bilgilerine ulaşılamadı",true);
            }
            var decriptedText = model.CryptedText.Decryption(application.ApplicationSecretKey);
            var retVal = JsonConvert.DeserializeObject<List<ApplicationModulesDecryptedViewModel?>>(decriptedText);
            return Response<List<ApplicationModulesDecryptedViewModel?>>.SuccessData(200,"Uygulama Modül Listesi Başarıyla Alındı",retVal);
        }
        catch (Exception ex)
        {
            return Response<List<ApplicationModulesDecryptedViewModel?>>.FailData(400, "Şifre açılırken bir sorunla karşılaşıldı", ex.Message, false);
        }
    }
}
using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Koala.Portal.Core.Helpers;
using Newtonsoft.Json;

namespace Koala.Portal.Service.Services;

public class ApplicationLicencesService : IApplicationLicencesService
{
    private readonly IApplicationLicencesRepository _repository;
    private readonly IUnitOfWork<AppDbContext> _unitOfWorks;
    private readonly IApplicationsRepository _applicationsRepository;
    private readonly IMapper _mapper;
    public ApplicationLicencesService(IApplicationLicencesRepository repository, IUnitOfWork<AppDbContext> unitOfWorks, IApplicationsRepository applicationsRepository, IMapper mapper)
    {
        _repository = repository;
        _unitOfWorks = unitOfWorks;
        _applicationsRepository = applicationsRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ApplicationLicencesListViewModel>>> GetApplicationLicencesAsync(string applicationGuid)
    {
        try
        {
            var res = _repository.GetApplicationLicencesAsync(applicationGuid);
            return Response<IEnumerable<ApplicationLicencesListViewModel>>.SuccessData(200, "Uygulama Lisans Listesi Başarıyla Alındı", _mapper.Map<List<ApplicationLicencesListViewModel>>(res));
        }
        catch (Exception ex)
        {
            return Response<IEnumerable<ApplicationLicencesListViewModel>>.FailData(400,
                "Uygulama Lisans Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
    public async Task<Response<ApiLicenceResultViewModel>> AddLicenceRequestAsync(ApplicationLicencesRequestViewModel model)
    {
        try
        {
            var application = await _applicationsRepository.GetByGuidAsync(model.ApplicationGuid);//await _repository.GetApplicationLicencesAsync(model.ApplicationGuid);
            var licences = application.ApplicationLicences.ToList();
            var licenceCount = licences.Count(x => x.Status == StatusEnum.Active);
            if (application.MaxUserCount > 0 && licenceCount >= application.MaxUserCount)
            {
                return Response<ApiLicenceResultViewModel>.FailData(400, "Bu uygulama için maximum kullanıcı sayısına ulaştınız, Lütfen Sistem bilgisayar ile iletişime geçin.", "Maximum Kullanıcı Sayısı", true);
            }
            else
            {

                if (!licences.Any(x => x.CpuId == model.CpuId && x.MainboardId == model.MainboardId && x.PcName == model.PcName))
                {
                    var addModel = _mapper.Map<ApplicationLicences>(model);
                    addModel.ApplicationId = application.Id;
                    addModel.ApplicationName = application.Name;
                    addModel.Status = StatusEnum.Pasive;
                    addModel.licenceStatus= ApplicationLicenceStatusEnum.AcceptWaiting;
                    addModel.CreateDate = DateTime.Now;
                    addModel.LicenceCode = "";

                    await _repository.AddLicenceRequestAsync(addModel);
                    await _unitOfWorks.CommitAsync();
                    var retVal = await _repository.GetById(addModel.Id);
                    var decCode = retVal.LicenceCode ?? "";

                    var codeObject = new LicanceCryptionJosonViewModel();
                    if (!string.IsNullOrEmpty(decCode))
                    {
                        var codeJson = LicenceCryption.Encryption(decCode, application.ApplicationSecretKey);
                        codeObject = JsonConvert.DeserializeObject<LicanceCryptionJosonViewModel>(codeJson);
                    }
                    return Response<ApiLicenceResultViewModel>.SuccessData(201,
                        "Lisans Talebiniz Başarıyla Eklendi",
                        new ApiLicenceResultViewModel
                        {
                            Id = retVal.Id,
                            Approved = retVal.Status == StatusEnum.Active,
                            ExpDate = codeObject.ExpDate,
                            IsActive = retVal.Status == StatusEnum.Active,
                            Code = decCode
                        });

                }
                else
                {
                    var licence = licences.FirstOrDefault(x => x.CpuId == model.CpuId && x.MainboardId == model.MainboardId && x.PcName == model.PcName);
                    //var retVal = await _repository.(application.Id);
                    //if (retVal == null)
                    //{

                    //}
                    var decCode = licence.LicenceCode ?? "";

                    var codeObject = new LicanceCryptionJosonViewModel();
                    if (!string.IsNullOrEmpty(decCode))
                    {
                        var codeJson = LicenceCryption.Encryption(decCode, application.ApplicationSecretKey);
                        codeObject = JsonConvert.DeserializeObject<LicanceCryptionJosonViewModel>(codeJson);
                    }
                    return Response<ApiLicenceResultViewModel>.SuccessData(200,
                        "Lisans Talebiniz Başarıyla Eklendi",
                        new ApiLicenceResultViewModel
                        {
                            Id = licence.Id,
                            Approved = licence.Status == StatusEnum.Active,
                            ExpDate = codeObject.ExpDate,
                            IsActive = licence.Status == StatusEnum.Active,
                            Code = decCode
                        });
                    //return Response<ApiLicenceResultViewModel>.SuccessData(200, "Lisans Talebiniz Zaten Mevcut.");
                }
            }
        }
        catch (Exception ex)
        {
            return Response<ApiLicenceResultViewModel>.FailData(400, "Lisans Talebi Oluşturulurken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
    public async Task<Response<List<ApplicationLicencesListViewModel>>> GetWaitingLicences()
    {
        try
        {
            var res = await _repository.GetWaitingLicences();
            var retVal = _mapper.Map<List<ApplicationLicencesListViewModel>>(res);

            return Response<List<ApplicationLicencesListViewModel>>.SuccessData(200, "Onay Bekleyen Lisans Lisatesi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<List<ApplicationLicencesListViewModel>>.FailData(400,
                "Onay Bekleyen Lisans Talepleri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
    public async Task<Response> ConfirmLicence(ConfirmApplicationLicencesViewModel model)
    {
        try
        {
            var entity = await _repository.GetById(model.Id);
            var application = await _applicationsRepository.GetByIdAsync(entity.ApplicationId);

            var jsonModel = new LicanceCryptionJosonViewModel
            {
                Id = entity.Id,
                ApplicationId = entity.ApplicationId,
                ApplicationName = application.Name,
                CpuId = entity.CpuId,
                ExpDate = application.ExpDate,
                IsActive = model.Status == StatusEnum.Active,
                MainboardId = entity.MainboardId,
                PcName = entity.PcName,
                ApplicationLicenceStatus = model.ApplicationLicenceStatus
            };
            entity.Status = model.Status;
            entity.LicenceCode = LicenceCryption.Encryption(JsonConvert.SerializeObject(jsonModel), application.ApplicationSecretKey);
            entity.ApprovedByUserId = model.ApprovedByUserId;
            entity.licenceStatus = model.ApplicationLicenceStatus;


            await _repository.UpdateLicenceRequestAsync(entity);
            await _unitOfWorks.CommitAsync();
            return Response.Success(200, entity.Status == StatusEnum.Active ?
                                                         "Lisans Başarıyla Onaylandı" :
                                                         "Lisans Başarıyla Reddedildi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Lisans Onaylanırken Bir Sorunla Karşılaşıldı", ex.Message, false);

        }
    }
    public async Task<Response<DetailApplicationLicencesViewModels>> GetLiceceByIdAsync(string id)
    {
        try
        {
            var entity = await _repository.GetById(id);
            return entity == null ?
                Response<DetailApplicationLicencesViewModels>.FailData(404, "Lisans Bilgilerine Ulaşılamadı, Lütfen Yeni Lisans Talebi Oluşturun.", "Lisans Bilgilerine Ulaşılamadı, Lütfen Yeni Lisans Talebi Oluşturun.", true) :
                Response<DetailApplicationLicencesViewModels>.SuccessData(200, "Lisans Bilgileri Başarıyla Alındı", _mapper.Map<DetailApplicationLicencesViewModels>(entity));
        }
        catch (Exception ex)
        {
            return Response<DetailApplicationLicencesViewModels>.FailData(404, "Lisans Bilgilerine Ulaşılamadı, Lütfen Yeni Lisans Talebi Oluşturun.", ex.Message, true);
        }
    }


    public async Task<Response<LicanceCryptionJosonViewModel>> CheckApplicationLicence(ApplicationCheckLicenceViewModel model)
    {
        var application = await _applicationsRepository.GetByGuidAsync(model.ApplicationId);
        if (application == null)
        {
            return Response<LicanceCryptionJosonViewModel>.FailData(404, "Uygulamanız Henüz Kullanıma Açılmamış, Lütfen Sistem Bilgisayar İle İletişime Geçin.", "Uygulamanız Henüz Kullanıma Açılmamış", false);
        }

        var licenceInfo = await _repository.FindMacLicence(model);
        if (licenceInfo == null)
        {
            return Response<LicanceCryptionJosonViewModel>.FailData(404, "Lisans Kaydınız Henüz Gerçekleştirilmemiş", "Lisans Kaydınız Henüz Gerçekleştirilmemiş", false);
        }
        if (string.IsNullOrEmpty(licenceInfo.LicenceCode))
        {
            return Response<LicanceCryptionJosonViewModel>.FailData(204, "Lisansınız Henüz Onaylanmamış, Lütfen Sistem Bilgisayar İle İletişime Geçin.", "Lisansınız Henüz Onaylanmamış", false);
        }
        else
        {
            var licenceCode = LicenceCryption.Decryption(licenceInfo.LicenceCode, application.ApplicationSecretKey);
            var licence = JsonConvert.DeserializeObject<LicanceCryptionJosonViewModel>(licenceCode);
            if (licence.ExpDate < DateTime.Now)
            {
                return Response<LicanceCryptionJosonViewModel>.FailData(410, "Lisansınızın Kullanım Süresi Dolmuş, Lütfen Sistem Bilgisayarla İLetişime Geçin.", "Lisansınızın Kullanım Süresi Dolmuş", false);
            }
            else if (!licence.IsActive)
            {
                return Response<LicanceCryptionJosonViewModel>.FailData(423, "Lisansınız Kullanıma Kapatılmış, Lütfen Sistem Bilgisayarla İLetişime Geçin.", "Lisansınız Kullanıma Kapatılmış", false);
            }
            else
            {
                return Response<LicanceCryptionJosonViewModel>.SuccessData(200, "Lisans Bilgileri Başarıyla Alındı", licence);
            }
        }


    }

    public async Task<Response<ApplicationLicenceCountViewModel>> GetApplicationLicanceCount(string id)
    {
        try
        {
            var licance = await _repository.GetById(id);
            var appLicances = await _repository.GetApplicationLicencesAsync(licance.Applications.AppId);
            var activeCount = appLicances.Count(x => x.Status == StatusEnum.Active);
            return Response<ApplicationLicenceCountViewModel>.SuccessData(200, "Uygulama Lisans Sayıları Başarıyla Alındı.", new ApplicationLicenceCountViewModel { Id = licance.Id, ActiveLicanceCount = activeCount, MaxLicanceCount = licance.Applications.MaxUserCount });
        }
        catch (Exception ex)
        {
            return Response<ApplicationLicenceCountViewModel>.FailData(400, "Uygulama Lisans Sayıları Alınırken Bir Sorunla Karşılaşıldı.", ex.Message, false);
        }

    }

    //public async Task<Response<ApiLicenceResultViewModel>>
}
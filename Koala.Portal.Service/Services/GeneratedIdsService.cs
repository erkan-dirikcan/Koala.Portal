using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class GeneratedIdsService : IGeneratedIdsService
    {
        private readonly IGeneratedIdsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public GeneratedIdsService(IGeneratedIdsRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(CreateGeneratedIdsViewModel model)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<GeneratedIds>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yeni Bir Kimlik Başarıyla Tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yeni Bir Kimlik Oluşturulurken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<GetGeneratedIdsListViewModel>> GetByIdAsync(string id)
        {
            try
            {
                var gId = await _repository.GetByIdAsync(id);
                return gId == null ?
                    Response<GetGeneratedIdsListViewModel>.FailData(404, "Görüntülenmek istenilen Kimlik Bilgilerine ulaşılamadı. Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Kimlik Bilgilerine ulaşılamadı. Lütfen senkronizasyon yapıp tekrar deneyin.",true) :
                    Response<GetGeneratedIdsListViewModel>.SuccessData(200,"Kimlik Bilgisi Başarıyla Alındı",_mapper.Map<GetGeneratedIdsListViewModel>(gId));
            }
            catch (Exception ex)
            {
                return Response<GetGeneratedIdsListViewModel>.FailData(400, "Kimlik Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<GetGeneratedIdsListViewModel>>> GetGeneratedIdsList()
        {
            var res = await _repository.GetGeneratedIdsList();
            var retVal = _mapper.Map<List<GetGeneratedIdsListViewModel>>(res);
            return Response<List<GetGeneratedIdsListViewModel>>.SuccessData(200, "Kimlik Bilgisi Listesi Başarıyla Alındı", retVal);
        }

        public async Task<Response<string>> GetNextNumber(string moduleId)
        {
            try
            {
                var gId = await _repository.GetByModuleIdAsync(moduleId);
                if (gId == null)
                {
                    return Response<string>.FailData(404, "Güncellenmek İstenilen Kimlik Bilgilerine Ulaşılamadı", $"{moduleId} li Kimlik Bilgilerine Ulaşılamadı", true);
                }
                var format = "D" + gId.Digit;
                var retVal = $"{gId.Prefix}-{gId.LastNumber.ToString(format)}";

                gId.LastNumber++;
                var res = _repository.UpdateAsync(gId);
                await _unitOfWork.CommitAsync();

                return Response<string>.SuccessData(200, "Kimlik Bilgisi Başarıyla Güncellendi", retVal);
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400,"Kimlik Bilgisi Güncellenirken Bir Hatayla Karşılaşıldı", ex.Message, false);

            }
        }

        public async Task<Response<UpdateGeneratedIdsViewModel>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var gId = await _repository.GetByIdAsync(id);
                return gId == null ?
                    Response<UpdateGeneratedIdsViewModel>.FailData(404, "Görüntülenmek istenilen Kimlik Bilgilerine ulaşulamadı. Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Kimlik Bilgilerine ulaşulamadı. Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<UpdateGeneratedIdsViewModel>.SuccessData(200, "Kimlik Bilgileri Başarıyla Alındı", _mapper.Map<UpdateGeneratedIdsViewModel>(gId));
            }
            catch (Exception ex)
            {
                return Response<UpdateGeneratedIdsViewModel>.FailData(400,"Kimlik Bilgisi Güncellenirken Bir Sorunla Karşılaşıldı",ex.Message, false);
            }
        }

        public async Task<Response<GetGeneratedIdsListViewModel>> UpdateAsync(UpdateGeneratedIdsViewModel model, string id)
        {
            try
            {
                var gId = await _repository.GetByIdAsync(id);
                if (gId == null)
                {
                    return Response<GetGeneratedIdsListViewModel>.FailData(404, "Güncellenmek istenilen Kimlik Bilgilerine Ulaşılamadı", $"{id} li Kimlik Bilgilerine ulaşılamadı", true);
                }
                gId.Prefix = model.Prefix;
                gId.LastNumber= model.LastNumber;
                gId.StartNumber = model.StartNumber;
                gId.Digit = model.Digit;
                gId.ModuleId = model.ModuleId;

                var res = _repository.UpdateAsync(gId);
                await _unitOfWork.CommitAsync();
                return Response<GetGeneratedIdsListViewModel>.SuccessData(200,"Kimlik Bilgisi Başarıyla Güncellendi",_mapper.Map<GetGeneratedIdsListViewModel>(gId));
            }
            catch (Exception ex)
            {
                return Response<GetGeneratedIdsListViewModel>.FailData(400, "Kimlik Bilgisi Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

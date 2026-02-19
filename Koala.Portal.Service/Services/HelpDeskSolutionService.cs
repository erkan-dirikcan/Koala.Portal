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
    public class HelpDeskSolutionService : IHelpDeskSolutionService
    {
        private readonly IHelpDeskSolutionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IGeneratedIdsService _generatedIdsService;
        private const string ModuleId = "069f9c88-dbb5-11ee-a5b1-704d7b71982b";
        public HelpDeskSolutionService(IHelpDeskSolutionRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork, IGeneratedIdsService generatedIdsService)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _generatedIdsService = generatedIdsService;
        }

        public async Task<Response> AddAsync(HelpDeskSolitionCreateViewModel model)
        {
            try
            {
                var solitionNumber =await _generatedIdsService.GetNextNumber(ModuleId);
                var entity = _mapper.Map<HelpDeskSolution>(model);
                entity.SolitionNumber = solitionNumber.Data;
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Çözümü Başarıyla Tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Çözümü Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStatusAsync(HelpDeskSolitionChangeStatusViewModel model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id.ToString());
                if (entity == null)
                {
                    return Response.Fail(400, "Yardım Masası Çözüm Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", "Yardım Masası Çözüm Durumu Değiştirilecek Olan Bilgilere Ulaşılamadı", true);
                }
                entity.Status = model.Status;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Çözüm Durumu Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Çözüm Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> Delete(string id)
        {
            var hDS = _repository.GetByIdAsync(id);
            if (hDS ==null)
            {
                return Response<HelpDeskSolitionInfoViewModels>.FailData(404, "Silinmek İstenilen Yardım Masası Çözümüne Ulaşılamadı", $"{id} li Yardım Masası Çözümüne Ulaşılamadı", true);
            }
            try
            {
                _repository.Delete(_mapper.Map<HelpDeskSolution>(hDS));
                return Response.Success(200, "Yardım Masası Çözümü Başarıyla Silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Çözümü Silinirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskSolitionInfoViewModels>> GetByIdAsync(string id)
        {
            try
            {
                var hDS = await _repository.GetByIdAsync(id);
                return hDS == null ?
                    Response<HelpDeskSolitionInfoViewModels>.FailData(404, "Görüntülenmek istenilen Yardım Masaı Çözüm bilgilerine blaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Çözüm bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin", true):
                    Response<HelpDeskSolitionInfoViewModels>.SuccessData(200,"Yardım Masası Çözüm Bilgisi Başarıyla Alındı",_mapper.Map<HelpDeskSolitionInfoViewModels>(hDS));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskSolitionInfoViewModels>.FailData(400, "Yardım Masası Çözüm Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<HelpDeskSolitionInfoViewModels>>> GetHelpDeskSolutionList()
        {
            var res = await _repository.GetHelpDeskSolutionList();
            var retVal = _mapper.Map<List<HelpDeskSolitionInfoViewModels>>(res);
            return Response<List<HelpDeskSolitionInfoViewModels>>.SuccessData(200, "Yardım Masası Çözüm Listesi Başarıyla Alındı", retVal);
        }

        public async Task<Response<HelpDeskSolitionUpdateViewModel>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var hDS = await _repository.GetByIdAsync(id);
                return hDS == null ?
                    Response<HelpDeskSolitionUpdateViewModel>.FailData(404, "Görüntülenmek istenilen Yardım Masası Çözüm bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Çözüm bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<HelpDeskSolitionUpdateViewModel>.SuccessData(200, "Yardım Masası Çözüm Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskSolitionUpdateViewModel>(hDS));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskSolitionUpdateViewModel>.FailData(400, "Yardım Masası Çözüm Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskSolitionInfoViewModels>> UpdateAsync(HelpDeskSolitionUpdateViewModel model, string id)
        {
            try
            {
                var hDS = await _repository.GetByIdAsync(id);
                if (hDS == null)
                {
                    return Response<HelpDeskSolitionInfoViewModels>.FailData(404, "Güncellenmek istenilen Yardım Masası Çözümüne ulaşılamadı", $"{id} li Yardım Masası Çözüm bilgilerine ulaşılamadı", true);
                }

                hDS.Title = model.Title;
                hDS.Content = model.Content;
                hDS.Description = model.Description;
                hDS.HelpDeskProblemId = model.HelpDeskProblemId;
                hDS.CustomerCanSee = model.CustomerCanSee;

                var res = _repository.UpdateAsync(hDS);
                await _unitOfWork.CommitAsync();
                return Response<HelpDeskSolitionInfoViewModels>.SuccessData(200,"Yardım Masası Çözümü Başarıyla Güncellendi",_mapper.Map<HelpDeskSolitionInfoViewModels>(hDS));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskSolitionInfoViewModels>.FailData(400, "Yardım Masası Çözümü Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

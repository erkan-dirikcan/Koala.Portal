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
    public class HelpDeskCategoryService : IHelpDeskCategoryService
    {
        private readonly IHelpDeskCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public HelpDeskCategoryService(IHelpDeskCategoryRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(HelpDeskCategoryCreateViewModel model)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<HelpDeskCategory>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Kategorisi Başarıyla Tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Kategorisi Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStatusAsync(HelpDeskCategoryChangeStatusViewModel model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id.ToString());
                if (entity==null)
                {
                    return Response.Fail(400, "Yardım Masası Kategori Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", "Yardım Masası Durumu Değiştirilecek Olan Bilgilere Ulaşılamadı", true);
                }
                entity.Status = model.Status;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Kategori Durumu Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Kategori Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> Delete(string id)
        {
            var hDC = _repository.GetByIdAsync(id);
            if (hDC==null)
            {
                return Response<HelpDeskCategoryInfoViewModels>.FailData(404, "Silinmek istenilen Yardım Masası Kategorisine ulaşılamadı", $"{id} li Yardım Masası Kategorisine ulaşılamadı", true);
            }
            try
            {
                _repository.Delete(_mapper.Map<HelpDeskCategory>(hDC));
                return Response.Success(200, "Yardım Masası Kategorisi Başarıyla Silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400,"Yardım Masası Kategorisi Silinirken Bir Sorunla Karşılaşıldı",ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskCategoryInfoViewModels>> GetByIdAsync(string id)
        {
            try
            {
                var hDC = await _repository.GetByIdAsync(id);
                return hDC == null ?
                    Response<HelpDeskCategoryInfoViewModels>.FailData(404, "Görüntülenmek istenilen Yardım Masası Kategori bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Kategori bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<HelpDeskCategoryInfoViewModels>.SuccessData(200, "Yardım Masası Kategori Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskCategoryInfoViewModels>(hDC));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskCategoryInfoViewModels>.FailData(400, "Yardım Masası Kategori Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<HelpDeskCategoryInfoViewModels>>> GetHelpDeskCategoryList()
        {
            var res = await _repository.GetHelpDeskCategoryList();
            var retVal = _mapper.Map<List<HelpDeskCategoryInfoViewModels>>(res);
            return Response<List<HelpDeskCategoryInfoViewModels>>.SuccessData(200, "Yardım Masası Kategori Listesi Bşaarıyla Alındı", retVal);
        }

        public async Task<Response<HelpDeskCategoryUpdateViewModel>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var hDC = await _repository.GetByIdAsync(id);
                return hDC== null ?
                    Response<HelpDeskCategoryUpdateViewModel>.FailData(404, "Görüntülenmek istenilen Yardım Masası Kategori bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Kategori bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<HelpDeskCategoryUpdateViewModel>.SuccessData(200, "Yardım Masası Kategori Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskCategoryUpdateViewModel>(hDC));
            }
            catch (Exception ex )
            {
                return Response<HelpDeskCategoryUpdateViewModel>.FailData(400, "Yardım Masası Kategori Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskCategoryInfoViewModels>> UpdateAsync(HelpDeskCategoryUpdateViewModel model, string id)
        {
            try
            {
                var hDC = await _repository.GetByIdAsync(id);
                if (hDC == null)
                {
                    return Response<HelpDeskCategoryInfoViewModels>.FailData(404, "Güncellenmek istenilen Yardım Masası Kategorisine ulaşılamadı", $"{id} li Yardım Masası Kategori bilgilerine ulaşılamadı", true);
                }
                hDC.Name = model.Name;
                hDC.Description =model.Description;

                var res = _repository.UpdateAsync(hDC);
                await _unitOfWork.CommitAsync();
                return Response<HelpDeskCategoryInfoViewModels>.SuccessData(200, "Yardım Masası Kategorisi Başarıyla Güncellendi", _mapper.Map<HelpDeskCategoryInfoViewModels>(hDC));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskCategoryInfoViewModels>.FailData(400, "Yardım Masası Kategori Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

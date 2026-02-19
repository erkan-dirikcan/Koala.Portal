using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services
{
    public class HelpDeskProblemService : IHelpDeskProblemService
    {
        private readonly IHelpDeskProblemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public HelpDeskProblemService(IHelpDeskProblemRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(HelpDeskProblemCreateViewModel model)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<HelpDeskProblem>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Problemi Başarıyla Tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Problemi Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStatusAsync(HelpDeskProblemChangeStatusViewModel model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id.ToString());
                if (entity == null)
                {
                    return Response.Fail(400, "Yardım Masası Problemi Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", "Yardım Masası Problemi Durumu Değiştirilecek Olan Bilgilere Ulaşılamadı", true);
                }
                entity.Status = model.Status;
                await _repository.UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Yardım Masası Problemi Durumu Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Problemi Durumu Değiştirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> Delete(string id)
        {
            var hDeskProblem = _repository.GetByIdAsync(id);
            if (hDeskProblem == null)
            {
                return Response<HelpDeskCategoryInfoViewModels>.FailData(404, "Silinmek İstenilen Yardım Masası Problemine Ulaşılamadı", $"{id} li Yardım Masası Problemine Ulaşılamadı", true);
            }
            try
            {
                _repository.Delete(_mapper.Map<HelpDeskProblem>(hDeskProblem));
                return Response.Success(200, "Yardım Masası Problemi Başarıyla Silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Yardım Masası Problemi Silinirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskProblemInfoViewModels>> GetByIdAsync(string id)
        {
            try
            {
                var hDeskProblem = await _repository.GetByIdAsync(id);
                HelpDeskProblemInfoViewModels retVal;
                if (hDeskProblem == null)
                {
                    return Response<HelpDeskProblemInfoViewModels>.FailData(404, "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true);
                }
                else
                {
                    if (hDeskProblem.HelpDeskSolitions == null || hDeskProblem.HelpDeskSolitions.Count < 0)
                    {
                        return Response<HelpDeskProblemInfoViewModels>.SuccessData(200, "Yardım Masası Kategori Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskProblemInfoViewModels>(hDeskProblem));
                    }
                    else
                    {
                        return Response<HelpDeskProblemInfoViewModels>.SuccessData(200, "Yardım Masası Kategori Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskProblemInfoViewModels>(hDeskProblem));
                    }
                }
                //hDeskProblem == null ?
                //Response<HelpDeskProblemInfoViewModels>.FailData(404, "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                //Response<HelpDeskProblemInfoViewModels>.SuccessData(200, "Yardım Masası Kategori Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskProblemInfoViewModels>(hDeskProblem));

            }
            catch (Exception ex)
            {
                return Response<HelpDeskProblemInfoViewModels>.FailData(400, "Yardım Masası Problemi Bİlgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskFilterList(string tag)
        {
            try
            {
                var res = await _repository.Where(x => x.Status == StatusEnum.Active && (
                   x.Content.Contains(tag) ||
                   x.Title.Contains(tag) ||
                   x.HelpDeskSolitions.Any(y => y.Content.Contains(tag)) ||
                   x.HelpDeskSolitions.Any(y => y.Title.Contains(tag)))).ToListAsync();
                var retVal = _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res);
                //if (!res.Any())
                //{
                //    return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(204, "Aradığınız kriterlere uygun çözüm bülünamadı", _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res));
                //}
                return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(200, "Aranan kriterlerde çözümler başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<HelpDeskProblemInfoViewModels>>.FailData(400, "Çözüm aranırken bir sorunla karşılaşıldı", ex.Message, false);
            }

        }
        public async Task<Response<HelpDeskProblemUpdateViewModel>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var hDeskProblem = await _repository.GetByIdAsync(id);
                return hDeskProblem == null ?
                    Response<HelpDeskProblemUpdateViewModel>.FailData(404, "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Yardım Masası Problemi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<HelpDeskProblemUpdateViewModel>.SuccessData(200, "Yardım Masası Problemi Bilgisi Başarıyla Alındı", _mapper.Map<HelpDeskProblemUpdateViewModel>(hDeskProblem));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskProblemUpdateViewModel>.FailData(400, "Yardım Masası Problemi Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<HelpDeskProblemInfoViewModels>> UpdateAsync(HelpDeskProblemUpdateViewModel model, string id)
        {
            try
            {
                var hDeskProblem = await _repository.GetByIdAsync(id);
                if (hDeskProblem == null)
                {
                    return Response<HelpDeskProblemInfoViewModels>.FailData(404, "Güncellenmek istenilen Yardım Masası Problemine ulaşılamadı", $"{id} li Yardım Masası Problemi bilgilerine ulaşılamadı", true);
                }
                hDeskProblem.Title = model.Title;
                hDeskProblem.Content = model.Content;
                //TODO : Katogori İşlemleri Yapılacak
                //hDeskProblem.CategoryId = model.CategoryId;
                var res = _repository.UpdateAsync(hDeskProblem);
                await _unitOfWork.CommitAsync();
                return Response<HelpDeskProblemInfoViewModels>.SuccessData(200, "Yardım Masası Problemi Başarıyla Güncellendi", _mapper.Map<HelpDeskProblemInfoViewModels>(hDeskProblem));
            }
            catch (Exception ex)
            {
                return Response<HelpDeskProblemInfoViewModels>.FailData(400, "Yardım Masası Problemi Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemList()
        {
            var res = await _repository.GetHelpDeskProblemList();
            var retVal = _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res);
            return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(200, "Yardım Masası Problem Listesi Başarıyla Alındı", retVal);
        }

        public async Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemViewOrderList()
        {
            var res = await _repository.GetHelpDeskProblemViewOrderList();
            var retVal = _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res);
            return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(200, "Yardım Masası Problem Listesi Görüntüleme Sırasına Göre Başarıyla Alındı", retVal);
        }

        public async Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemLastAddedList()
        {
            var res = await _repository.GetHelpDeskProblemLastAddedList();
            var retVal = _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res);
            return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(200, "Yardım Masası Problem Listesi Ekleme Sırasına Göre Başarıyla Alındı", retVal);
        }

        public async Task<Response<List<HelpDeskProblemInfoViewModels>>> GetHelpDeskProblemWithCategory(string category)
        {
            try
            {
                var res = await _repository.GetHelpDeskProblemWithCategory(category);

                var retVal = _mapper.Map<List<HelpDeskProblemInfoViewModels>>(res);
                return Response<List<HelpDeskProblemInfoViewModels>>.SuccessData(200, "Yardım Masası Problemleri Kategoriye Göre Başarıyla Getirildi", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<HelpDeskProblemInfoViewModels>>.FailData(400, "Yardım Masası Kategoriye Göre Problem Listesi Getirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }

        }

        public async Task<Response<HelpDeskProblemDetailInfoViewModels>> DetailInfo(string id)
        {
            try
            {
                var problem = await _repository.GetByIdAsync(id);
                problem.Views++;
                var res = _repository.UpdateAsync(problem);
                await _unitOfWork.CommitAsync();
                return Response<HelpDeskProblemDetailInfoViewModels>.SuccessData(200, "Yardım Masası Problemi Başarıyla Güncellendi", _mapper.Map<HelpDeskProblemDetailInfoViewModels>(problem));
            }
            catch (Exception ex )
            {
                return Response<HelpDeskProblemDetailInfoViewModels>.FailData(400, "Yardım Masası Problemi Bİlgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

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
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public TransactionTypeService(ITransactionTypeRepository transactionTypeRepository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(CreateTransactionTypeViewModels model)
        {
            try
            {
                await _transactionTypeRepository.AddAsync(_mapper.Map<TransactionType>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Transaction Tipi Başarıyla Tanımlandı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Transaction Tipi Tanımlanırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> Delete(string id)
        {
            var tType = _transactionTypeRepository.GetByIdAsync(id);
            if (tType == null)
            {
                return Response<GetTransactionTypeViewModel>.FailData(404, "Silinmek istenilen Transaction Tipine ulaşılamadı", $"{id} li Transaction Tipine ulaşılamadı", true);
            }
            try
            {
                _transactionTypeRepository.Delete(_mapper.Map<TransactionType>(tType));
                return Response.Success(200, "Transaction Tipi başarıyla silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Transaction Tipi silinirken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<GetTransactionTypeViewModel>> GetByIdAsync(string id)
        {
            try
            {
                var tType = await _transactionTypeRepository.GetByIdAsync(id);
                return tType == null ?
                    Response<GetTransactionTypeViewModel>.FailData(404, "Görüntülenmek istenilen Transaction Tipi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen Transaction Tipi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<GetTransactionTypeViewModel>.SuccessData(200, "Transaction Tipi Bilgisi Başarıyla Alındı", _mapper.Map<GetTransactionTypeViewModel>(tType));
            }
            catch (Exception ex)
            {
                return Response<GetTransactionTypeViewModel>.FailData(400, "Transaction Tipi Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<UpdateTransactionTypeViewModels>> GetUpdateInfoAsync(string id)
        {
            try
            {
                var tType = await _transactionTypeRepository.GetByIdAsync(id);
                return tType == null ?
                    Response<UpdateTransactionTypeViewModels>.FailData(404, "Görüntülenmek istenilen Transaction Tipi bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<UpdateTransactionTypeViewModels>.SuccessData(200, "Transaction Tipi Bilgisi Başarıyla Alındı", _mapper.Map<UpdateTransactionTypeViewModels>(tType));
            }
            catch (Exception ex)
            {
                return Response<UpdateTransactionTypeViewModels>.FailData(400, "Transaction Tipi Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<GetTransactionTypeViewModel>>> GetTransactionTypeList()
        {
            var res = await _transactionTypeRepository.GetTransactionTypeList();
            var retVal = _mapper.Map<List<GetTransactionTypeViewModel>>(res);
            return Response<List<GetTransactionTypeViewModel>>.SuccessData(200, "Transaction Tipi Listesi Başarıyla Alındı", retVal);
        }

        public async Task<Response<GetTransactionTypeViewModel>> UpdateAsync(UpdateTransactionTypeViewModels model, string id)
        {
            try
            {
                var tType = await _transactionTypeRepository.GetByIdAsync(id);
                if (tType == null)
                {
                    return Response<GetTransactionTypeViewModel>.FailData(404, "Güncellenmek istenilen Transaction Tipine ulaşılamadı", $"{id} li modül bilgilerine ulaşılamadı", true);
                }
                tType.Name = model.Name;
                tType.Description = model.Description;
                tType.Icon = model.Icon;
                tType.ColorClass = model.ColorClass;
                var res = _transactionTypeRepository.UpdateAsync(tType);
                await _unitOfWork.CommitAsync();
                return Response<GetTransactionTypeViewModel>.SuccessData(200, "Transaction Tipi Başarıyla Güncellendi", _mapper.Map<GetTransactionTypeViewModel>(tType));
            }
            catch (Exception ex)
            {
                return Response<GetTransactionTypeViewModel>.FailData(400, "Transaction Tipi Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStatusAsync(TransactionTypeChangeStatusViewModel model)
        {
            try
            {

                var entity = await _transactionTypeRepository.GetByIdAsync(model.Id.ToString());
                if (entity == null)
                {
                    return Response.Fail(400, "Transaction Tipi Değiştirilirken Bir Sorunla Karşılaşıldı", "Transaction Tipi Değiştirilecek Olan Bilgilere Ulaşılamadı.", true);
                }
                entity.Status = model.Status;
                await _transactionTypeRepository.UpdateAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Transaction Tipi Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Transaction Tipi Değiştirilirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

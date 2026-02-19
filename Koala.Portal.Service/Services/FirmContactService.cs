using Koala.Portal.Core.Services;
using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class FirmContactService : IFirmContactService
    {
        private readonly IFirmContactRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public FirmContactService(IFirmContactRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<CrmFirmContactListViewModel>>> GetAllAsync(string firmId)
        {
            try
            {
                var res =await _repository.GetAllAsync(firmId);
                var retVal = _mapper.Map<List<CrmFirmContactListViewModel>>(res);
                return Response<List<CrmFirmContactListViewModel>>.SuccessData(200, "Firma yetkili listesi başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmContactListViewModel>>.FailData(400, "Firma Yetkili Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<CrmFirmContactListViewModel>>> GetAllByOidAsync(string firmOid)
        {
            try
            {
                var res = _repository.GetAllByOidAsync(firmOid);
                var retVal = _mapper.Map<List<CrmFirmContactListViewModel>>(res);
                return Response<List<CrmFirmContactListViewModel>>.SuccessData(200, "Firma yetkili listesi başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmContactListViewModel>>.FailData(400, "Firma Yetkili Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<string>> GetOidAsync(string id)
        {
            try
            {
                var res = await _repository.GetByIdAsync(id);
                return res == null 
                    ? Response<string>.FailData(404, "Firma yetkilisi bilgileri alınırken bir sorunla karşılaşıldı", "Firma yetkilisi bilgilerine ulaşılamdı", true) 
                    : Response<string>.SuccessData(200, "Firma yetkilisi Oid bilgisi başarıyla alındı", res.Oid);
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Firma Yetkilisi Oid bilgisi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<string>> GetIdAsync(string oid)
        {
            try
            {
                var res = await _repository.GetByOidAsync(oid);
                return res == null 
                    ? Response<string>.FailData(404, "Firma yetkilisi bilgileri alınırken bir sorunla karşılaşıldı", "Firma yetkilisi bilgilerine ulaşılamdı", true) 
                    : Response<string>.SuccessData(200, "Firma yetkilisi Id bilgisi başarıyla alındı", res.Id);
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Firma Yetkilisi Id bilgisi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<CrmFirmContactDetailViewModel>> GetDetailAsync(string contactId)
        {
            try
            {
                var res = await _repository.GetByIdAsync(contactId);
                var retVal = _mapper.Map<CrmFirmContactDetailViewModel>(res);
                return res == null 
                    ? Response<CrmFirmContactDetailViewModel>.FailData(404, "Firma yetkilisi bilgileri alınırken bir sorunla karşılaşıldı", "Firma yetkilisi bilgilerine ulaşılamdı", true) 
                    : Response<CrmFirmContactDetailViewModel>.SuccessData(200, "Firma yetkilisi bilgisi başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<CrmFirmContactDetailViewModel>.FailData(400, "Firma Yetkilisi bilgisi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<CrmFirmContactDetailViewModel>> GetDetailByOidAsync(string contactOid)
        {
            try
            {
                var res = await _repository.GetByOidAsync(contactOid);
                var retVal = _mapper.Map<CrmFirmContactDetailViewModel>(res);
                return res == null 
                    ? Response<CrmFirmContactDetailViewModel>.FailData(404, "Firma yetkilisi bilgileri alınırken bir sorunla karşılaşıldı", "Firma yetkilisi bilgilerine ulaşılamdı", true) 
                    : Response<CrmFirmContactDetailViewModel>.SuccessData(200, "Firma yetkilisi bilgisi başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<CrmFirmContactDetailViewModel>.FailData(400, "Firma Yetkilisi bilgisi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
    }
}

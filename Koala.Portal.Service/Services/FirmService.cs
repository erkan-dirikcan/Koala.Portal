using AutoMapper;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class FirmService : IFirmService
    {
        private readonly IFirmRepository _repository;
        private readonly ICrmFirmRepository _crmRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public FirmService(IUnitOfWork<AppDbContext> unitOfWork, IBaseRepository<CrmFirm> baseRepository, IFirmRepository repository, IMapper mapper,ICrmFirmRepository crmRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _crmRepository = crmRepository;
        }
        public async Task<Response<List<InfoCrmFirmViewModel>>> GetFirmList()
        {
            var firms = await _repository.GetAllAsync();
            return Response<List<InfoCrmFirmViewModel>>.SuccessData(200, "Firma Listesi Başarıyla Alındı", _mapper.Map<List<InfoCrmFirmViewModel>>(firms));
        }
        public async Task<Response> AddRangeAsync(List<CreateCrmFirmViewModel> firms)
        {
            try
            {
                var val = _mapper.Map<List<CrmFirm>>(firms);
                await _repository.AddRangeAsync(val);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Firmalar Crm Veritabanına Başarıyla Aktarıldı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Firmalar Crm Veri Tabanına Eklenirken Bir Sorunla Karşılaşıldı", ex.Message,
                    false);

            }
        }

        public async Task<Response<InfoCrmFirmViewModel>> GetFirmByIdAsync(string id)
        {
            try
            {
                var firm = _repository.GetFirmInfoById(id);
                return firm == null ?
                    Response<InfoCrmFirmViewModel>.FailData(404, "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<InfoCrmFirmViewModel>.SuccessData(200, "Firmaa Bilgisi Başarıyla Alındı", _mapper.Map<InfoCrmFirmViewModel>(firm));
            }
            catch (Exception ex)
            {
                return Response<InfoCrmFirmViewModel>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<SupportListInfoCrmFirmViewModel>> GetFirmByOidAsync(string oid)
        {
            try
            {
                var firm = _crmRepository.GetFirmInfo(oid);//_repository.GetFirmInfoById(id);
                return firm == null ?
                    Response<SupportListInfoCrmFirmViewModel>.FailData(404, "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", "Görüntülenmek istenilen firma bilgilerine ulaşılamadı, Lütfen senkronizasyon yapıp tekrar deneyin.", true) :
                    Response<SupportListInfoCrmFirmViewModel>.SuccessData(200, "Firmaa Bilgisi Başarıyla Alındı", _mapper.Map<SupportListInfoCrmFirmViewModel>(firm));
            }
            catch (Exception ex)
            {
                return Response<SupportListInfoCrmFirmViewModel>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        //public async Task<Response<InfoCrmFirmViewModel>> UpdateFirmAsync(string id)
        //{
        //    try
        //    {
        //        var lFirm =   _repository.GetFirmInfoById(id);
        //        var CrmFirm = _crmRepository.GetFirmInfo(id);

        //        List<string> list = new List<string>();
        //        foreach (var item in list)
        //        {
                    
        //        }
        //        var res = _repository.UpdateFirmAsync(lFirm);
        //        return Response<InfoCrmFirmViewModel>.SuccessData(200, "Firma Başarıyla Güncellendi",_mapper.Map<InfoCrmFirmViewModel>(lFirm));

        //    }
        //    catch (Exception ex)
        //    {
        //        return Response<InfoCrmFirmViewModel>.FailData(400, "Firma Bilgileri Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message,false);
        //    }
            

        //}
    }
}

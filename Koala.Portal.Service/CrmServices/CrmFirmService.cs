using System.Diagnostics;
using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using System.Linq.Expressions;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Koala.Portal.Core.Repositories;

namespace Koala.Portal.Service.CrmServices

{
    public class CrmFirmService : ICrmFirmService
    {
        private readonly ICrmFirmRepository _repository;
        private readonly IFirmRepository _localRepository;
        private readonly ICrmPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;
        public CrmFirmService(ICrmFirmRepository repository, IMapper mapper, ICrmPhoneRepository phoneRepository, IFirmRepository localRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _phoneRepository = phoneRepository;
            _localRepository = localRepository;
        }
        /// <summary>
        /// Crm de bulunan ve Koala sistemine henüz taşınmamış firmaları tespit ederek veri tabanına kaydetmek için kullanılır.
        /// </summary>
        /// <param name="predicate">Hangi firmaların taşınacağını belirtel Linq Sorgusu</param>
        /// <returns>Response&lt;List&lt;CreateCrmFirmViewModel&gt;&gt; Türünde veri döndürür</returns>
        public Response<List<CreateCrmFirmViewModel>> Where(Expression<Func<MT_Firm, bool>> predicate)
        {
            try
            {
                var res = _repository.Where(predicate).ToList();
                var retVal = _mapper.Map<List<CreateCrmFirmViewModel>>(res);
                return Response<List<CreateCrmFirmViewModel>>.SuccessData(200, "", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CreateCrmFirmViewModel>>.FailData(400, "Firma Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        /// <summary>
        /// Firmanın Destek sözleşmesi durumunu döndürür
        /// </summary>
        /// <param name="firmOid">Firma Oid Bilgisi</param>
        /// <returns>Response&lt;FirmSupportStatusViewModel&gt; Türünde veri döndürür</returns>
        public Response<FirmSupportStatusViewModel> GetFirmSupportStatusInfo(string firmOid)
        {
            var res = _repository.GetFirmSupportStatusInfo(firmOid);
            var retVal = _mapper.Map<FirmSupportStatusViewModel>(res);
            return Response<FirmSupportStatusViewModel>.SuccessData(200, "Firma Destek Durumu Başarıyla Alındı", retVal);
        }

        public Response<InfoCrmFirmViewModel> GetFirmInfo(string firmOid)
        {
            try
            {
                var firm = _repository.GetFirmInfo(firmOid);
                if (firm != null)
                {
                    return Response<InfoCrmFirmViewModel>.SuccessData(200, "Firma Bilgisi Başarıyla Alındı",
                        _mapper.Map<InfoCrmFirmViewModel>(firm));
                }

                return Response<InfoCrmFirmViewModel>.FailData(404, "Firma Bilgisi Bulunamadı",
                    "Firma Bilgisi Bulunamadı", true);
            }
            catch (Exception ex)
            {
                return Response<InfoCrmFirmViewModel>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }

        }

        public Response<InfoCrmFirmViewModel> GetFirmInfoByCode(string code)
        {
            try
            {
                var firm = _repository.GetFirmInfoByCode(code);
                if (firm != null)
                {
                    return Response<InfoCrmFirmViewModel>.SuccessData(200, "Firma Bilgisi Başarıyla Alındı",
                        _mapper.Map<InfoCrmFirmViewModel>(firm));
                }

                return Response<InfoCrmFirmViewModel>.FailData(404, "Firma Bilgisi Bulunamadı",
                    "Firma Bilgisi Bulunamadı", true);
            }
            catch (Exception ex)
            {
                return Response<InfoCrmFirmViewModel>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        /// <summary>
        /// Telefon numarasına göre firma bilgisi döndürür
        /// </summary>
        /// <param name="model">GetFirm3cxInfoByPhoneViewModel</param>
        /// <returns>Response&lt;Firm3cxInfoViewModel&gt; Türünde veri döndürür</returns>
        public Response<Firm3cxInfoViewModel> GetFirmInfoWithPhone(GetFirm3cxInfoByPhoneViewModel model)
        {
            var sw = new Stopwatch();
            sw.Start();
            var phone = model.Phone.Replace(" ", "");
            var phoneLines = _phoneRepository.Where(x => x.GCRecord == null);

            var pl = new List<PO_Phone_Number>();
            foreach (var item in phoneLines)
            {
                var pn = FormatPhone(item.AreaCode, item.Number);
                if (pn == phone)
                {
                    pl.Add(item);
                }
            }

            var retVal = new Firm3cxInfoViewModel();
            if (phoneLines.Any(x => x.RelatedContactNavigation != null && x.RelatedFirmNavigation != null))
            {
                var line = phoneLines.FirstOrDefault(x => x.RelatedContactNavigation != null && x.RelatedFirmNavigation != null);
                retVal = _mapper.Map<Firm3cxInfoViewModel>(line);

            }
            else if (phoneLines.Any(x => x.RelatedFirmNavigation != null))
            {
                var line = phoneLines.FirstOrDefault(x => x.RelatedFirmNavigation != null);
                retVal = _mapper.Map<Firm3cxInfoViewModel>(line);
            }
            else if (phoneLines.Any(x => x.RelatedContactNavigation != null))
            {
                var line = phoneLines.FirstOrDefault(x => x.RelatedContactNavigation != null);
                retVal = _mapper.Map<Firm3cxInfoViewModel>(line);
            }
            var s = sw.ElapsedMilliseconds;
            sw.Stop();

            return !string.IsNullOrEmpty(retVal.Oid) ?
                Response<Firm3cxInfoViewModel>.SuccessData(200, "Firma Telefon Bilgisi Başarıyla Alındı", retVal) :
                Response<Firm3cxInfoViewModel>.FailData(404, "Telefon Numarası CRM de Bulunamadı", "Telefon Numarası CRM de Bulunamadı", true);
        }
        /// <summary>
        /// Bu metot henüz kullanıma açılmadı
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<Firm3cxInfoViewModel> GetFirmInfoWithEmail(GetFirm3cxInfoByEmailViewModel model)
        {
            //TODO : Zamanı gelince kullanılacak.
            return Response<Firm3cxInfoViewModel>.FailData(404, "Eposta Adresi CRM de Bulunamadı", "Eposta Adresi CRM de Bulunamadı", true);
        }




        //===============================================Private Metotlar=================================================
        private string FormatPhone(string? areaCode, string? number)
        {
            var ac = areaCode == null ? "" : areaCode.Replace(" ", "");
            var n = number == null ? "" : number.Replace(" ", "");
            return ac + n;
        }

        public async Task<Response<List<CrmFirmListViewModel>>> GetAllLocalFirm()
        {
            try
            {
                var res = await _localRepository.GetAllAsync();
                var retVal = _mapper.Map<List<CrmFirmListViewModel>>(res);
                return Response<List<CrmFirmListViewModel>>.SuccessData(200, "Local Firma Listesi Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmListViewModel>>.FailData(400, "Firma Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}

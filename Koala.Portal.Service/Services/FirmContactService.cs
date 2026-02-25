using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Services;
using AutoMapper;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Services
{
    public class FirmContactService : IFirmContactService
    {
        private readonly ICrmFirmRepository _crmRepository;
        private readonly IMapper _mapper;

        public FirmContactService(ICrmFirmRepository crmRepository, IMapper mapper)
        {
            _crmRepository = crmRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<CrmFirmContactListViewModel>>> GetAllAsync(string firmId)
        {
            try
            {
                // For CRM, we need the firm OID, not the local ID
                // Get contacts from CRM directly
                var crmFirm = await _crmRepository.GetAllAsync();
                var firm = crmFirm.FirstOrDefault(x => x.Oid.ToString().Equals(firmId, StringComparison.OrdinalIgnoreCase));

                if (firm == null)
                {
                    return Response<List<CrmFirmContactListViewModel>>.FailData(404, "Firma CRM'de bulunamadı", "Firma bilgilerine ulaşılamadı", true);
                }

                var contacts = firm.MT_Contact?
                    .Where(c => c.InUse == true)
                    .Select(c => new CrmFirmContactListViewModel
                    {
                        Id = c.Oid.ToString(),
                        Oid = c.Oid.ToString(),
                        Firm = firm.Oid.ToString(),
                        FullName = $"{c.FirstName} {c.LastName}".Trim()
                    })
                    .ToList() ?? new List<CrmFirmContactListViewModel>();

                return Response<List<CrmFirmContactListViewModel>>.SuccessData(200, "Firma yetkili listesi CRM'den başarıyla alındı", contacts);
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
                var firm = _crmRepository.GetFirmInfo(firmOid);

                if (firm == null)
                {
                    return Response<List<CrmFirmContactListViewModel>>.FailData(404, "Firma CRM'de bulunamadı", "Firma bilgilerine ulaşılamadı", true);
                }

                var contacts = firm.MT_Contact?
                    .Where(c => c.InUse == true)
                    .Select(c => new CrmFirmContactListViewModel
                    {
                        Id = c.Oid.ToString(),
                        Oid = c.Oid.ToString(),
                        Firm = firm.Oid.ToString(),
                        FullName = $"{c.FirstName} {c.LastName}".Trim()
                    })
                    .ToList() ?? new List<CrmFirmContactListViewModel>();

                return Response<List<CrmFirmContactListViewModel>>.SuccessData(200, "Firma yetkili listesi CRM'den başarıyla alındı", contacts);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmContactListViewModel>>.FailData(400, "Firma Yetkili Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<string>> GetOidAsync(string oid)
        {
            // For CRM, Oid is already the primary identifier
            // Just validate that this contact exists in CRM
            try
            {
                var firms = await _crmRepository.GetAllAsync();
                var contact = firms.SelectMany(f => f.MT_Contact ?? new List<MT_Contact>())
                    .FirstOrDefault(c => c.Oid.ToString().Equals(oid, StringComparison.OrdinalIgnoreCase));

                return contact == null
                    ? Response<string>.FailData(404, "İletişim kişisi CRM'de bulunamadı", "İletişim kişisi bilgilerine ulaşılamadı", true)
                    : Response<string>.SuccessData(200, "İletişim kişisi CRM'de bulundu", contact.Oid.ToString());
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "İletişim kişisi bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<string>> GetIdAsync(string oid)
        {
            // For CRM, Oid is the identifier we use
            return await GetOidAsync(oid);
        }

        public async Task<Response<CrmFirmContactDetailViewModel>> GetDetailAsync(string contactOid)
        {
            return await GetDetailByOidAsync(contactOid);
        }

        public async Task<Response<CrmFirmContactDetailViewModel>> GetDetailByOidAsync(string contactOid)
        {
            try
            {
                var firms = await _crmRepository.GetAllAsync();
                var contact = firms.SelectMany(f => f.MT_Contact ?? new List<MT_Contact>())
                    .FirstOrDefault(c => c.Oid.ToString().Equals(contactOid, StringComparison.OrdinalIgnoreCase));

                if (contact == null)
                {
                    return Response<CrmFirmContactDetailViewModel>.FailData(404, "İletişim kişisi CRM'de bulunamadı", "İletişim kişisi bilgilerine ulaşılamadı", true);
                }

                var detail = _mapper.Map<CrmFirmContactDetailViewModel>(contact);
                return Response<CrmFirmContactDetailViewModel>.SuccessData(200, "İletişim kişisi detayı CRM'den başarıyla alındı", detail);
            }
            catch (Exception ex)
            {
                return Response<CrmFirmContactDetailViewModel>.FailData(400, "İletişim kişisi detayı alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
    }
}

using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmFirmAdapter : ICrmFirmAdapter
    {
        private readonly ICrmPhoneAdapter _phoneAdapter;
        private readonly ICrmContactAdapter _contactAdapter;

        public CrmFirmAdapter(ICrmPhoneAdapter phoneAdapter, ICrmContactAdapter contactAdapter)
        {
            _phoneAdapter = phoneAdapter;
            _contactAdapter = contactAdapter;
        }

        public CrmFirm ToLocalEntity(MT_Firm crmFirm)
        {
            if (crmFirm == null) return null;

            return new CrmFirm
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmFirm.Oid.ToString(),
                Code = crmFirm.FirmCode ?? "",
                Title = crmFirm.FirmTitle ?? "",
                Phone = null, // Will be loaded separately via ToLocalEntityWithPhones
                InUse = crmFirm.InUse ?? false,
                LastUpdate = DateTime.Now // Not used, but set for completeness
            };
        }

        public CrmFirm ToLocalEntityWithPhones(MT_Firm crmFirm, IEnumerable<PO_Phone_Number> phones)
        {
            var localFirm = ToLocalEntity(crmFirm);
            if (localFirm == null) return null;

            // Get default phone: where RelatedFirm = Firm.Oid AND IsDefaultPhone = true
            var defaultPhone = phones?
                .FirstOrDefault(p => p.RelatedFirm == crmFirm.Oid && p.IsDefaultPhone == true && p.GCRecord == null);

            if (defaultPhone != null)
            {
                localFirm.Phone = defaultPhone.Number;
                localFirm.Phones = new HashSet<CrmPhoneNumber>(
                    phones.Where(p => p.RelatedFirm == crmFirm.Oid && p.GCRecord == null)
                          .Select(p => _phoneAdapter.ToLocalEntity(p))
                );
            }
            else
            {
                localFirm.Phones = new HashSet<CrmPhoneNumber>();
            }

            // Load contacts from navigation property if available
            if (crmFirm.MT_Contact != null)
            {
                localFirm.Contacts = new HashSet<CrmFirmContact>(
                    crmFirm.MT_Contact
                        .Where(c => c.GCRecord == null)
                        .Select(c => _contactAdapter.ToLocalEntity(c, crmFirm.Oid.ToString()))
                );
            }

            return localFirm;
        }

        public IEnumerable<CrmFirm> ToLocalEntities(IEnumerable<MT_Firm> crmFirms)
        {
            if (crmFirms == null) return Enumerable.Empty<CrmFirm>();

            return crmFirms
                .Where(f => f.GCRecord == null) // Exclude deleted records
                .Select(f => ToLocalEntity(f))
                .Where(f => f != null);
        }
    }
}

using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmPhoneAdapter : ICrmPhoneAdapter
    {
        public CrmPhoneNumber ToLocalEntity(PO_Phone_Number crmPhone)
        {
            if (crmPhone == null) return null;

            return new CrmPhoneNumber
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmPhone.Oid.ToString(),
                RelatedFirm = crmPhone.RelatedFirm?.ToString(),
                RelatedContact = crmPhone.RelatedContact?.ToString(),
                AreaCode = crmPhone.AreaCode,
                Number = crmPhone.Number,
                Extension = crmPhone.Extension
            };
        }

        public IEnumerable<CrmPhoneNumber> ToLocalEntities(IEnumerable<PO_Phone_Number> crmPhones)
        {
            if (crmPhones == null) return Enumerable.Empty<CrmPhoneNumber>();

            return crmPhones
                .Where(p => p.GCRecord == null) // Exclude deleted records
                .Select(p => ToLocalEntity(p))
                .Where(p => p != null);
        }
    }
}

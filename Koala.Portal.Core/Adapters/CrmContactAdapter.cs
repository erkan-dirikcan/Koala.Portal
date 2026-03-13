using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmContactAdapter : ICrmContactAdapter
    {
        private readonly ICrmPhoneAdapter _phoneAdapter;

        public CrmContactAdapter(ICrmPhoneAdapter phoneAdapter)
        {
            _phoneAdapter = phoneAdapter;
        }

        public CrmFirmContact ToLocalEntity(MT_Contact crmContact, string firmOid = null)
        {
            if (crmContact == null) return null;

            // Name = FirstName + (MiddleName != null ? " {MiddleName}" : "")
            string name = crmContact.FirstName ?? "";
            if (!string.IsNullOrWhiteSpace(crmContact.MiddleName))
            {
                name += " " + crmContact.MiddleName.Trim();
            }

            var localContact = new CrmFirmContact
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmContact.Oid.ToString(),
                FirmId = firmOid ?? crmContact.RelatedFirm?.ToString(),
                Name = name.Trim(),
                LastName = crmContact.LastName ?? "",
                InUse = crmContact.InUse ?? false,
                SupportTicket = crmContact._MXN_InUse ?? false,
                LastUpdate = DateTime.Now // Not used, but set for completeness
            };

            // Load phones from navigation property if available
            if (crmContact.PO_Phone_Number != null)
            {
                localContact.Phones = new HashSet<CrmPhoneNumber>(
                    _phoneAdapter.ToLocalEntities(crmContact.PO_Phone_Number)
                );
            }

            return localContact;
        }

        public IEnumerable<CrmFirmContact> ToLocalEntities(IEnumerable<MT_Contact> crmContacts)
        {
            if (crmContacts == null) return Enumerable.Empty<CrmFirmContact>();

            return crmContacts
                .Where(c => c.GCRecord == null) // Exclude deleted records
                .Select(c => ToLocalEntity(c))
                .Where(c => c != null);
        }
    }
}

using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmContactAdapter
    {
        CrmFirmContact ToLocalEntity(CrmModels.MT_Contact crmContact, string firmOid = null);
        IEnumerable<CrmFirmContact> ToLocalEntities(IEnumerable<CrmModels.MT_Contact> crmContacts);
    }
}

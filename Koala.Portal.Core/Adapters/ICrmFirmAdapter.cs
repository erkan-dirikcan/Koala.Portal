using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmFirmAdapter
    {
        CrmFirm ToLocalEntity(CrmModels.MT_Firm crmFirm);
        CrmFirm ToLocalEntityWithPhones(CrmModels.MT_Firm crmFirm, IEnumerable<CrmModels.PO_Phone_Number> phones);
        IEnumerable<CrmFirm> ToLocalEntities(IEnumerable<CrmModels.MT_Firm> crmFirms);
    }
}

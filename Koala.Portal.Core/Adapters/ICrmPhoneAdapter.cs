using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmPhoneAdapter
    {
        CrmPhoneNumber ToLocalEntity(CrmModels.PO_Phone_Number crmPhone);
        IEnumerable<CrmPhoneNumber> ToLocalEntities(IEnumerable<CrmModels.PO_Phone_Number> crmPhones);
    }
}

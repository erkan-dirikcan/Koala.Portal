using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmServices
{
    public interface ICrmFirmService 
    {
        Response<List<CreateCrmFirmViewModel>> Where(Expression<Func<MT_Firm, bool>> predicate);
        Task<Response<List<CrmFirmListViewModel>>> GetAllLocalFirm();
        Response<FirmSupportStatusViewModel> GetFirmSupportStatusInfo(string firmOid);
        Response<InfoCrmFirmViewModel> GetFirmInfo(string firmOid);
        Response<InfoCrmFirmViewModel> GetFirmInfoByCode(string code);
        Response<Firm3cxInfoViewModel> GetFirmInfoWithPhone(GetFirm3cxInfoByPhoneViewModel model);
        Response<Firm3cxInfoViewModel> GetFirmInfoWithEmail(GetFirm3cxInfoByEmailViewModel model);



    }
}

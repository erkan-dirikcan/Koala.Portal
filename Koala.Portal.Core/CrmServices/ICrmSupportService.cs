using Koala.Portal.Core.Dtos;
using System.Linq.Expressions;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmServices;

public interface ICrmSupportService
{
    Task<Response<List<CrmSupportListViewModel>>> Where(Expression<Func<MT_Ticket, bool>> predicate);
    Task<Response> AddAsyc(CrmCreateSupportViewModel model);
    Task<Response> TakeOnAsync(CreateCrmSupportTicketHistoryViewModel model);
    Task<Response<CheckTakeOnSupportResponseViewModel>> CheckTakeOn(string oid, string userOid);
    Task<Response<List<CrmSupportListViewModel>>> GetFilteredSupports(CrmUserSupportFilterModel model);
    Task<Response<List<CrmFirmOpenSupportViewModel>>> GetFirmOpenSupports(string firmOid, List<Guid> Statuses);
    Task<Response<List<CrmFirmOpenSupportViewModel>>> GetFirmSupports(string firmOid);
    Task<Response<CrmUpdateSupportInfoViewModel>> GetUpdateSupportInfoAsync(string supportOid);    
    Task<Response> UpdateSupportAsync(CrmUpdateSupportViewModel model);
    string GetNextTicketId();

}
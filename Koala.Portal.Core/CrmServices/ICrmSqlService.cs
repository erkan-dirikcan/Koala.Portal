using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmServices
{
    public interface ICrmSqlService
    {
        Response<List<CrmUserDepartmentsViewModel>> GetCrmUserDepartments(string userOid);
        Response<CrmDashboardKpiDbViewModel> GetCrmDashboardKpi(string userOid);
        Response<string> GetCrmSupportNextId();
        Response<List<CrmUserFullNameInfoViewModel>> GetCrmUserFullNameInfoList();
        Response<CrmDetailViewModel> GetCrmSupportDetailById(string supportId);
        Response<string> GetFirmOidByPhone(string phone);
        Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmDailyClosedSupportCount();
        Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmApointedSupportCount();
    }


}

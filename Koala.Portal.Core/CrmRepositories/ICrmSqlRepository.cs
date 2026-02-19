using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmSqlRepository
{
    Response<List<CrmUserDepartmentsViewModel>> GetCrmUserDepartments(string query);
    Response<CrmDashboardKpiDbViewModel> GetCrmDashboardKpi(string query);
    Response<string> GetCrmSupportNextId(string query,string updateQuery);
    Response<List<CrmUserFullNameInfoViewModel>> GetCrmUserFullNameInfoList(string query);
    Response<CrmDetailViewModel> GetCrmSupportDetailById(string query);
    Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmDailyClosedSupportCount(string query1,string query2);
    Task<Response<List<CrmOpenSupportChartSqlViewModel>>> GetCrmOpenSupportChartData(string query);


    //TODO: Dosya Bilgisi Çekilecek
    //TODO : Proje Bilgisi Çekilecek

}
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmReportRepository
{
    Response<List<TicketReportViewModel>> GetAllTicketData();
}

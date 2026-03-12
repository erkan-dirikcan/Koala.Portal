using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmServices;

public interface ICrmReportService
{
    Response<List<TicketReportViewModel>> GetAllTicketData();
}

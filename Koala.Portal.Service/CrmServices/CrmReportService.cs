using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.CrmServices;

public class CrmReportService : ICrmReportService
{
    private readonly ICrmReportRepository _repository;

    public CrmReportService(ICrmReportRepository repository)
    {
        _repository = repository;
    }

    public Response<List<TicketReportViewModel>> GetAllTicketData()
    {
        return _repository.GetAllTicketData();
    }
}

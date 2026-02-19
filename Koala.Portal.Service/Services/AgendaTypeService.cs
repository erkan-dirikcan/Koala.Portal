using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services;

public class AgendaTypeService : BaseService<AgendaType>, IAgendaTypeService
{
    public AgendaTypeService(IUnitOfWork<AppDbContext> unitOfWork, IBaseRepository<AgendaType> baseRepository) : base(unitOfWork, baseRepository)
    {
    }
}
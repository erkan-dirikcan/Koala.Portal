using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmServices;

public interface ICrmSupportStateService
{
    Task<Response<List<CrmSupportStatesInfoViewModel>>> WhereAsync(Expression<Func<CT_Ticket_States, bool>> predicate);
    Task<Response<List<CrmSupportStatesInfoViewModel>>> GetAllAsync();
}
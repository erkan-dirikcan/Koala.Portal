using System.Linq.Expressions;
using Koala.Portal.Core.CrmModels;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmSupportStatesRepository
{
    Task<IQueryable<CT_Ticket_States>> WhereAsync(Expression<Func<CT_Ticket_States, bool>> predicate);
    Task<IEnumerable<CT_Ticket_States>> GetAllAsync();
    Task<CT_Ticket_States?> GetByOidAsync(Guid id);

}
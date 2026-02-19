using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmSupportTypeRepository:ICrmBaseRepository<CT_Ticket_Types>
{
    Task<IQueryable<CT_Ticket_Types>> WhereAsync(Expression<Func<CT_Ticket_Types, bool>> predicate);
    Task<IEnumerable<CT_Ticket_Types>> GetAllAsync();
    Task<CT_Ticket_Types?> GetByOidAsync(Guid id);
}
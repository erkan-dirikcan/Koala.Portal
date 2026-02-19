using System.Linq.Expressions;
using Koala.Portal.Core.CrmModels;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmSupportRepository
{
    IQueryable<MT_Ticket?> Where(Expression<Func<MT_Ticket, bool>> predicate);
    Task AddAsyc(MT_Ticket model);
    Task<MT_Ticket?> FindByOidAsync(string oid);
    Task<MT_Ticket?> FindByTickeyIdAsync(string ticketId);
    void UpdateTicket(MT_Ticket model);


}
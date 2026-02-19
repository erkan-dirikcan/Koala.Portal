using Koala.Portal.Core.CrmModels;

namespace Koala.Portal.Core.CrmRepositories
{
    public interface ICrmTicketHistoryRepository
    {
        Task AddAsync(EX_Ticket_History model);
    }
}

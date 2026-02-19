using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IVacationRequestRepository
    {
        Task<VacationRequest?> GetByIdAsyc(string id);
        Task<IEnumerable<VacationRequest>> GetAllAsync();
        IQueryable<VacationRequest> Where(Expression<Func<VacationRequest, bool>> predicate);
        Task AddAsyc(VacationRequest entity);
        VacationRequest Update(VacationRequest entity);
    }
}

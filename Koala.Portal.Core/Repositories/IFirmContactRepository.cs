using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IFirmContactRepository
    {
        Task<IEnumerable<CrmFirmContact>> GetAllAsync(string firmId);
        Task<IEnumerable<CrmFirmContact>> GetAllByOidAsync(string firmOid);
        IQueryable<CrmFirmContact> Where(Expression<Func<CrmFirmContact, bool>> predicate);
        Task<CrmFirmContact?> GetByIdAsync(string id);
        Task<CrmFirmContact?> GetByOidAsync(string oid);
    }
}

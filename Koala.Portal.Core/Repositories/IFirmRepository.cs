using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IFirmRepository
    {
        Task AddRangeAsync(List<CrmFirm> firms);
        CrmFirm? GetFirmInfoById(string id);
        Task UpdateFirmAsync(CrmFirm entity);
        IQueryable<CrmFirm> Where(Expression<Func<CrmFirm, bool>> predicate);
        Task<IEnumerable<CrmFirm>> GetAllAsync();
    }
}

using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IClaimRepository
    {
        Task<IEnumerable<Claims>> GetAllAsync();
        IQueryable<Claims> Where(Expression<Func<Claims, bool>> predicate);
        Task AddAsync(Claims claims);
        void Delete(Claims claims);
        Task UpdateAsync(Claims entity);
        Task<Claims> GetByIdAsyc(string id);

    }
}

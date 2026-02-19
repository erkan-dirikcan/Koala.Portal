using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IGeneratedIdsRepository
    {
        IQueryable<GeneratedIds> Where(Expression<Func<GeneratedIds, bool>> predicate);
        Task<IEnumerable<GeneratedIds>> GetGeneratedIdsList();
        Task<GeneratedIds> GetByIdAsync(string id);
        Task<GeneratedIds> GetByModuleIdAsync(string id);        
        Task AddAsync(GeneratedIds generatedIds);
        Task UpdateAsync(GeneratedIds entity);
    }
}

using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IProjectLineRepository
    {
        Task<IEnumerable<ProjectLine>> GetAllAsync();
        IQueryable<ProjectLine> Where(Expression<Func<ProjectLine, bool>> predicate);
        Task AddAsync(ProjectLine projectLine);
        void Delete(ProjectLine projectLine);
        void Update(ProjectLine entity);
        Task<ProjectLine> GetByIdAsyc(string id);       
    }
}

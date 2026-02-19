using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IProjectLineWorkRepository
    {
        IQueryable<ProjectLineWork?> Where(Expression<Func<ProjectLineWork, bool>> predicate);
        Task AddAsync(ProjectLineWork projectLine);
        void Update(ProjectLineWork entity);
        Task<ProjectLineWork?> GetByIdAsyc(string id);
    }
}

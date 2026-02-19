using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        IQueryable<Project> Where(Expression<Func<Project, bool>> predicate);
        Task AddAsync(Project project);
        void Delete(Project project);
        void Update(Project entity);
        Task<Project> GetByIdAsyc(string id);
        Task<Project> GetByCodeAsyc(string code);

    }
}

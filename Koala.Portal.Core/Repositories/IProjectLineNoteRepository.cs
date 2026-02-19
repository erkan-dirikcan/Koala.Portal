using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface IProjectLineNoteRepository
    {
        IQueryable<ProjectLineNote> Where(Expression<Func<ProjectLineNote, bool>> predicate);
        Task AddAsync(ProjectLineNote projectLineNote);
        void Delete(ProjectLineNote projectLineNote);
        void Update(ProjectLineNote entity);
        Task<ProjectLineNote> GetByIdAsyc(string id);
    }
}

using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories;

public interface IApplicationsRepository
{
    Task AddAsync(Applications application);
    IQueryable<Applications> Where(Expression<Func<Applications, bool>> predicate);
    Task UpdateAsync(Applications entity);
    Task<Applications> GetByIdAsync(string id);
    Task<Applications> GetByGuidAsync(string applicationGuid);
}
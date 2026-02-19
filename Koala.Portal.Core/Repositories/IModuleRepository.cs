using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories;

public interface IModuleRepository 
{
    bool any();
    Task<IEnumerable<Module>> GetModuleList();
    IQueryable<Module> Where(Expression<Func<Module, bool>> predicate);
    Task AddAsync(Module module);
    void Delete(Module module);
    Module UpdateAsync(Module entity);
    Task<Module> GetByIdAsyc(string id);

}
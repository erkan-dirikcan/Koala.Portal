using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction?> Where(Expression<Func<Transaction?, bool>> predicate);
        Task<Transaction?> GetByIdAsync(string id);
        Task AddAsync(Transaction transaction);
        void UpdateAsync(Transaction entity);

    }
}

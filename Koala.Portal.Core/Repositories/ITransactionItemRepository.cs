using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories;

public interface ITransactionItemRepository
{
    Task AddAsync(TransactionItem entity);
    Task<List<TransactionItem>> GetAllAsync();
    Task<TransactionItem?> GetAsync(string id);
    Task<List<TransactionItem?>> Where(Expression<Func<TransactionItem?, bool>> predicate);
}
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task<IEnumerable<TransactionType>> GetTransactionTypeList();
        Task<TransactionType> GetByIdAsync(string id);
        Task AddAsync(TransactionType transactionType);
        Task UpdateAsync(TransactionType entity);
        void Delete(TransactionType transactionType);
    }
}

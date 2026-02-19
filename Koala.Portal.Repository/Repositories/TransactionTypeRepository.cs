using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TransactionType> _dbSet;

        public TransactionTypeRepository(AppDbContext context)
        {
            _context= context;
            _dbSet = _context.Set<TransactionType>();
        }
        public async Task AddAsync(TransactionType transactionType)
        {
            await _context.AddAsync(transactionType);
        }

        public  void Delete(TransactionType transactionType)
        {
             _context.Remove(transactionType);
        }

        public async Task<TransactionType> GetByIdAsync(string id)
        {

            var tType = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (tType != null)
            {
                _context.Entry(tType).State = EntityState.Detached;
            }
            return tType;
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypeList()
        {
            return await _dbSet.Where(x=>x.Status !=StatusEnum.Deleted).ToListAsync();
        }

        public async Task UpdateAsync(TransactionType entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}

using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Transaction> _dbSet;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Transaction>();
    }
    public IQueryable<Transaction?> Where(Expression<Func<Transaction?, bool>> predicate)
    {
        return _dbSet.Include(x => x.TransactionType)
                     .Include(x => x.TransactionItems)
                     .Include(x => x.AppUser)
                     .Where(predicate);
    }

    public async Task<Transaction?> GetByIdAsync(string id)
    {
        return await _dbSet.Include(x => x.TransactionType)
                           .Include(x => x.TransactionItems)
                           .Include(x => x.AppUser)
                           .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Transaction transaction)
    {
        await _dbSet.AddAsync(transaction);
    }

    public void UpdateAsync(Transaction entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
    }
}
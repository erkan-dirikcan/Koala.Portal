using System.Linq.Expressions;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories;

public class TransactionItemRepository: ITransactionItemRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<TransactionItem> _dbSet;

    public TransactionItemRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TransactionItem>();
    }

    public async Task AddAsync(TransactionItem entity)
    {
        await _dbSet.AddAsync((entity));
    }

    public async Task<List<TransactionItem>> GetAllAsync()
    {
        return await _dbSet.Include(x => x.Transaction).ToListAsync();
    }

    public async Task<TransactionItem?> GetAsync(string id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TransactionItem?>> Where(Expression<Func<TransactionItem?, bool>> predicate)
    {
        return await _dbSet.Include(x => x.Transaction).Where(predicate).ToListAsync();
    }
}
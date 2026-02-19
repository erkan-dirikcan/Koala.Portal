using System.Linq.Expressions;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories;

public class FirmContactRepository : IFirmContactRepository
{
    public readonly AppDbContext _context;
    public readonly DbSet<CrmFirmContact> _dbSet;

    public FirmContactRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<CrmFirmContact>();


    }

    public async Task<IEnumerable<CrmFirmContact>> GetAllAsync(string firmId)
    {
        return await _dbSet
            .Include(x => x.Firm)
            .Include(x => x.Phones)
            .Where(x=>x.FirmId==firmId)
            .ToListAsync();
    }

    public async Task<IEnumerable<CrmFirmContact>> GetAllByOidAsync(string firmOid)
    {
        return await _dbSet
            .Include(x => x.Firm)
            .Include(x => x.Phones)
            .Where(x=>x.Oid==firmOid)
            .ToListAsync();
    }

    public IQueryable<CrmFirmContact> Where(Expression<Func<CrmFirmContact, bool>> predicate)
    {
        return _dbSet
            .Include(x => x.Firm)
            .Include(x => x.Phones)
            .Where(predicate);
    }

    public async Task<CrmFirmContact?> GetByIdAsync(string id)
    {
        var contact = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (contact != null)
        {
            _context.Entry(contact).State = EntityState.Detached;
        }
        return contact;
    }
    
    public async Task<CrmFirmContact?> GetByOidAsync(string oid)
    {
        var contact = await _dbSet.FirstOrDefaultAsync(x => x.Oid == oid);
        if (contact != null)
        {
            _context.Entry(contact).State = EntityState.Detached;
        }
        return contact;
    }
}
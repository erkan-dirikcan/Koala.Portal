using System.Linq.Expressions;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories;

public class ApplicationsRepository : IApplicationsRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Applications> _dbSet;

    public ApplicationsRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Applications>();
    }

    public async Task AddAsync(Applications application)
    {
        await _dbSet.AddAsync(application);
    }

    public IQueryable<Applications> Where(Expression<Func<Applications, bool>> predicate)
    {
        return _dbSet.Include(x => x.ApplicationLicences).Include(x => x.Modules).Where(predicate);
    }


    public async Task UpdateAsync(Applications entity)
    {
        var res = _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<Applications> GetByIdAsync(string id)
    {
        var module = await _dbSet.Include(x => x.ApplicationLicences).Include(x=>x.Modules).FirstAsync(x => x.Id == id);
        return module;
    }

    public async Task<Applications> GetByGuidAsync(string applicationGuid)
    {
        var module = await _dbSet.Include(x => x.ApplicationLicences).Include(x => x.Modules).FirstOrDefaultAsync(x => x.AppId == applicationGuid);
        return module;
    }
}
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories;

public class AgendaRepository : BaseRepository<Agenda>, IAgendaRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Agenda> _dbSet;
    public AgendaRepository(AppDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Agenda>();
    }

    public async Task<List<Agenda>> GetAll()
    {
        return await _dbSet
            .Include(x => x.AgendaFixtures)
            .Include(x => x.FirmOfficials)
            .Include(x => x.Users)
            .Include(x => x.AgendaType)
            .Where(x => x.StartDate > DateTime.Now.AddYears(-1))
            .ToListAsync();
    }

    public async Task<List<Agenda>> GetUserAgenda(string userId)
    {
        return await _dbSet
            .Include(x => x.AgendaFixtures)
            .Include(x => x.FirmOfficials)
            .Include(x => x.Users)
            .Include(x => x.AgendaType)
            .Where(x => x.StartDate > DateTime.Now.AddYears(-1) && x.Users.Any(x=>x.UserId==userId))
            .ToListAsync();
    }
}
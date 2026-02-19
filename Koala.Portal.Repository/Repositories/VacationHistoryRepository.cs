using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class VacationHistoryRepository : IVacationHistoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<VacationHistory> _dbSet;

        public VacationHistoryRepository(AppDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<VacationHistory>();
        }
        public async Task AddVacationHistoryAsync(VacationHistory model)
        {
           await _dbSet.AddAsync(model);
        }
    }
}

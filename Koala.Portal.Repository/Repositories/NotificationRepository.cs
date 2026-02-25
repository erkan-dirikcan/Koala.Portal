using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<AppNotification> _dbSet;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<AppNotification>();
        }

        public async Task AddAsync(AppNotification notification)
        {
            await _dbSet.AddAsync(notification);
        }

        public void Update(AppNotification entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(AppNotification entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<AppNotification> Where(Expression<Func<AppNotification, bool>> predicate)
        {
            return _dbSet
                .Include(n => n.User)
                .Where(predicate);
        }

        public async Task<AppNotification?> GetByIdAsync(string id)
        {
            return await _dbSet
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}

using Koala.Portal.Core.Models;
using System.Linq.Expressions;

namespace Koala.Portal.Core.Repositories
{
    public interface INotificationRepository
    {
        Task AddAsync(AppNotification notification);
        void Update(AppNotification entity);
        void Delete(AppNotification entity);
        IQueryable<AppNotification> Where(Expression<Func<AppNotification, bool>> predicate);
        Task<AppNotification?> GetByIdAsync(string id);
    }
}

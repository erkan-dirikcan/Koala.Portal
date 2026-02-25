using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface INotificationService
    {
        Task<Response> NotifyProjectAssignedAsync(string projectId, string userId);
        Task<Response> NotifyProjectStatusChangedAsync(string projectId, ProjectStatusEnum newStatus);
        Task<Response> NotifyWorkAssignedAsync(string workId, string userId);
        Task<Response> NotifyProjectLineAddedAsync(string projectLineId, string assignedUserId);
        Task<Response> NotifyProjectLineStatusChangedAsync(string projectLineId, ProjectLineStatusEnum newStatus);
        Task<Response> CreateInAppNotificationAsync(string userId, string title, string message, string? actionType = null, string? entityId = null, string? actionUrl = null);
        Task<Response<List<AppNotificationViewModel>>> GetUserNotificationsAsync(string userId, bool unreadOnly = false);
        Task<Response> MarkNotificationAsReadAsync(string notificationId, string userId);
        Task<Response> MarkAllNotificationsAsReadAsync(string userId);
    }
}

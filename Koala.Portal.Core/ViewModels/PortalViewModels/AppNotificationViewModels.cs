namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AppNotificationViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public string? ActionType { get; set; }
        public string? EntityId { get; set; }
        public string? ActionUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public string TimeAgo { get; set; }
    }

    public class UnreadNotificationCountViewModel
    {
        public int Count { get; set; }
    }
}

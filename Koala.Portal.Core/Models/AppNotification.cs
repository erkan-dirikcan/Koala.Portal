using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class AppNotification : CommonProperty
    {
        public string Id { get; set; } = Tools.CreateGuidStr().ToString();

        /// <summary>
        /// The user who will receive this notification
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Notification title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Notification message content
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Whether the notification has been read
        /// </summary>
        public bool IsRead { get; set; } = false;

        /// <summary>
        /// When the notification was read
        /// </summary>
        public DateTime? ReadAt { get; set; }

        /// <summary>
        /// Type of action that can be taken (e.g., "ViewProject", "ViewWork")
        /// </summary>
        public string? ActionType { get; set; }

        /// <summary>
        /// ID of the entity related to this notification
        /// </summary>
        public string? EntityId { get; set; }

        /// <summary>
        /// URL to navigate when clicking the notification
        /// </summary>
        public string? ActionUrl { get; set; }

        /// <summary>
        /// Additional data in JSON format
        /// </summary>
        public string? Data { get; set; }

        /// <summary>
        /// Status of the notification
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public virtual AppUser User { get; set; }
    }
}

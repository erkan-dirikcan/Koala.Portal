using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class TransactionItem : CommonProperty
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string? TransactionId { get; set; }
        public string? Description { get; set; }
        public bool IsSuccess { get; set; } = false;

        public virtual Transaction? Transaction { get; set; }
    }
}

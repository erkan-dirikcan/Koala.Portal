using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class SupportFile
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string TicketId { get; set; }
        public string AddedByOid { get; set; }
        public string UrlSlug { get; set; }
        public string FileName { get; set; }
        public string Endwith { get; set; }
        public FileAddedEnum AddedByType { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public StatusEnum Status { get; set; } = StatusEnum.Active;
    }
}

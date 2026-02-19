using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels;

public class GetSupportFileViewModel
{
    public string Id { get; set; }
    public string TicketId { get; set; }
    public string AddedByOid { get; set; }
    public string UrlSlug { get; set; }
    public string FileName { get; set; }
    public string Endwith { get; set; }
    public AttachmentType AttachmentType { get; set; }
}
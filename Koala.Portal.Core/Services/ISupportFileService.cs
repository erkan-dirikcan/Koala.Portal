using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services;

public interface ISupportFileService
{
    Task<Response<GetSupportFileViewModel>> GetBySupportIdAsyc(string ticketId);
    Task<Response<GetSupportFileViewModel>> GetByIdAsyc(string ticketId);
}
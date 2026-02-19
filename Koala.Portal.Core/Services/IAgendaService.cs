using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IAgendaService
    {
        Task<List<AgendaDetailViewModel>> GetAll();
        Task<List<AgendaDetailViewModel>> GetUserAgenda(string userId);
    }
}
